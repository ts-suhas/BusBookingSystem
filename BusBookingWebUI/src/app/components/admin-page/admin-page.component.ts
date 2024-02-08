import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/services/admin.service';
import { BookingManagmentService } from 'src/app/services/booking-managment.service';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {

  filterTermBuses:any
  filterTermDriver: any
  filterTermPassenger:any
  busForm! : FormGroup;
  selectedDriver = 0
  p = 1
  p2 = 1
  p3 = 1

  busList: any = []
  driverList: any = []
  passengerList: any = []

  DriversList: any = []

  constructor(
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private adminService: AdminService,
    private bkmService: BookingManagmentService,
    private homeService: HomeService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.busForm = this.fb.group({
      No_Plate: [null,[Validators.required]],
      color: [null,[Validators.required]],
      type: [null]

    })
    this.getAllBuses()
    this.getAllDrives()
    this.getAllPassengers()
  }

  

  getBusFormProperty(property:any){
    return this.busForm.get(property);
  }
  
  
  
  onChangeCat(event:any){
    this.selectedDriver = event.target.value
    alert(this.selectedDriver)
  }

  onSubmitBusForm(){
    if(this.busForm.valid){
      this.spinnerService.show()

      let request: any = this.busForm.value
      request.D_ID = this.selectedDriver == 0 ? 1 : this.selectedDriver


      console.log("service data ", request)
      this.adminService.addBus(request).subscribe((resp:any) => {
        this.toastrService.success("Added New Service", "Successfully!!")
        this.spinnerService.hide()
        this.getAllBuses()

      }, (err:any) => {
        this.toastrService.error("Something went wrong", "Failed!!")
        this.spinnerService.hide()

      })
    
    } else {
      Object.values(this.busForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });

    }
  }

  getAllBuses(){
    this.homeService.getBookingsList().subscribe(res => {
      this.busList = res
    })

  }
  getAllDrives(){
    this.homeService.getDriversList().subscribe(res => {
      this.driverList = res
    })

  }

  getAllPassengers(){
    this.homeService.getPassengersList().subscribe(resp => {
      this.passengerList = resp
    })
  }

}
