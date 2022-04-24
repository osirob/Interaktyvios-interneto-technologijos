import { Car } from './../../models/car.model';
import { CarsService } from './../../services/cars.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  loaded : boolean = false;
  cars: Car[] = [];

  constructor(private carService : CarsService) { }

  ngOnInit(): void {
    this.getAllCars();
  }

  getAllCars(){
    this.carService.getAllCars().subscribe(response => {
      this.cars = response;
      this.loaded = true;
    });
  }
}
