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
import { HastaTibbiBilgiService } from '../../../services/vem/hasta-tibbi-bilgi.service';
import {
  HastaTibbiBilgiDto,
  CreateHastaTibbiBilgiDto,
  UpdateHastaTibbiBilgiDto,
  newHastaTibbiBilgi
} from '../../../models/vem/hasta-tibbi-bilgi.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-hasta-tibbi-bilgi',
  templateUrl: './hasta-tibbi-bilgi.component.html',
  styleUrls: ['./hasta-tibbi-bilgi.component.scss'],
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
export class HastaTibbiBilgiComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedHastaTibbiBilgi: HastaTibbiBilgiDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateHastaTibbiBilgiDto | UpdateHastaTibbiBilgiDto = { ...newHastaTibbiBilgi };

  constructor(private hastaTibbiBilgiService: HastaTibbiBilgiService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.hastaTibbiBilgiService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedHastaTibbiBilgi = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedHastaTibbiBilgi = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni HastaTibbiBilgi';
    this.formData = { ...newHastaTibbiBilgi };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedHastaTibbiBilgi) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'HastaTibbiBilgi Duzenle';

    try {
      const entity = await this.hastaTibbiBilgiService.getById(this.selectedHastaTibbiBilgi.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedHastaTibbiBilgi) {
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
        await this.hastaTibbiBilgiService.delete(this.selectedHastaTibbiBilgi.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedHastaTibbiBilgi = null;
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
        await this.hastaTibbiBilgiService.create(this.formData as CreateHastaTibbiBilgiDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateHastaTibbiBilgiDto;
        await this.hastaTibbiBilgiService.update(updateData.id, updateData);
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
