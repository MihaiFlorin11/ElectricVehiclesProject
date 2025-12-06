import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MAT_DIALOG_DATA, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Invoice } from 'src/app/entities/invoice';
import { InvoiceService } from 'src/app/services/invoices/invoice.service';

@Component({
  selector: 'app-manage-invoices',
  templateUrl: './manage-invoices.component.html',
  styleUrls: ['./manage-invoices.component.css']
})
export class ManageInvoicesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'totalPrice', 'paid', 'actions', 'add'];
  dataSource: MatTableDataSource<Invoice> = new MatTableDataSource<Invoice>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  invoice: Invoice = {
    id: 0,
    totalPrice: 0,
    paid: false,
  };
  

  constructor(private invoiceService: InvoiceService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.invoiceService.getInvoices().subscribe(
      (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  refreshTable(): void {
    this.invoiceService.getInvoices().subscribe(
      (data) => {
        this.dataSource.data = data;
    });
  }

  openDialogForCreate(): void {
    this.dialog.open(CreateInvoiceDialog, {
      data: {
        totalPrice: this.invoice.totalPrice,
        paid: this.invoice.paid
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForView(id: number): void {
    this.dialog.open(ViewInvoiceDialog, {
      data: {
        id: id,
      }
    });
  }

  openDialogForUpdate(id: number, totalPrice: number, paid: boolean): void {
    this.dialog.open(UpdateInvoiceDialog, {
      data: {
        id: id,
        totalPrice: totalPrice,
        paid: paid,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForDelete(id: number): void {
    this.dialog.open(DeleteInvoiceDialog, {
      data: {
        id: id,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }
}

@Component({
  selector: 'create-invoice-dialog',
  templateUrl: 'create-invoice-dialog.html',
})
export class CreateInvoiceDialog implements OnInit {

  createForm!: FormGroup;
  hide = true;
  status = false;

  constructor(
    public dialogRef: MatDialogRef<CreateInvoiceDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Invoice, private formBuilder: FormBuilder,
    private invoiceService: InvoiceService) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      totalPrice: [null, Validators.required],
      paid: [false, Validators.required]
    });
  }

  changeStatus(): void {
    this.status = this.createForm.value['paid'];
  }

  submit() {
    if (!this.createForm.valid) {
      return;
    }
    else {    
      this.invoiceService.createInvoice(this.createForm.value).subscribe();
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'view-invoice-dialog',
  templateUrl: 'view-invoice-dialog.html',
})
export class ViewInvoiceDialog implements OnInit {

  invoice: Invoice = {
    id: 0,
    totalPrice: 0,
    paid: true
  };

  constructor(public dialogRef: MatDialogRef<ViewInvoiceDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Invoice, 
    private invoiceService: InvoiceService) {}

  ngOnInit(): void {
    this.invoiceService.getInvoiceById(this.data.id).subscribe(
      (data) => {
        this.invoice.id = data.id;
        this.invoice.totalPrice = data.totalPrice;
        this.invoice.paid = data.paid;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}

@Component({
  selector: 'update-invoice-dialog',
  templateUrl: 'update-invoice-dialog.html',
})
export class UpdateInvoiceDialog implements OnInit {

  updateForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<UpdateInvoiceDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Invoice, private formBuilder: FormBuilder,
    private invoiceService: InvoiceService) {}

  ngOnInit(): void {
      this.updateForm = this.formBuilder.group({
        id: this.data.id,
        totalPrice: [this.data.totalPrice, Validators.required],
        paid: [this.data.paid, Validators.required]
      });
    }

  submit() {
    if (!this.updateForm.valid) {
      return;
    }
    else {
      this.invoiceService.updateInvoice(this.data.id, this.updateForm.value).subscribe();
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'delete-user-dialog',
  templateUrl: 'delete-invoice-dialog.html',
})
export class DeleteInvoiceDialog implements OnInit {
  
  invoice: Invoice = {
    id: 0,
    totalPrice: 0,
    paid: true
  };

  constructor(
    public dialogRef: MatDialogRef<DeleteInvoiceDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Invoice,
    private invoiceService: InvoiceService) {}

  ngOnInit(): void {
      
  }

  submit() {
    this.invoiceService.deleteInvoice(this.data.id).subscribe();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}