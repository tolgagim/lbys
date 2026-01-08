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
import { EvdeSaglikIzlemService } from '../../../services/vem/evde-saglik-izlem.service';
import {
  EvdeSaglikIzlemDto,
  CreateEvdeSaglikIzlemDto,
  UpdateEvdeSaglikIzlemDto,
  newEvdeSaglikIzlem
} from '../../../models/vem/evde-saglik-izlem.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-evde-saglik-izlem',
  templateUrl: './evde-saglik-izlem.component.html',
  styleUrls: ['./evde-saglik-izlem.component.scss'],
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
export class EvdeSaglikIzlemComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedEvdeSaglikIzlem: EvdeSaglikIzlemDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateEvdeSaglikIzlemDto | UpdateEvdeSaglikIzlemDto = { ...newEvdeSaglikIzlem };

  constructor(private evdeSaglikIzlemService: EvdeSaglikIzlemService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.evdeSaglikIzlemService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedEvdeSaglikIzlem = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedEvdeSaglikIzlem = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni EvdeSaglikIzlem';
    this.formData = { ...newEvdeSaglikIzlem };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedEvdeSaglikIzlem) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'EvdeSaglikIzlem Duzenle';

    try {
      const entity = await this.evdeSaglikIzlemService.getById(this.selectedEvdeSaglikIzlem.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedEvdeSaglikIzlem) {
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
        await this.evdeSaglikIzlemService.delete(this.selectedEvdeSaglikIzlem.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedEvdeSaglikIzlem = null;
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
        await this.evdeSaglikIzlemService.create(this.formData as CreateEvdeSaglikIzlemDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateEvdeSaglikIzlemDto;
        await this.evdeSaglikIzlemService.update(updateData.id, updateData);
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
