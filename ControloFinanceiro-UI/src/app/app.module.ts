import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// registar serviços
import {TiposService} from '../app/services/tipos.service';
import {CategoriasService} from '../app/services/categorias.service';
import { ListagemCategoriasComponent } from './components/Categoria/listagem-categorias/listagem-categorias.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatButtonModule} from '@angular/material/button';

// API reference for Angular Material table -> para exibir os dados no HTML
import {MatTableModule} from '@angular/material/table';
import {MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    AppComponent,
    ListagemCategoriasComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule
  ],
  providers: [
    TiposService, CategoriasService, HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
