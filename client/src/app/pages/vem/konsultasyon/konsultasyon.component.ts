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
import { KonsultasyonService } from '../../../services/vem/konsultasyon.service';
import {
  KonsultasyonDto,
  CreateKonsultasyonDto,
  UpdateKonsultasyonDto,
  newKonsultasyon
} from '../../../models/vem/konsultasyon.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-konsultasyon',
  templateUrl: './konsultasyon.component.html',
  styleUrls: ['./konsultasyon.component.scss'],
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
export class KonsultasyonComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedKonsultasyon: KonsultasyonDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateKonsultasyonDto | UpdateKonsultasyonDto = { ...newKonsultasyon };

  constructor(private konsultasyonService: KonsultasyonService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.konsultasyonService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedKonsultasyon = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedKonsultasyon = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni Konsultasyon';
    this.formData = { ...newKonsultasyon };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedKonsultasyon) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'Konsultasyon Duzenle';

    try {
      const entity = await this.konsultasyonService.getById(this.selectedKonsultasyon.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedKonsultasyon) {
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
        await this.konsultasyonService.delete(this.selectedKonsultasyon.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedKonsultasyon = null;
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
        await this.konsultasyonService.create(this.formData as CreateKonsultasyonDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateKonsultasyonDto;
        await this.konsultasyonService.update(updateData.id, updateData);
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
