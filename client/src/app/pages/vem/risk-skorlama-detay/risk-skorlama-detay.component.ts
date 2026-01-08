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
import { RiskSkorlamaDetayService } from '../../../services/vem/risk-skorlama-detay.service';
import {
  RiskSkorlamaDetayDto,
  CreateRiskSkorlamaDetayDto,
  UpdateRiskSkorlamaDetayDto,
  newRiskSkorlamaDetay
} from '../../../models/vem/risk-skorlama-detay.model';
import notify from 'devextreme/ui/notify';
import { custom } from 'devextreme/ui/dialog';

@Component({
  selector: 'app-risk-skorlama-detay',
  templateUrl: './risk-skorlama-detay.component.html',
  styleUrls: ['./risk-skorlama-detay.component.scss'],
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
export class RiskSkorlamaDetayComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent;

  dataSource: any;
  selectedRiskSkorlamaDetay: RiskSkorlamaDetayDto | null = null;

  // Popup state
  isEditPopupVisible = false;
  isNewRecord = false;
  popupTitle = '';
  isLoading = false;

  // Form data
  formData: CreateRiskSkorlamaDetayDto | UpdateRiskSkorlamaDetayDto = { ...newRiskSkorlamaDetay };

  constructor(private riskSkorlamaDetayService: RiskSkorlamaDetayService) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.dataSource = this.riskSkorlamaDetayService.createCustomStore();
  }

  refresh(): void {
    this.dataGrid.instance.refresh();
  }

  onSelectionChanged(e: any): void {
    this.selectedRiskSkorlamaDetay = e.selectedRowsData[0] || null;
  }

  onRowDblClick(e: any): void {
    this.selectedRiskSkorlamaDetay = e.data;
    this.onEditClick();
  }

  // ADD
  onAddClick(): void {
    this.isNewRecord = true;
    this.popupTitle = 'Yeni RiskSkorlamaDetay';
    this.formData = { ...newRiskSkorlamaDetay };
    this.isEditPopupVisible = true;
  }

  // EDIT
  async onEditClick(): Promise<void> {
    if (!this.selectedRiskSkorlamaDetay) {
      notify('Lutfen bir kayit secin', 'warning', 2000);
      return;
    }

    this.isNewRecord = false;
    this.popupTitle = 'RiskSkorlamaDetay Duzenle';

    try {
      const entity = await this.riskSkorlamaDetayService.getById(this.selectedRiskSkorlamaDetay.id);
      this.formData = { ...entity };
      this.isEditPopupVisible = true;
    } catch (error) {
      notify('Kayit yuklenemedi', 'error', 2000);
    }
  }

  // DELETE
  async onDeleteClick(): Promise<void> {
    if (!this.selectedRiskSkorlamaDetay) {
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
        await this.riskSkorlamaDetayService.delete(this.selectedRiskSkorlamaDetay.id);
        notify('Kayit silindi', 'success', 2000);
        this.refresh();
        this.selectedRiskSkorlamaDetay = null;
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
        await this.riskSkorlamaDetayService.create(this.formData as CreateRiskSkorlamaDetayDto);
        notify('Kayit olusturuldu', 'success', 2000);
      } else {
        const updateData = this.formData as UpdateRiskSkorlamaDetayDto;
        await this.riskSkorlamaDetayService.update(updateData.id, updateData);
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
