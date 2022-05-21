import { CarCreateEdit } from './../models/carCreate.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  baseUrl = 'https://localhost:7289/api/Cars';

  constructor(private http: HttpClient) { }

  //Get all cars
  getAllCars() : Observable<Car[]>{
    return this.http.get<Car[]>(this.baseUrl);
  }

  getCar(id: number) : Observable<Car>{
    return this.http.get<Car>(this.baseUrl + `/${id}`);
  }

  postCar(car: CarCreateEdit) : Observable<Car>{
    return this.http.post<Car>(this.baseUrl, car);
  }
}
