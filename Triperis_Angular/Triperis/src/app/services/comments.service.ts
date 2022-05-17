import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  baseUrl = 'https://localhost:7289/api/Comments';

  constructor(private http: HttpClient) { }

  getCommentsById(carId : number) : Observable<Comment[]>{
    return this.http.get<Comment[]>(this.baseUrl + `/${carId}`);
  }
}
