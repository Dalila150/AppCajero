import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  cardNumber: number = 0;
  errorMessageFlag: boolean = false;

  constructor(private api: ApiService) { };

  keyboardPress(joinedNumber: number): void {
    if (this.validateCardNumber()) {
      this.cardNumber = this.cardNumber * 10 + joinedNumber;
      this.formatCardNumber();
    }
  }

  validateCardNumber(): boolean {
    return this.cardNumber.toString().length < 16 ? true : false;
  }

  formatCardNumber(): string {
    const cardNumberString = this.cardNumber.toString();
    return cardNumberString.replace(/(\d{4})(?=\d)/g, '$1-');
  }

  cleanKeayboard(): void {
    this.cardNumber = 0;
  }

  sentCardNumber(): void {
    if (this.cardNumber.toString().length === 16 && this.cardNumber !== 0) {
      this.api.sentCardNumber(this.cardNumber).subscribe(
        (response) => {
          const valido = response.valido;
          
          if (valido) {
            localStorage.setItem('cardNumber', this.cardNumber.toString());
            window.location.replace('/pin');
          }
        },
        (error) => {
          console.log(error);
          this.errorMessageFlag = true;
          setTimeout(() => {
            this.errorMessageFlag = false;
          }, 3000);
        }
      );
    }
    else {
      this.errorMessageFlag = true;
      setTimeout(() => {
        this.errorMessageFlag = false;
      }, 3000);
    }
  }

}
