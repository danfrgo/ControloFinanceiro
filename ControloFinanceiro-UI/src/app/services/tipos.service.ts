import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tipo } from '../models/Tipo';

@Injectable({
  providedIn: 'root'
})
export class TiposService {

  // url API
url: string = 'api/Tipos';

  constructor(private http: HttpClient) { }

  // Observable -> colecao de itens
  ObterTodos(): Observable<Tipo[]>{
    return this.http.get<Tipo[]>(this.url);
  }
}
