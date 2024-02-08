import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private http: HttpClient) { }

  SignOut(){

  }

  login(detail:any){
    return this.http.post('https://localhost:44366/api/Users/userLogin',detail)
  }

  adminLogin(detail:any){
    return this.http.post('https://localhost:44366/api/Authentication/token',detail)
  }

  signup(detail:any){
    return this.http.post('https://localhost:44366/api/passenger',detail)
  }
}
