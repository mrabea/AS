import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers: any;
  currentCustomer = null;
  currentIndex = -1;
  name = '';
  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.readCustomers();
  }
  readCustomers(): void {
    this.customerService.readAll()
      .subscribe(
        customers => {
          this.customers = customers;
          console.log(customers);
        },
        error => {
          console.log(error);
        });
  }

  refresh(): void {
    this.readCustomers();
    this.currentCustomer = null;
    this.currentIndex = -1;
  }

  btnClick= function (id) {
    this.router.navigateByUrl('/customer/'+id);
};


  searchByName(): void {
    this.customerService.searchByName(this.name)
      .subscribe(
        customers => {
          this.customers = customers;
          console.log(customers);
        },
        error => {
          console.log(error);
        });
  }
}
