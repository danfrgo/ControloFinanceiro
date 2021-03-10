import { CategoriasService } from './../../../services/categorias.service';
import { Component, OnInit } from '@angular/core';

// API reference for Angular Material table -> para exibir os dados no HTML
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { Inject } from '@angular/core';
import { MatDialog ,MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-listagem-categorias',
  templateUrl: './listagem-categorias.component.html',
  styleUrls: ['./listagem-categorias.component.css']
})
export class ListagemCategoriasComponent implements OnInit {

  categorias = new MatTableDataSource<any>(); // var para receber os dados
  displayedColumns: string[]; // exibir todas as colunas



  constructor(
    private categoriasService: CategoriasService,
    private dialog: MatDialog) {}

  ngOnInit(): void {

    this.categoriasService.ObterTodos().subscribe(resultado => {
      this.categorias.data = resultado;
    });
    this.displayedColumns = this.ExibirColunas();
  }

  ExibirColunas(): string[]{
    return ['nome', 'icone', 'tipo', 'acoes'];
  }

  AbrirDialog(categoriaId, nome): void {
    this.dialog.open(DialogRemoverCategoriasComponent, {
      data:{
        categoriaId: categoriaId,
        nome: nome,
      }
    }).afterClosed().subscribe(resultado => {
      if(resultado === true){
        this.categoriasService.ObterTodos().subscribe(dados => {
          this.categorias.data = dados;
        });
        this.displayedColumns = this.ExibirColunas();
      }
    });

  }

}


@Component({
  selector: 'app-dialog-remover-categorias',
  templateUrl: 'dialog-remover-categorias.html',
})

export class DialogRemoverCategoriasComponent{
  constructor( // MAT_DIALOG_DATA - permite enviar dados do component ListagemCategoriasComponent para o DialogRemoverCategoriasComponent
    @Inject(MAT_DIALOG_DATA) public dados: any,
    private categoriasService: CategoriasService) {}
      // funcao para remover
      RemoverCategoria(categoriaId): void {
        this.categoriasService.RemoverCategoria(categoriaId).subscribe(resultado => {

        });
      }
  }
