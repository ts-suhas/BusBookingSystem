import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  BussList: any[] = []

  displayBussList: any[] = [{title: "Youtung Buses"},
      {title: "Acronous Luxury Bus", imageUrl: "assets/bus2.jfif"},
      {title: "Nastey One Buses"},
      {title: "Broujan Tours", imageUrl: "assets/bus2.jfif"},
    ]

  constructor(private homeService: HomeService,
    private router: Router) { }

  ngOnInit(): void {
    this.getBussList()
  }

  getBussList(){
    return this.homeService.getBookingsList().subscribe((resp:any) => {

      resp.forEach((element:any) => {
        this.BussList.push(element)
      });

      this.displayBussList = this.BussList
      console.log("Buss respnse", this.BussList)
    })
  }

  goToCreateBooking(BusId:any){
    let isLoggedIn = localStorage.getItem('userData')
    if(!isLoggedIn){
      this.router.navigate(['login'])
      return
    }
    this.router.navigate(['create-booking/'+BusId])
  }

  search(selectedDate:any){
    console.log("selected date ", selectedDate)
    if(!selectedDate){
      this.displayBussList = this.BussList
      return

    }

    this.homeService.getBookingsList().subscribe((resp:any) => {
      let bookings: any[] = []
      resp.forEach((element:any) => {
        bookings.push(element.data())
      });
      console.log("bookings ", bookings)
      let ids = [...new Set(bookings.filter(b => b.fromDate >= selectedDate || b.toDate <= selectedDate).map(x => x.BusId))]
      console.log("ids ", ids)
      this.displayBussList = this.BussList.filter(r => ids.includes(r.BusId))

    })

  }

}
