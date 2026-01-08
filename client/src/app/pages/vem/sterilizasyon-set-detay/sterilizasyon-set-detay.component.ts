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
import { SterilizasyonSetDetayService } from '../../../services/vem/sterilizasyon-set-detay.service';
import {
  SterilizasyonSetDetayDto,
  CreateSterilizasyonSetDetayDto,
  UpdateSterilizasyonSetDetayDto,
  newSterilizasyonSetDetay
} from '../../../models/vem/sterilizasyon-set-detay.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-sterilizasyon-set-detay',
  templateUrl: './sterilizasyon-set-detay.component.html',
  styleUrls: ['./sterilizasyon-set-detay.component.scss'],
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
export class SterilizasyonSetDetayComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedSterilizasyonSetDetay: SterilizasyonSetDetayDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateSterilizasyonSetDetayDto | UpdateSterilizasyonSetDetayDto = { ...newSterilizasyonSetDetay };

  constructor(private sterilizasyonSetDetayService: SterilizasyonSetDetayService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.sterilizasyonSetDetayService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedSterilizasyonSetDetay = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedSterilizasyonSetDetay = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni SterilizasyonSetDetay';
    this.formData = { ...newSterilizasyonSetDetay };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedSterilizasyonSetDetay) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'SterilizasyonSetDetay Duzenle';

    try {
      const entity = await this.sterilizasyonSetDetayService.getById(this.selectedSterilizasyonSetDetay.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedSterilizasyonSetDetay) {
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
        await this.sterilizasyonSetDetayService.delete(this.selectedSterilizasyonSetDetay.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedSterilizasyonSetDetay = null;
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
        await this.sterilizasyonSetDetayService.create(this.formData as CreateSterilizasyonSetDetayDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateSterilizasyonSetDetayDto;
        await this.sterilizasyonSetDetayService.update(updateData.id, updateData);
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
