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
import { AmeliyatIslemService } from '../../../services/vem/ameliyat-islem.service';
import {
  AmeliyatIslemDto,
  CreateAmeliyatIslemDto,
  UpdateAmeliyatIslemDto,
  newAmeliyatIslem
} from '../../../models/vem/ameliyat-islem.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-ameliyat-islem',
  templateUrl: './ameliyat-islem.component.html',
  styleUrls: ['./ameliyat-islem.component.scss'],
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
export class AmeliyatIslemComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedAmeliyatIslem: AmeliyatIslemDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateAmeliyatIslemDto | UpdateAmeliyatIslemDto = { ...newAmeliyatIslem };

  constructor(private ameliyatIslemService: AmeliyatIslemService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.ameliyatIslemService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedAmeliyatIslem = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedAmeliyatIslem = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni AmeliyatIslem';
    this.formData = { ...newAmeliyatIslem };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedAmeliyatIslem) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'AmeliyatIslem Duzenle';

    try {
      const entity = await this.ameliyatIslemService.getById(this.selectedAmeliyatIslem.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedAmeliyatIslem) {
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
        await this.ameliyatIslemService.delete(this.selectedAmeliyatIslem.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedAmeliyatIslem = null;
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
        await this.ameliyatIslemService.create(this.formData as CreateAmeliyatIslemDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateAmeliyatIslemDto;
        await this.ameliyatIslemService.update(updateData.id, updateData);
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
