import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';
import { IdentityService } from 'src/app/services/identity.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  username:string = ''
  name:string = ''
  gender:string = ''
  cardType:number = 0
  email:string = ''
  mobileNo:string = ''
  password:string = ''
  isFormValid = false
  defaultCheck1 = false
  isMember = false

  loginForm!: FormGroup;
  constructor(private router: Router,
    private toastr: ToastrService,
    private identityService: IdentityService,
    private spinnerService: NgxSpinnerService,) { }

  ngOnInit(): void {
  }

  get isFormValidd(){
    if(this.name.length > 0 && this.gender.length > 0 && this.email.length > 0 && this.password.length > 0){
      this.isFormValid = true;
    }else{
      this.isFormValid = false
    }
    return this.isFormValid
  }

  onChangeGender(event:any){
    this.gender = event.target.value
  }

  onChangeCardType(event:any){
    this.cardType = event.target.value
  }

  get doShowCardTypeSelect(){
    return this.isMember === true
  }


  signup() {
    let detail = {
      name: this.name,
      gender: this.gender,
      password: this.password,
      passengerEmail:{
        emails: this.email
      },
      cid: this.cardType,
      isMember: this.isMember

    }
    this.spinnerService.show()
    this.identityService.signup(detail).subscribe((response:any)=>{
      this.spinnerService.hide()
      console.log(response)
      localStorage.setItem('userData',JSON.stringify(response))
      this.router.navigate([''])

    },(error:any)=> {
      this.spinnerService.hide()
      if (error instanceof HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
          this.toastr.error("Error Event");
        } else {
            console.log(`error status : ${error.status} ${error.statusText}`);
            switch (error.status) {
                case 404:     //forbidden
                this.toastr.error('404', 'Failed');
                    break;
                case 500:     //forbidden
                this.toastr.error(error.error.detail, 'Failed');
                    break;
                case 0:     //forbidden
                this.toastr.error('Server Connection Error', 'Registration Failed');
                    break;
            }
        }
    } else {
      this.spinnerService.hide()
      this.toastr.error('Something went wrong', 'Contact Support')
    }
    })

  }
  public  jwtHelper = new JwtHelperService();

  public decodeToken(): any {
    const token = JSON.parse(localStorage.getItem('authenticatedByLoginToken') || "")
    if (!token) {
      return {}
    }
    let decodedToken = this.jwtHelper.decodeToken(token)
    return decodedToken
   }

}
