import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxDataGridModule,
  DxDataGridComponent,
  DxButtonModule,
  DxTextBoxModule,
  DxDateBoxModule,
  DxSelectBoxModule,
  DxNumberBoxModule,
  DxCheckBoxModule,
  DxValidatorModule,
  DxValidationGroupModule,
  DxTextAreaModule,
} from 'devextreme-angular';
import { FormPopupComponent } from '../../../components/shared/form-popup/form-popup.component';
import { SterilizasyonYikamaService } from '../../../services/vem/sterilizasyon-yikama.service';
import {
  SterilizasyonYikamaDto,
  CreateSterilizasyonYikamaDto,
  UpdateSterilizasyonYikamaDto,
  newSterilizasyonYikama
} from '../../../models/vem/sterilizasyon-yikama.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-sterilizasyon-yikama',
  templateUrl: './sterilizasyon-yikama.component.html',
  styleUrls: ['./sterilizasyon-yikama.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    DxDataGridModule,
    DxButtonModule,
    DxTextBoxModule,
    DxDateBoxModule,
    DxSelectBoxModule,
    DxNumberBoxModule,
    DxCheckBoxModule,
    DxValidatorModule,
    DxValidationGroupModule,
    DxTextAreaModule,
    FormPopupComponent
  ]
})
export class SterilizasyonYikamaComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedSterilizasyonYikama: SterilizasyonYikamaDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateSterilizasyonYikamaDto | UpdateSterilizasyonYikamaDto = { ...newSterilizasyonYikama };

  constructor(private sterilizasyonYikamaService: SterilizasyonYikamaService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.sterilizasyonYikamaService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedSterilizasyonYikama = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedSterilizasyonYikama = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni SterilizasyonYikama';
    this.formData = { ...newSterilizasyonYikama };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedSterilizasyonYikama) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'SterilizasyonYikama Duzenle';

    try {
      const entity = await this.sterilizasyonYikamaService.getById(this.selectedSterilizasyonYikama.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedSterilizasyonYikama) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    const result = await custom({
      title: 'Silme Onayi',
      messageHtml: `Bu kaydi silmek istediginize emin misiniz?`,
      buttons: [
        { text: 'Evet', onClick: () => true },
        { text: 'Hayir', onClick: () => false }
      ]
    }).show();

    if (result) {
      try {
        await this.sterilizasyonYikamaService.delete(this.selectedSterilizasyonYikama.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedSterilizasyonYikama = null;
      } catch (error) {
        notify('Kayit silinemedi', 'error', 2000);
      }
    }
  }

  // SAVE
  async onSaveClick(): Promise<void> {
    this.isLoading = true;
    try {
      if (this.isNewRecord) {
        await this.sterilizasyonYikamaService.create(this.formData as CreateSterilizasyonYikamaDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateSterilizasyonYikamaDto;
        await this.sterilizasyonYikamaService.update(updateData.id, updateData);
        notify('Kayit guncellendi', 'success', 2000);
      }

      this.isEditPopupVisible = false;
      this.refresh();
    } catch (error: any) {
      const message = error?.error?.message || 'Islem basarisiz';
      notify(message, 'error', 3000);
    } finally {
      this.isLoading = false;
    }
  }

  onCancelClick(): void {
    this.isEditPopupVisible = false;
  }
}
