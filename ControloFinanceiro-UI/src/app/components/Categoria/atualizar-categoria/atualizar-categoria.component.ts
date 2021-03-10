import { FormGroup, FormControl } from '@angular/forms';
import { CategoriasService } from './../../../services/categorias.service';
import { TiposService } from './../../../services/tipos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/Categoria';
import { Tipo } from 'src/app/models/Tipo';

@Component({
  selector: 'app-atualizar-categoria',
  templateUrl: './atualizar-categoria.component.html',
  styleUrls: ['../listagem-categorias/listagem-categorias.component.css']
})
export class AtualizarCategoriaComponent implements OnInit {

// var para receber a categoria
categoria: Observable<Categoria>
tipos: Tipo[];
formulario: any;



  constructor
  (
    private router: Router, 
    private route: ActivatedRoute, // ActivatedRoute -> obter id da rota
    private tiposService: TiposService, 
    private categoriasService: CategoriasService){ }



  ngOnInit(): void {

    // obter id da rota
    const categoriaId = this.route.snapshot.params.id;
    this.tiposService.ObterTodos().subscribe(resultado => {
      this.tipos = resultado;
    });

    // obter os dados da categoria para depois atualizar
    this.categoriasService.ObterCategoriaPeloId(categoriaId).subscribe(resultado => {
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


}
