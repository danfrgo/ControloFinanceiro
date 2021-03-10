import { FormGroup, FormControl } from '@angular/forms';
import { CategoriasService } from './../../../services/categorias.service';
import { TiposService } from './../../../services/tipos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Tipo } from 'src/app/models/Tipo';
import { MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-atualizar-categoria',
  templateUrl: './atualizar-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class AtualizarCategoriaComponent implements OnInit {

nomeCategoria: string; // var utilizada para mostrar o nome da categoria no formulario
categoriaId: number; // obter id da rota
categoria: Observable<Categoria> // var para receber a categoria
tipos: Tipo[];
formulario: any;



  constructor(
    private router: Router, 
    private route: ActivatedRoute, // ActivatedRoute -> obter id da rota
    private tiposService: TiposService, 
    private categoriasService: CategoriasService,
    private snackBar: MatSnackBar){ }



  ngOnInit(): void {

    // para obter id da rota
    this.categoriaId = this.route.snapshot.params.id;
    this.tiposService.ObterTodos().subscribe(resultado => {
      this.tipos = resultado;
    });

    // obter os dados da categoria para depois atualizar
    this.categoriasService.ObterCategoriaPeloId(this.categoriaId).subscribe(resultado => {
      this.nomeCategoria = resultado.nome;
      this.formulario = new FormGroup({
        categoriaId: new FormControl(resultado.categoriaId),
        nome: new FormControl(resultado.nome),
        icone: new FormControl(resultado.icone),
        tipoId: new FormControl(resultado.tipoId)
      });
    });

  }

      // funcao para ajudar a trabalhar com o formulario
    get propriedade(){
      return this.formulario.controls;
    }

    // enviar formulario (htmml)
    EnviarFormulario(): void{
      // var para obter os valores do atributo
      const categoria = this.formulario.value;
      // passar o id da categoria e a propria categoria
      this.categoriasService.AtualizarCategoria(this.categoriaId, categoria).subscribe(resultado => {
        this.router.navigate(['categorias/listagemcategorias']);
        this.snackBar.open(resultado.mensagem, null,{
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top'
        });
      });
    }

    // funcao utilizada no formulario para retroceder de pagina
    VoltarListagem() : void{
      this.router.navigate(['categorias/listagemcategorias']);
    }


}
