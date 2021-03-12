import { startWith, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
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
  autoCompleteInput = new FormControl();
  opcoesFuncoes: string[] = []; // array com os nomes das funcoes
  nomesFuncoes: Observable<string[]>; // lista de funcoes

  @ViewChild(MatPaginator, { static: true }) // paginacao
  paginator: MatPaginator;

  @ViewChild(MatSort, { static: true }) // ordenacao de pagina
  sort: MatSort;


  constructor(private funcoesService: FuncoesService) { }

  ngOnInit(): void {
    this.funcoesService.ObterTodos().subscribe((resultado) => {
      resultado.forEach(funcao => {
        this.opcoesFuncoes.push(funcao.name);
      });


      this.funcoes.data = resultado;
      this.funcoes.paginator = this.paginator;
      this.funcoes.sort = this.sort;
    });

    this.displayedColumns = this.ExibirColunas();
    this.nomesFuncoes = this.autoCompleteInput.valueChanges.pipe(startWith(''), map(nome => this.FiltrarNomes(nome))); // autoCompleteInput inicia com string vazia
  }


  ExibirColunas(): string[] {
    return ['nome', 'descricao', 'acoes'];
  }

  FiltrarNomes(nome: string): string[] {
    if (nome.trim().length >= 4) {
      this.funcoesService.FiltrarFuncoes(nome.toLowerCase()).subscribe(resultado => {
        this.funcoes.data = resultado;
      });
    }
    else {
      if (nome === '') {
        this.funcoesService.ObterTodos().subscribe(resultado => {
          this.funcoes.data = resultado;
        });
      }
    }
    return this.opcoesFuncoes.filter(funcao => funcao.toLowerCase().includes(nome.toLowerCase()));
  }

}
