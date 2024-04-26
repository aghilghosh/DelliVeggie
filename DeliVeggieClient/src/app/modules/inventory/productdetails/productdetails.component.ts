import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClient } from 'src/app/services/api.service';

@Component({
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.css']
})
export class ProductDetailsComponent implements OnInit {

  inventory$: Observable<any> | undefined;
  constructor(private apiClient: ApiClient) { }

  ngOnInit(): void {
    this.inventory$ = this.apiClient.getProducts();
  }

  restockInventory(){
    // let sub = this.apiClient.reStock().subscribe();
  }

}
