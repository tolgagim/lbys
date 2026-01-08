import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxDataGridModule,
  DxDataGridComponent,
  DxButtonModule,
  DxTextBoxModule,
  DxDateBoxModule,
  DxSelectBoxModule,
  DxValidatorModule,
  DxValidationGroupModule,
  DxTextAreaModule,
} from 'devextreme-angular';
import { FormPopupComponent } from '../../../components/shared/form-popup/form-popup.component';
import { HastaService } from '../../../services/vem/hasta.service';
import {
  HastaDto,
  CreateHastaDto,
  UpdateHastaDto,
  newHasta
} from '../../../models/vem/hasta.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-hasta',
  templateUrl: './hasta.component.html',
  styleUrls: ['./hasta.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    DxDataGridModule,
    DxButtonModule,
    DxTextBoxModule,
    DxDateBoxModule,
    DxSelectBoxModule,
    DxValidatorModule,
    DxValidationGroupModule,
    DxTextAreaModule,
    FormPopupComponent
  ]
})
export class HastaComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedHasta: HastaDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateHastaDto | UpdateHastaDto = { ...newHasta };

  // Cinsiyet options
  cinsiyetOptions = [
    { value: 'E', text: 'Erkek' },
    { value: 'K', text: 'Kadin' }
  ];

  // Kan grubu options
  kanGrubuOptions = [
    { value: 'A+', text: 'A Rh+' },
    { value: 'A-', text: 'A Rh-' },
    { value: 'B+', text: 'B Rh+' },
    { value: 'B-', text: 'B Rh-' },
    { value: 'AB+', text: 'AB Rh+' },
    { value: 'AB-', text: 'AB Rh-' },
    { value: '0+', text: '0 Rh+' },
    { value: '0-', text: '0 Rh-' }
  ];

  constructor(private hastaService: HastaService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.hastaService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedHasta = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedHasta = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni Hasta';
    this.formData = { ...newHasta };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedHasta) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'Hasta Duzenle';

    try {
      const hasta = await this.hastaService.getById(this.selectedHasta.id);
      this.formData = { ...hasta };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedHasta) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    const result = await custom({
      title: 'Silme Onayi',
      messageHtml: `<b>${this.selectedHasta.ad} ${this.selectedHasta.soyad}</b> kaydini silmek istediginize emin misiniz?`,
      buttons: [
        { text: 'Evet', onClick: () => true },
        { text: 'Hayir', onClick: () => false }
      ]
    }).show();

    if (result) {
      try {
        await this.hastaService.delete(this.selectedHasta.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedHasta = null;
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
        await this.hastaService.create(this.formData as CreateHastaDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateHastaDto;
        await this.hastaService.update(updateData.id, updateData);
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
