import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-operations-reports-page',
  templateUrl: './operations-reports-page.component.html',
  styleUrls: ['./operations-reports-page.component.scss']
})
export class OperationsReportsPageComponent {
  @Input() isBalanceOperation: boolean = true;
  @Input() cardNumber: number = 0;
  @Input() date: string = '';
  @Input() balance: number = 0;

  @Input() isDepositOperation: boolean = false;
  @Input() withdrawalNumber: number = 0;

  constructor() { 
    this.cardNumber = parseInt(localStorage.getItem('cardNumber') || '');
    const fechaActual = new Date();
    const fechaFormateada = fechaActual.toLocaleDateString().slice(0, 19).replace("T", " ");
    this.date = fechaFormateada;
  }

  formatcardNumber(): string {
    const cardNumberString = this.cardNumber.toString();
    return cardNumberString.replace(/(\d{4})(?=\d)/g, '$1-');
  }
}
