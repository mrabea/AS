import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
@Component({
  selector: 'app-customer-create',
  templateUrl: './customer-create.component.html',
  styleUrls: ['./customer-create.component.css']
})
export class CustomerCreateComponent implements OnInit {

  customer = {
    customerName: '',
    phoneNumber: ''
  };
  submitted = false;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
  }

  createCustomer(): void {
    const data = {
      customerName: this.customer.customerName,
      phoneNumber: this.customer.phoneNumber
    };

    this.customerService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newCustomer(): void {
    this.submitted = false;
    this.customer = {
      customerName: '',
      phoneNumber :''
    };
  }


}
