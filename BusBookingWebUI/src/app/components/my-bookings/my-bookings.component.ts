import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BookingManagmentService } from 'src/app/services/booking-managment.service';

@Component({
  selector: 'app-my-bookings',
  templateUrl: './my-bookings.component.html',
  styleUrls: ['./my-bookings.component.scss']
})
export class MyBookingsComponent implements OnInit {


  dtOptions: any = {};

  tableData: any[] = [
    {busTitle:'Monac Tours', from:"Dubai", to:"Sharjah", departureDateTime:"20-11-2022 Tue 20:30PM", status:"reserved"},  
    {busTitle:'Emirates Line', from:"Marina", to:"JLT", departureDateTime:"08-11-2022 Tue 20:30PM", status:"completed"}
  
  ]

  bookingList: any[] = []

  roomsList: any[] = []

  currentUser: any
  updateBookingData = {
    bookingId: "0",
    roomId: "0",
    userId: null,
    fromDate: null,
    toDate: null
  }


  constructor(private roomManagmentService: BookingManagmentService,
    private toastr: ToastrService,) {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 12,
      processing: true
    };

  }

  ngOnInit(): void {
    // this.getUserBookings()
    this.getRoomsList()
    this.currentUser = JSON.parse(localStorage.getItem("userData") ?? "")
    this.getAllBookings()
  }
  

  getUserBookings(){
    let userId = JSON.parse(localStorage.getItem("userData") ?? "")
    this.roomManagmentService.getUserBookings(userId).subscribe((resp:any) => {
      console.log("user bookings ", resp)
    }, (err:any) => {
      console.log("erro bookings", err)
    })
  }

  getAllBookings(){
    var currentUser = JSON.parse(localStorage.getItem('userData') ?? "")
    this.roomManagmentService.geAllBookings(currentUser.paId).subscribe((resp:any) => {

      this.tableData = resp
      console.log("bookngs List ", this.tableData)
    })
  }

  getRoomsList(){
    return this.roomManagmentService.getRoomsList().subscribe((resp:any) => {

      resp.forEach((element:any) => {
        this.roomsList.push(element.data())
      });
      this.tableData = this.roomsList
    })
  }

  getRoomTitleById(roomId:any){
    return this.roomsList.find(r => r.roomId == roomId)?.title ?? "Room deleted"
  }

  getRoomImageById(roomId:any){
    return this.roomsList.find(r => r.roomId == roomId)?.imageUrl ?? "/assets/roomB.webp"
  }

  openBookingUpdateModal(){

  }

  openEditBookingModal(data:any){
    Object.assign(this.updateBookingData, data)
  }

  closeEditBookingModal(){
    this.updateBookingData = {
      bookingId: "0",
      roomId: "0",
      userId: null,
      fromDate: null,
      toDate: null
    }
  }

  updateBooking(){
    let data = {
      bookingId: this.updateBookingData.bookingId,
      roomId: this.updateBookingData.roomId,
      userId: this.currentUser.email,
      fromDate: this.updateBookingData.fromDate,
      toDate: this.updateBookingData.toDate
    }

    this.roomManagmentService.createBooking(data).subscribe((resp:any) => {
      console.log("resp booking ", resp)
      this.tableData.splice(this.tableData.findIndex(x => x.roomId == this.updateBookingData.roomId),1)
      this.tableData.push(this.updateBookingData)
      this.updateBookingData = {bookingId: "0", roomId: "0", userId: null, fromDate: null, toDate: null}
      this.toastr.success("updated booking","Successfully")
    }, (err:any) =>{
      console.log("error booking ", err)
    })

  }

  deleteBooking(data:any){
    this.roomManagmentService.deleteBookingById(data).subscribe((resp:any) => {
      this.tableData.splice(this.tableData.findIndex(x => x.roomId == data.bookingId),1)
      alert("Successfully Deleted Room")
    },(err:any) => {
      alert("Failed to Delete Room")

    })
  }

}
