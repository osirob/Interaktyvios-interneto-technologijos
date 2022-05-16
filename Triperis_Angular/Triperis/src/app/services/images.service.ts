import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImagesService {
  private baseUrl = 'https://localhost:7289/api/Images'

  constructor(private http: HttpClient) { }

  uploadImage(formdata : FormData, carId : number) : Observable<any> {
    return this.http.post(this.baseUrl + '/Upload' + `/${carId}`, formdata, {reportProgress: true, observe: 'events'});
  }
}