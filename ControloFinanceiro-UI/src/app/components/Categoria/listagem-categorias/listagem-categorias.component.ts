import { CategoriasService } from './../../../services/categorias.service';
import { Component, OnInit } from '@angular/core';

// API reference for Angular Material table -> para exibir os dados no HTML
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  // var para receber os dados
  categorias = new MatTableDataSource<any>();

  // exibir todas as colunas
  displayColumns: string[];

  constructor(private categoriasService: CategoriasService) { }

  ngOnInit(): void {

    this.categoriasService.ObterTodos().subscribe(resultado => {
      this.categorias.data = resultado;
    });
    this.displayColumns = this.ExibirColunas();
  }

  ExibirColunas(): string[]{
    return ['nome', 'icone', 'tipo', 'acoes'];
  }

}
