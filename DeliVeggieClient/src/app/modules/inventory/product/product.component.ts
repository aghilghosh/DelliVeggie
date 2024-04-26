import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApiClient } from 'src/app/services/api.service';

@Component({
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  inventory$: Observable<any> | undefined;
  constructor(private apiClient: ApiClient,
    private router: Router) { }

  ngOnInit(): void {
    this.inventory$ = this.apiClient.getProducts();
  }

  onProductSelected(product: any) {

    this.router.navigate([`product/${product.Id}`]);
  }
}
