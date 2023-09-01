import { Component, Input } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-balance-page',
  templateUrl: './balance-page.component.html',
  styleUrls: ['./balance-page.component.scss']
})
export class BalancePageComponent {
  showReportBalance: boolean = false;
  balanceAccount: number = 0;
  cardNumber: number = 0;
  date: string = '';
  //cardNumber: number = 0;

  @Input() isDepositOperation: boolean = false;
  @Input() withdrawalNumber: number = 0;
  
  constructor(private api: ApiService) { 
    //llamar
    
    this.cardNumber = parseInt(localStorage.getItem('cardNumber') || '');
    const fechaActual = new Date();
    const fechaFormateada = fechaActual.toISOString().slice(0, 19);
    this.date = fechaFormateada;
    this.sentOperation();
  }

  toggleReportBalance(): void {
    this.showReportBalance = true;
  }

  sentOperation(): void {
    //hacer llamado api
    
      //llamar apí
      const fechaActual = new Date();
      const fechaFormateada = fechaActual.toISOString().slice(0, 19);
      this.api.InsertarOperacion(this.cardNumber, 1, fechaFormateada, null)
      .subscribe(
        (response) => {
          
          if (response!==null) {
            
            //mostrar los datos de response
            this.balanceAccount = response.saldoActual;
            //window.location.replace('/reporte');
            //this.showReportWithdrawal = true;
          }
        },
        (error) => {
          console.log(error);
          //this.errorMessageFlag = true;
          setTimeout(() => {
            //this.errorMessageFlag = false;
          }, 3000);
        }
      )
      //this.showReportWithdrawal = true;
    
  }
}
