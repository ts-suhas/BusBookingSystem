import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingManagmentService } from 'src/app/services/booking-managment.service';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.scss']
})
export class CreateBookingComponent implements OnInit {
  bus:any

  constructor(private activeRoute: ActivatedRoute,
    private bmService: BookingManagmentService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    let param = this.activeRoute.snapshot.paramMap.get('id');
    this.getBusDetail(param)
  }

  getBusDetail(id:any){
    this.bmService.getBusById(id).subscribe(res => {
      this.bus = res
    })
  }

  bookTicket(rId:any){
    var currentUser = JSON.parse(localStorage.getItem('userData') ?? "")
    if(!currentUser){
      return
    }
    let request = {
      rId: rId,
      pId: currentUser.paId,
      amount: 20,
      tNum: new Date().getSeconds()
    }

    this.bmService.createBooking(request).subscribe(res => {
      this.toastrService.success("successfully booked", "Congrates!!")
      this.router.navigate(['my-bookings'])
    }, err => {
      this.toastrService.success("failed to book ticket", "Sorry!!")

    })
  }

}
