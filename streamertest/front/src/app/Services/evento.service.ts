import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Evento } from '../Models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {
  
  baseURL = 'http://localhost:5000/api/project';

  constructor(private http: HttpClient) { 
    
  }
  

  putEvento(evento: Evento): Observable<Evento> {
    return this.http.put<Evento>(this.baseURL + '/put', evento);
  }

  postEvento(evento: Evento): Observable<Evento> {
    return this.http.post<Evento>(this.baseURL + '/post', evento);
  }
  
  getAllEvento(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }
  
  deleteEvento(id: number): Observable<{}> {
    const url = `${this.baseURL}/${id}`;
    return this.http.delete(url);
  }

  getEventoById(id: number) {
    return this.http.get<Evento>(this.baseURL + "/" + id);
  }

  getByCourseId(id: number) {
    return this.http.get<Evento[]>(this.baseURL + '/CourseId?CourseId=' + id);
  }
}
