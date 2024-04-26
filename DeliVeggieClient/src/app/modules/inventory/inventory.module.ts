import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ProductDetailsComponent } from './productdetails/productdetails.component';
import { ProductComponent } from './product/product.component';

@NgModule({
  declarations: [ProductComponent, ProductDetailsComponent],
  providers:[],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: "",
        children: [
          {
            path: "productdetails",
            component: ProductDetailsComponent
          },
          {
            path: "product/:productId",
            component: ProductComponent
          }
        ]
      }
    ])
  ]
})
export class InventoryModule { }
