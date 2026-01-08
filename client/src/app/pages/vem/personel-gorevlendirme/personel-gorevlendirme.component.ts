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
import { PersonelGorevlendirmeService } from '../../../services/vem/personel-gorevlendirme.service';
import {
  PersonelGorevlendirmeDto,
  CreatePersonelGorevlendirmeDto,
  UpdatePersonelGorevlendirmeDto,
  newPersonelGorevlendirme
} from '../../../models/vem/personel-gorevlendirme.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-personel-gorevlendirme',
  templateUrl: './personel-gorevlendirme.component.html',
  styleUrls: ['./personel-gorevlendirme.component.scss'],
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
export class PersonelGorevlendirmeComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedPersonelGorevlendirme: PersonelGorevlendirmeDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreatePersonelGorevlendirmeDto | UpdatePersonelGorevlendirmeDto = { ...newPersonelGorevlendirme };

  constructor(private personelGorevlendirmeService: PersonelGorevlendirmeService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.personelGorevlendirmeService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedPersonelGorevlendirme = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedPersonelGorevlendirme = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni PersonelGorevlendirme';
    this.formData = { ...newPersonelGorevlendirme };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedPersonelGorevlendirme) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'PersonelGorevlendirme Duzenle';

    try {
      const entity = await this.personelGorevlendirmeService.getById(this.selectedPersonelGorevlendirme.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedPersonelGorevlendirme) {
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
        await this.personelGorevlendirmeService.delete(this.selectedPersonelGorevlendirme.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedPersonelGorevlendirme = null;
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
        await this.personelGorevlendirmeService.create(this.formData as CreatePersonelGorevlendirmeDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdatePersonelGorevlendirmeDto;
        await this.personelGorevlendirmeService.update(updateData.id, updateData);
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
