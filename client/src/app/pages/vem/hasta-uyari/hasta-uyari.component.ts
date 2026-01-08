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
import { HastaUyariService } from '../../../services/vem/hasta-uyari.service';
import {
  HastaUyariDto,
  CreateHastaUyariDto,
  UpdateHastaUyariDto,
  newHastaUyari
} from '../../../models/vem/hasta-uyari.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-hasta-uyari',
  templateUrl: './hasta-uyari.component.html',
  styleUrls: ['./hasta-uyari.component.scss'],
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
export class HastaUyariComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedHastaUyari: HastaUyariDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateHastaUyariDto | UpdateHastaUyariDto = { ...newHastaUyari };

  constructor(private hastaUyariService: HastaUyariService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.hastaUyariService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedHastaUyari = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedHastaUyari = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni HastaUyari';
    this.formData = { ...newHastaUyari };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedHastaUyari) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'HastaUyari Duzenle';

    try {
      const entity = await this.hastaUyariService.getById(this.selectedHastaUyari.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedHastaUyari) {
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
        await this.hastaUyariService.delete(this.selectedHastaUyari.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedHastaUyari = null;
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
        await this.hastaUyariService.create(this.formData as CreateHastaUyariDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateHastaUyariDto;
        await this.hastaUyariService.update(updateData.id, updateData);
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
