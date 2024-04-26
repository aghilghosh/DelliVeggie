import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'inventory',
    loadChildren: () => import('../app/modules/inventory/inventory.module').then(m => m.InventoryModule)
  },
  {
    path: '**',
    redirectTo: '/',
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
