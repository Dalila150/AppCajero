import { Injectable, Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders, HttpInterceptor } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { Operacion } from '../Modelos/operacion.modelo';

@Injectable({
    providedIn: 'root'
})

export class ApiService {
    //apiURL: string = 'https://3d44-190-247-63-245.ngrok.io/';
    apiURL: string = 'http://localhost:5151/';

    constructor(private httpClient: HttpClient) { }

    sentCardNumber(cardNumber: number): Observable<any> {
        const cardNumberStr = cardNumber.toString();
        return this.httpClient.post<any>(this.apiURL + 'api/Tarjeta/ValidarNumeroTarjeta',
        {
            "numeroTarjeta": cardNumberStr
        })
    }

    sentPinNumber(cardNumber: string, pinNumber: number): Observable<any> {
        
        const pinNumberStr = pinNumber.toString();
        const cardNumberStr = cardNumber.toString();
        return this.httpClient.post<any>(this.apiURL + 'api/Tarjeta/ValidarPinTarjeta',
            {
                "numeroTarjeta": cardNumberStr,
                "pin": pinNumberStr
            },
            { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    }

    

    InsertarOperacion(cardNumber: number, idOperation: number, Time: string, Amount: number | null): Observable<any> {
        
        return this.httpClient.post<any>(this.apiURL + 'api/Operacion/InsertarOperacion',
            {
                //operacion
                "IdTarjeta": cardNumber,
                "IdTipo": idOperation,
                "Hora": Time,
                "Monto": Amount
            },
            { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) });
    }
}