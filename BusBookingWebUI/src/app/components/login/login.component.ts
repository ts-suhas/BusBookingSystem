import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { IdentityService } from 'src/app/services/identity.service'
import CryptoJS from 'crypto-js';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email:string = ''
  password:string = ''
  invalidValidLoginAttempt = false

  constructor(private router: Router,
    private toastr: ToastrService,
    private spinnerService: NgxSpinnerService,
    private identityService: IdentityService) { }

  ngOnInit(): void {
  }

  signin() {
    
    let generated_signature = CryptoJS.SHA256(this.password).toString(CryptoJS.enc.Hex)
    let detail = {
      email: this.email,
      password: generated_signature
    }
    this.spinnerService.show()

    
    if(detail.email == 'admin@super'){
      this.identityService.adminLogin(detail).subscribe((response:any)=>{
        localStorage.setItem('userData',JSON.stringify(response))
        this.spinnerService.hide()
  
          this.router.navigateByUrl('/admin-page')
      } ,(error:any)=>{
        this.invalidValidLoginAttempt = true
        this.spinnerService.hide()
        this.toastr.error('Something went wrong', 'Contact Support')
      
      })

    }else{
      this.identityService.login(detail).subscribe((response:any)=>{
        localStorage.setItem('userData',JSON.stringify(response))
        this.spinnerService.hide()
  
          this.router.navigateByUrl('/')
      } ,(error:any)=>{
        this.invalidValidLoginAttempt = true
        this.spinnerService.hide()
        this.toastr.error('Something went wrong', 'Contact Support')
      
      })

    }

  }

}
