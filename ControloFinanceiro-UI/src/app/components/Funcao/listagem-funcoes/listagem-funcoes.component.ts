import { FuncoesService } from './../../../services/funcoes.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-listagem-funcoes',
  templateUrl: './listagem-funcoes.component.html',
  styleUrls: ['./listagem-funcoes.component.css']
})
export class ListagemFuncoesComponent implements OnInit {


  funcoes = new MatTableDataSource<any>(); // var que ira ter as funcoes
  displayedColumns: string[]; // lista de strings com as colunas a serem exibidas


  @ViewChild(MatPaginator, { static: true }) // paginacao
  paginator: MatPaginator;

  @ViewChild(MatSort, { static: true }) // ordenacao de pagina
  sort: MatSort;


  constructor(private funcoesService: FuncoesService) { }

  ngOnInit(): void {
    this.funcoesService.ObterTodos().subscribe(resultado => {
      this.funcoes.data = resultado;
      this.funcoes.sort = this.sort;
      this.funcoes.paginator = this.paginator;
    });

    this.displayedColumns = this.ExibirColunas();

  }


  ExibirColunas(): string[] {
    return ['nome', 'descricao', 'acoes'];
  }

}
