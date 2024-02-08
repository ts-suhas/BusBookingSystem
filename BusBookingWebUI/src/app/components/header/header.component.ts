import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from 'src/app/services/identity.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public currencies = ['USD', 'EUR']
  public languages = ['Eng', 'Fr']
  public selectedCurrency = 'USD';
  public selectedLang = 'Eng';

  constructor(private route: Router,
    private loginService: IdentityService) { }

  ngOnInit(): void {
  }

  goHome(){
    this.route.navigateByUrl('/')
  }
  public get identity() {
    return JSON.parse(localStorage.getItem('userData')!)
  }
  logout() {
    localStorage.removeItem('authenticatedByLoginToken')
    localStorage.removeItem('userData')
    this.route.navigateByUrl('/login')
    this.loginService.SignOut()
  }
}
