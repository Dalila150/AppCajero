import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-withdrawal-page',
  templateUrl: './withdrawal-page.component.html',
  styleUrls: ['./withdrawal-page.component.scss']
})
export class WithdrawalPageComponent {
  showReportWithdrawal: boolean = false;
  withdrawalNumber: number = 0;
  errorMessageFlag: boolean = false;
  cardNumber: number = 0;
  date: string = '';
  balance: number = 0;

  constructor(private api: ApiService) {
    this.cardNumber = parseInt(localStorage.getItem('cardNumber') || '');
   };

  keyboardPress(joinedNumber: number): void {
    if (this.validatePinNumber()) {
      
      this.withdrawalNumber = this.withdrawalNumber * 10 + joinedNumber;
    }
  }

  validatePinNumber(): boolean {
    return this.withdrawalNumber.toString().length < 7 ? true : false;
  }


  formatPinNumber(): string {
    const cardNumberString = this.withdrawalNumber.toString();
    return this.withdrawalNumber.toString();
  }

  cleanKeayboard(): void {
    this.withdrawalNumber = 0;
  }

  sentMoneyToWithdrawal(): void {
    
    if (this.withdrawalNumber.toString().length <= 7 && this.withdrawalNumber !== 0) {
      //llamar apí
      const fechaActual = new Date();
      const fechaFormateada = fechaActual.toISOString().slice(0, 19);
      this.api.InsertarOperacion(this.cardNumber, 2, fechaFormateada, this.withdrawalNumber)
      .subscribe(
        (response) => {
          this.date = fechaFormateada;
          this.balance = response.saldoActual;
          this.showReportWithdrawal = true;
        },
        (error) => {
          console.log(error);
          this.errorMessageFlag = true;
          setTimeout(() => {
            this.errorMessageFlag = false;
          }, 3000);
        }
      )
      //this.showReportWithdrawal = true;
    }
    else {
      this.errorMessageFlag = true;
      setTimeout(() => {
        this.errorMessageFlag = false;
      }, 3000);
    }
  }
}
