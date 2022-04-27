import { LoginUser } from './../models/loginUser.model';
import { RegisterUser } from './../models/registerUser.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = 'https://localhost:7289/api/AppUser'

  constructor(private http : HttpClient) { }

  registerUser(newUser: RegisterUser) : Observable<RegisterUser> {
    return this.http.post<RegisterUser>(this.baseUrl + '/Register', newUser);
  }

  //Returns error or JWT token
  login(user: LoginUser) : Observable<any>{
    return this.http.post<LoginUser>(this.baseUrl + '/Login', user);
  }
}
