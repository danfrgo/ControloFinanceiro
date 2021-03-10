import { CategoriasService } from './../../../services/categorias.service';
import { TiposService } from './../../../services/tipos.service';
import { Tipo } from './../../../models/Tipo';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-nova-categoria',
  templateUrl: './nova-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class NovaCategoriaComponent implements OnInit {

  formulario: any;
  tipos: Tipo[];

  constructor(
    private tiposService: TiposService,
    private categoriasService: CategoriasService,
    private router: Router,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    // carregar os dados da BD com os tipos a serem selecionados
    this.tiposService.ObterTodos().subscribe(resultado => {
      this.tipos = resultado;
      // console.log(resultado);
    });

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      icone: new FormControl(null),
      tipoId: new FormControl(null),
    });
  }
  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    const categoria = this.formulario.value;

    this.categoriasService.NovaCategoria(categoria).subscribe(resultado => {
      this.router.navigate(['categorias/listagemcategorias']);
      // mensagens/notificacoes atualizado/removido/editado
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
