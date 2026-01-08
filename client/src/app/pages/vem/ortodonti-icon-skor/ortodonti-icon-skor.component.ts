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
import { OrtodontiIconSkorService } from '../../../services/vem/ortodonti-icon-skor.service';
import {
  OrtodontiIconSkorDto,
  CreateOrtodontiIconSkorDto,
  UpdateOrtodontiIconSkorDto,
  newOrtodontiIconSkor
} from '../../../models/vem/ortodonti-icon-skor.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-ortodonti-icon-skor',
  templateUrl: './ortodonti-icon-skor.component.html',
  styleUrls: ['./ortodonti-icon-skor.component.scss'],
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
export class OrtodontiIconSkorComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedOrtodontiIconSkor: OrtodontiIconSkorDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateOrtodontiIconSkorDto | UpdateOrtodontiIconSkorDto = { ...newOrtodontiIconSkor };

  constructor(private ortodontiIconSkorService: OrtodontiIconSkorService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.ortodontiIconSkorService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedOrtodontiIconSkor = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedOrtodontiIconSkor = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni OrtodontiIconSkor';
    this.formData = { ...newOrtodontiIconSkor };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedOrtodontiIconSkor) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'OrtodontiIconSkor Duzenle';

    try {
      const entity = await this.ortodontiIconSkorService.getById(this.selectedOrtodontiIconSkor.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedOrtodontiIconSkor) {
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
        await this.ortodontiIconSkorService.delete(this.selectedOrtodontiIconSkor.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedOrtodontiIconSkor = null;
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
        await this.ortodontiIconSkorService.create(this.formData as CreateOrtodontiIconSkorDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateOrtodontiIconSkorDto;
        await this.ortodontiIconSkorService.update(updateData.id, updateData);
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
