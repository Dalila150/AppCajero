import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PinPageComponent } from './components/pin-page/pin-page.component';
import { BalancePageComponent } from './components/balance-page/balance-page.component';
import { OperationsPageComponent } from './components/operations-page/operations-page.component';
import { WithdrawalPageComponent } from './components/withdrawal-page/withdrawal-page.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { CanvaComponent } from './components/canva/canva.component';
import { OperationsReportsPageComponent } from './components/operations-reports-page/operations-reports-page.component';

const routes: Routes = [
  { path: '', component: CanvaComponent, pathMatch: 'full'},
  { path: 'home', component: HomeComponent},
  { path: 'pin', component: PinPageComponent},
  { path: 'operaciones', component: OperationsPageComponent},
  { path: 'balance', component: BalancePageComponent},
  { path: 'retirar', component: WithdrawalPageComponent},
  { path: 'reporte', component: OperationsReportsPageComponent},
  { path: 'error', component: ErrorPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
