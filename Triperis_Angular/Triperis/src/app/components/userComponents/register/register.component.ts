import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;

  constructor(private fb: FormBuilder) { 
    
  }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() : void{
    this.form = this.fb.group({
      userName: ['', [Validators.minLength(6), Validators.required]],
      email: ['', [Validators.email, Validators.required]],
      password: ['', [Validators.minLength(6), Validators.required]],
      confirmPassword: ['', [Validators.minLength(6), Validators.required]],
    }) as FormGroup;
  }

  addNewUser() : void{
    
  }
}
