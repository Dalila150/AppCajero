import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PinPageComponent } from './components/pin-page/pin-page.component';
import { OperationsPageComponent } from './components/operations-page/operations-page.component';
import { BalancePageComponent } from './components/balance-page/balance-page.component';
import { WithdrawalPageComponent } from './components/withdrawal-page/withdrawal-page.component';
import { OperationsReportsPageComponent } from './components/operations-reports-page/operations-reports-page.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';
import { CanvaComponent } from './components/canva/canva.component';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PinPageComponent,
    OperationsPageComponent,
    BalancePageComponent,
    WithdrawalPageComponent,
    OperationsReportsPageComponent,
    ErrorPageComponent,
    CanvaComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
