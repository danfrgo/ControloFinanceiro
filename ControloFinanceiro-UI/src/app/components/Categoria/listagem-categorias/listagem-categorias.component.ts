import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { CategoriasService } from './../../../services/categorias.service';
import { Component, OnInit, ViewChild } from '@angular/core';

// API reference for Angular Material table -> para exibir os dados no HTML
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Inject } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { startWith, map } from 'rxjs/operators';
import { MatPaginator} from '@angular/material/paginator';
import { MatSort} from '@angular/material/sort';
import { MatSnackBar} from '@angular/material/snack-bar';
import { validateHorizontalPosition } from '@angular/cdk/overlay';


@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>(); // var para receber os dados
  displayedColumns: string[]; // exibir todas as colunas
  autoCompleteInput = new FormControl();
  opcoesCategorias: string[] = []; // array com os nomes das categorias
  nomesCategorias: Observable<string[]>; // lista de categorias

 // para injetar paginacao no html
  @ViewChild(MatPaginator, {static: true})
  paginator: MatPaginator;

  // ordenação no html
  @ViewChild(MatSort, {static: true})
  sort: MatSort;

  constructor(
    private categoriasService: CategoriasService,
    private dialog: MatDialog) { }

  ngOnInit(): void {

    // tslint:disable-next-line: deprecation
    this.categoriasService.ObterTodos().subscribe((resultado) => {
      resultado.forEach((categoria) => {
        // push -> para add dados numa lista
        this.opcoesCategorias.push(categoria.nome);
      });

      this.categorias.data = resultado;
      this.categorias.paginator = this.paginator;
      this.categorias.sort = this.sort;
    });

    this.displayedColumns = this.ExibirColunas();

    // preencher os valores de nomesCategorias
    // pipe -> funcao para transformacao de dados
    this.nomesCategorias = this.autoCompleteInput.valueChanges.pipe(
      startWith(''),
      map((nome) => this.FiltrarNomes(nome)));
  }


  ExibirColunas(): string[] {
    return ['nome', 'icone', 'tipo', 'acoes'];
  }

  AbrirDialog(categoriaId, nome): void {
    this.dialog.open(DialogRemoverCategoriasComponent, {
      data: {
        categoriaId: categoriaId,
        nome: nome,
      }
    // tslint:disable-next-line: deprecation
    }).afterClosed().subscribe(resultado => {
      if (resultado === true) {
        // tslint:disable-next-line: deprecation
        this.categoriasService.ObterTodos().subscribe(dados => {
          this.categorias.data = dados;
        });
        this.displayedColumns = this.ExibirColunas();
      }
    });

  }

  FiltrarNomes(nome: string): string[] {
    if (nome.trim().length >= 4) {
      this.categoriasService.FiltrarCategorias(nome.toLowerCase()).subscribe(resultado => {
        this.categorias.data = resultado;
      });
    } else {
      if (nome === '') {
        this.categoriasService.ObterTodos().subscribe(resultado => {
          this.categorias.data = resultado;
        });
      }
    }
    return this.opcoesCategorias.filter(categoria =>
      // comparar os valores de opcoesCategorias atraves de categoria e comparar com nome
      categoria.toLowerCase().includes(nome.toLowerCase())
    );


  }

}


@Component({
  selector: 'app-dialog-remover-categorias',
  templateUrl: 'dialog-remover-categorias.html',
})

export class DialogRemoverCategoriasComponent {
  constructor( // MAT_DIALOG_DATA - permite enviar dados do component ListagemCategoriasComponent para o DialogRemoverCategoriasComponent
    @Inject(MAT_DIALOG_DATA) public dados: any,
    private categoriasService: CategoriasService,
    private snackBar : MatSnackBar) { }
  // funcao para remover
  RemoverCategoria(categoriaId): void {
    // tslint:disable-next-line: deprecation
    this.categoriasService.RemoverCategoria(categoriaId).subscribe(resultado => {
      // mensagens de atualizacao, remover
      this.snackBar.open(resultado.mensagem, null,{
        duration: 2000,
        horizontalPosition: 'right',
        verticalPosition: 'top'
      });

    });
  }
}
