import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-pin-page',
  templateUrl: './pin-page.component.html',
  styleUrls: ['./pin-page.component.scss']
})
export class PinPageComponent {
  pinNumber: number = 0;
  errorMessageFlag: boolean = false;
  blockedCard: boolean = false;
  cardNumber: string = '';
  tries: number = 0;

  constructor(private api: ApiService) {
    this.cardNumber = localStorage.getItem('cardNumber') || '';
  };

  keyboardPress(joinedNumber: number): void {
    if (this.validatePinNumber()) {
      this.pinNumber = this.pinNumber * 10 + joinedNumber;
    }
  }

  validatePinNumber(): boolean {
    return this.pinNumber.toString().length < 4 ? true : false;
  }

  setErrorMessage(validTries: number){
    if(validTries === 0){
      this.blockedCard = true;
      this.errorMessageFlag = false;
    }
    else{
      this.errorMessageFlag = true;
      setTimeout(() => {
        this.errorMessageFlag = false;
      }, 3000);
    }
  }

  formatPinNumber(): string {
    const cardNumberString = this.pinNumber.toString();
    return cardNumberString.replace(/(\d{4})(?=\d)/g, '$1-');
  }

  cleanKeayboard(): void {
    this.pinNumber = 0;
  }

  sentPinNumber(): void {
    if (this.pinNumber.toString().length === 4 && this.pinNumber !== 0) {
      this.api.sentPinNumber(this.cardNumber, this.pinNumber).subscribe(
        (response) => {
          const valido = response.valido;
          const IntentosRestantes = response.restantes;
          
          if(valido && IntentosRestantes > 0){
            window.location.replace('/operaciones');
          }
          
          if(!valido && IntentosRestantes > 0 ){
            this.tries = IntentosRestantes;
            this.errorMessageFlag = true;
            this.setErrorMessage(this.tries);
          }
          if(IntentosRestantes === 0){
            this.blockedCard = true;
            this.errorMessageFlag = false;
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
