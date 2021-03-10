
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import { FormsModule } from '@angular/forms';

// registar serviços
import {TiposService} from '../app/services/tipos.service';
import {CategoriasService} from '../app/services/categorias.service';

// components
import { ListagemCategoriasComponent } from './components/Categoria/listagem-categorias/listagem-categorias.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';
import { AtualizarCategoriaComponent } from './components/Categoria/atualizar-categoria/atualizar-categoria.component';
import { DialogRemoverCategoriasComponent } from './components/Categoria/listagem-categorias/listagem-categorias.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// API reference for Angular Material table -> para exibir os dados no HTML
import {MatTableModule} from '@angular/material/table';
import {MatIconModule } from '@angular/material/icon';

import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatSelectModule} from '@angular/material/select';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDialogModule} from '@angular/material/dialog';


import {MatAutocompleteModule} from '@angular/material/autocomplete'; 





@NgModule({
  declarations: [
    AppComponent,
    ListagemCategoriasComponent,
    NovaCategoriaComponent,
    AtualizarCategoriaComponent,
    DialogRemoverCategoriasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatSelectModule,
    MatGridListModule,
    MatDialogModule,
    FormsModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
  ],
  providers: [
    TiposService, CategoriasService, HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
