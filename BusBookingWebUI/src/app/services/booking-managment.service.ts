import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookingManagmentService {

  constructor(private http: HttpClient) { }

  deleteBookingById(data:any){
    return this.http.get('')
  }
  createBooking(data:any){
    return this.http.post('https://localhost:44366/api/Buses/bookticket',data)
  }
  getRoomsList(){
    return this.http.get('')
  }
  geAllBookings(pId:any){
    return this.http.get('https://localhost:44366/api/Buses/tickets/'+pId)
  }
  getUserBookings(data:any){
    return this.http.get('')
  }

  getBusById(id:any){
    return this.http.get('https://localhost:44366/api/Buses/'+id)
  }
}
