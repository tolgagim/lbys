import {
  Component, ViewChild, NgModule,
} from '@angular/core';
import {
  DxButtonModule,
  DxDataGridModule,
  DxDataGridComponent,
  DxDropDownButtonModule,
  DxSelectBoxModule,
  DxTextBoxModule,
} from 'devextreme-angular';
import { DxDataGridTypes } from 'devextreme-angular/ui/data-grid';
import { exportDataGrid as exportDataGridToPdf } from 'devextreme/pdf_exporter';
import { exportDataGrid as exportDataGridToXLSX } from 'devextreme/excel_exporter';

import { Contact, contactStatusList, ContactStatus, } from 'src/app/types/contact';
import { DxDropDownButtonTypes, DxDropDownButtonModule as DxDropDownButtonModule_1 } from 'devextreme-angular/ui/drop-down-button';
import DataSource from 'devextreme/data/data_source';
import { CommonModule } from '@angular/common';
import { DataService } from 'src/app/services';
import { Workbook } from 'exceljs';
import { saveAs } from 'file-saver-es';
import { jsPDF } from 'jspdf';
import notify from "devextreme/ui/notify";
import { formatPhone } from 'src/app/pipes/phone.pipe';


import { ContactNewFormComponent } from 'src/app/components/library/contact-new-form/contact-new-form.component';
import { ContactNewFormComponent as ContactNewFormComponent_1 } from '../../components/library/contact-new-form/contact-new-form.component';
import { FormPopupComponent } from '../../components/utils/form-popup/form-popup.component';
import { ContactPanelComponent } from '../../components/library/contact-panel/contact-panel.component';
import { ContactStatusComponent } from '../../components/utils/contact-status/contact-status.component';
import { DxTemplateModule } from 'devextreme-angular/core';
import { DxoLoadPanelModule, DxoScrollingModule, DxoSelectionModule, DxoSortingModule, DxoHeaderFilterModule, DxoColumnChooserModule, DxoSearchPanelModule, DxoExportModule, DxoToolbarModule, DxiItemModule, DxiColumnModule } from 'devextreme-angular/ui/nested';
import { HttpClientModule } from '@angular/common/http';

type FilterContactStatus = ContactStatus | 'All';

@Component({
    templateUrl: './crm-contact-list.component.html',
    styleUrls: ['./crm-contact-list.component.scss'],
    providers: [DataService],
    standalone: true,
    imports: [
        DxDataGridModule,
        DxoLoadPanelModule,
        DxoScrollingModule,
        DxoSelectionModule,
        DxoSortingModule,
        DxoHeaderFilterModule,
        DxoColumnChooserModule,
        DxoSearchPanelModule,
        DxoExportModule,
        DxoToolbarModule,
        DxiItemModule,
        DxDropDownButtonModule_1,
        DxButtonModule,
        DxiColumnModule,
        DxTemplateModule,
        ContactStatusComponent,
        DxSelectBoxModule,
        DxTextBoxModule,
        ContactPanelComponent,
        FormPopupComponent,
        ContactNewFormComponent_1,
        HttpClientModule
    ],
})
export class CrmContactListComponent {
  @ViewChild(DxDataGridComponent, { static: true }) dataGrid: DxDataGridComponent;

  @ViewChild(ContactNewFormComponent, { static: false }) contactNewForm: ContactNewFormComponent;

  statusList = contactStatusList;

  filterStatusList = ['All', ...contactStatusList];

  isPanelOpened = false;

  isAddContactPopupOpened = false;

  userId: number;

  dataSource = new DataSource<Contact[], string>({
    key: 'id',
    load: () => new Promise((resolve, reject) => {
      this.service.getContacts().subscribe({
          next: (data: Contact[]) => resolve(data),
          error: ({message}) => reject(message)
        })
    }),
  });

  constructor(private service: DataService) {}

  addContact() {
    this.isAddContactPopupOpened = true;
  };

  refresh = () => {
    this.dataGrid.instance.refresh();
  };

  rowClick(e: DxDataGridTypes.RowClickEvent) {
    const { data } = e;

    this.userId = data.id;
    this.isPanelOpened = true;
  }

  onOpenedChange = (value: boolean) => {
    if (!value) {
      this.userId = null;
    }
  };

  onPinnedChange = () => {
    this.dataGrid.instance.updateDimensions();
  };

  filterByStatus = (e: DxDropDownButtonTypes.SelectionChangedEvent) => {
    const { item: status }: { item: FilterContactStatus } = e;

    if (status === 'All') {
      this.dataGrid.instance.clearFilter();
    } else {
      this.dataGrid.instance.filter(['status', '=', status]);
    }
  };

  customizePhoneCell = ({ value }) => value ? formatPhone(value) : undefined;

  onExporting(e) {
    if (e.format === 'pdf') {
      const doc = new jsPDF();
      exportDataGridToPdf({
        jsPDFDocument: doc,
        component: e.component,
      }).then(() => {
        doc.save('Contacts.pdf');
      });
    } else {
      const workbook = new Workbook();
      const worksheet = workbook.addWorksheet('Contacts');

      exportDataGridToXLSX({
        component: e.component,
        worksheet,
        autoFilterEnabled: true,
      }).then(() => {
        workbook.xlsx.writeBuffer().then((buffer) => {
          saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Contacts.xlsx');
        });
      });
      e.cancel = true;
    }
  }

  onClickSaveNewContact = () => {
    const { firstName, lastName} = this.contactNewForm.getNewContactData();
    notify({
        message: `New contact "${firstName} ${lastName}" saved`,
        position: { at: 'bottom center', my: 'bottom center' }
      },
      'success');
  };
}


