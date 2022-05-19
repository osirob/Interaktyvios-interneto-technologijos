import { BrandsService } from './../../services/brands.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car.model';

@Component({
  selector: 'app-car-form',
  templateUrl: './car-form.component.html',
  styleUrls: ['./car-form.component.css']
})
export class CarFormComponent implements OnInit {

  @Input() title: string;
  public form: FormGroup;
  public carsInfo : any;
  public models : any;

  constructor(
    private fb: FormBuilder,
    private brandsService: BrandsService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.getCarsInfo();
  }

  getCarsInfo(): void{
    this.carsInfo = this.brandsService.getInfo();
  }

  initializeForm() : void{
    this.form = this.fb.group({
      marke: ['', [Validators.required]],
      modelis: new FormControl({value: '', disabled: true})
    }) as FormGroup;
  }

  onChange($event) : void{
    if(this.form.controls.marke.value){
      this.models = this.getModelList(this.form.controls.marke.value);
      this.form.controls.modelis.enable();
    }
  }

  getModelList(brandParam: string){
    for(var i of this.carsInfo){
      if(i.brand === brandParam){
        return i.models;
      }
    }
  }
}
