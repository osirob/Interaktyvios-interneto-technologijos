import { Observable } from 'rxjs';
import { UsersService } from './../../services/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  loggedIn : boolean
  constructor(private usersService : UsersService) { }

  ngOnInit(): void {
    this.checkLogin();
  }

  logout() : void {
    this.usersService.logout();
  }

  checkLogin() : void {
    this.usersService.loggedInCurrent.subscribe(x => this.loggedIn = x);
  }
}
