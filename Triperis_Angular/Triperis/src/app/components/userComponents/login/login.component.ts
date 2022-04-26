import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastService } from 'src/app/services/toast.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formModel = {
    userName : '',
    password : ''
  }

  constructor(private fb: FormBuilder, private usersService: UsersService, private toast: ToastService) { }

  ngOnInit(): void {

  }


  login() : void {
    console.log(this.formModel);
  }

}
