import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from '../models/Categoria';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  url = 'api/Categorias';

  constructor(private http: HttpClient) { }

  ObterTodos(): Observable<Categoria[]>{
    return this.http.get<Categoria[]>(this.url);
  }

  ObterCategoriaPeloId(categoriaId: number): Observable<Categoria>
  {
    // api/categorias/5
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.get<Categoria>(apiUrl);
  }

  NovaCategoria(categoria: Categoria): Observable<any>
  {
    return this.http.post<Categoria>(this.url, categoria, httpOptions);
  }

  AtualizaCategoria(categoriaId: number, categoria: Categoria): Observable<any>
  {
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.put<Categoria>(apiUrl, categoria, httpOptions);
  }

  RemoverCategoria(categoriaId: number): Observable<any>
  {
    const apiUrl = `${this.url}/${categoriaId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }





}
