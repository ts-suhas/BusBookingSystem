import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getBookingsList(){
    return this.http.get('https://localhost:44366/api/Buses')
  }

  getDriversList(){
    return this.http.get('https://localhost:44366/api/Driver')
  }

  getPassengersList(){
    return this.http.get('https://localhost:44366/api/Passenger')
  }
}
