import { UserDetails } from 'src/app/models/userDetails.model';
import { Observable } from 'rxjs';
import { UsersService } from './../../services/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  loggedIn : boolean;
  role: string;
  user: UserDetails;
  constructor(private usersService : UsersService) { }

  ngOnInit(): void {
    this.checkLogin();
    this.role = this.usersService.getRole();
    this.getDetails();
  }

  logout() : void {
    this.usersService.logout();
  }

  checkLogin() : void {
    this.usersService.loggedInCurrent.subscribe(x => this.loggedIn = x);
  }

  getDetails():void {
    this.usersService.getUserProfile().subscribe(details => {
      this.user = details;
    });
  }
}
