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
import { NobetciPersonelBilgisiService } from '../../../services/vem/nobetci-personel-bilgisi.service';
import {
  NobetciPersonelBilgisiDto,
  CreateNobetciPersonelBilgisiDto,
  UpdateNobetciPersonelBilgisiDto,
  newNobetciPersonelBilgisi
} from '../../../models/vem/nobetci-personel-bilgisi.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-nobetci-personel-bilgisi',
  templateUrl: './nobetci-personel-bilgisi.component.html',
  styleUrls: ['./nobetci-personel-bilgisi.component.scss'],
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
export class NobetciPersonelBilgisiComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedNobetciPersonelBilgisi: NobetciPersonelBilgisiDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateNobetciPersonelBilgisiDto | UpdateNobetciPersonelBilgisiDto = { ...newNobetciPersonelBilgisi };

  constructor(private nobetciPersonelBilgisiService: NobetciPersonelBilgisiService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.nobetciPersonelBilgisiService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedNobetciPersonelBilgisi = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedNobetciPersonelBilgisi = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni NobetciPersonelBilgisi';
    this.formData = { ...newNobetciPersonelBilgisi };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedNobetciPersonelBilgisi) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'NobetciPersonelBilgisi Duzenle';

    try {
      const entity = await this.nobetciPersonelBilgisiService.getById(this.selectedNobetciPersonelBilgisi.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedNobetciPersonelBilgisi) {
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
        await this.nobetciPersonelBilgisiService.delete(this.selectedNobetciPersonelBilgisi.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedNobetciPersonelBilgisi = null;
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
        await this.nobetciPersonelBilgisiService.create(this.formData as CreateNobetciPersonelBilgisiDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateNobetciPersonelBilgisiDto;
        await this.nobetciPersonelBilgisiService.update(updateData.id, updateData);
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
