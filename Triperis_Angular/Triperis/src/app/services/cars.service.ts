import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarsService {
  baseUrl = 'https://localhost:7289/api/Cars'

  constructor(private http: HttpClient) { }

  //Get all cars
  getAllCars() : Observable<Car[]>{
    return this.http.get<Car[]>(this.baseUrl);
  }
}
