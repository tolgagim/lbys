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
import { HizmetService } from '../../../services/vem/hizmet.service';
import {
  HizmetDto,
  CreateHizmetDto,
  UpdateHizmetDto,
  newHizmet
} from '../../../models/vem/hizmet.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-hizmet',
  templateUrl: './hizmet.component.html',
  styleUrls: ['./hizmet.component.scss'],
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
export class HizmetComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedHizmet: HizmetDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateHizmetDto | UpdateHizmetDto = { ...newHizmet };

  constructor(private hizmetService: HizmetService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.hizmetService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedHizmet = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedHizmet = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni Hizmet';
    this.formData = { ...newHizmet };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedHizmet) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'Hizmet Duzenle';

    try {
      const entity = await this.hizmetService.getById(this.selectedHizmet.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedHizmet) {
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
        await this.hizmetService.delete(this.selectedHizmet.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedHizmet = null;
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
        await this.hizmetService.create(this.formData as CreateHizmetDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateHizmetDto;
        await this.hizmetService.update(updateData.id, updateData);
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
