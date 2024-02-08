import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BusBookingWebUI';
  showHeaderFooter = true

  constructor(private router: Router){

  }

  ngOnInit(): void {
    this.router.events.pipe(
      filter((event:any) => event instanceof NavigationEnd)
    ).subscribe((event: any) => {
   if(event.url =='/register' || event.url == '/login' ) {
        this.showHeaderFooter = false
      }else {
        this.showHeaderFooter = true
        }
      }
    );


    }
}
