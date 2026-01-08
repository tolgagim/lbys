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
import { PersonelBordroSondurumService } from '../../../services/vem/personel-bordro-sondurum.service';
import {
  PersonelBordroSondurumDto,
  CreatePersonelBordroSondurumDto,
  UpdatePersonelBordroSondurumDto,
  newPersonelBordroSondurum
} from '../../../models/vem/personel-bordro-sondurum.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-personel-bordro-sondurum',
  templateUrl: './personel-bordro-sondurum.component.html',
  styleUrls: ['./personel-bordro-sondurum.component.scss'],
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
export class PersonelBordroSondurumComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedPersonelBordroSondurum: PersonelBordroSondurumDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreatePersonelBordroSondurumDto | UpdatePersonelBordroSondurumDto = { ...newPersonelBordroSondurum };

  constructor(private personelBordroSondurumService: PersonelBordroSondurumService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.personelBordroSondurumService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedPersonelBordroSondurum = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedPersonelBordroSondurum = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni PersonelBordroSondurum';
    this.formData = { ...newPersonelBordroSondurum };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedPersonelBordroSondurum) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'PersonelBordroSondurum Duzenle';

    try {
      const entity = await this.personelBordroSondurumService.getById(this.selectedPersonelBordroSondurum.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedPersonelBordroSondurum) {
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
        await this.personelBordroSondurumService.delete(this.selectedPersonelBordroSondurum.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedPersonelBordroSondurum = null;
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
        await this.personelBordroSondurumService.create(this.formData as CreatePersonelBordroSondurumDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdatePersonelBordroSondurumDto;
        await this.personelBordroSondurumService.update(updateData.id, updateData);
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
