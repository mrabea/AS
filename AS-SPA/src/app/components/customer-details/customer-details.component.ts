import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  currentCustomer = null;
  message = '';
  constructor(
    private customerService: CustomerService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getCustomer(this.route.snapshot.paramMap.get('id'));
  }
  getCustomer(id  ) {
    this.customerService.read(id)
      .subscribe(
        customer => {
          this.currentCustomer = customer;
          console.log(customer);
        },
        error => {
          console.log(error);
        });
  }

  updateCustomer(): void {
    this.customerService.update(this.currentCustomer.customerId, this.currentCustomer)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The customer was updated!';
        },
        error => {
          console.log(error);
        });
  }

  deleteCustomer(): void {
    this.customerService.delete(this.currentCustomer.customerId)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/customers']);
        },
        error => {
          console.log(error);
        });
  }
}
