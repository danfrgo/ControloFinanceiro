import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// registar componentes
import { ListagemCategoriasComponent } from './components/Categoria/listagem-categorias/listagem-categorias.component';
import { AtualizarCategoriaComponent } from './components/Categoria/atualizar-categoria/atualizar-categoria.component';
import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';

// registar rotas/componentes
const routes: Routes = [
  {
    path: 'categorias/listagemcategorias', component: ListagemCategoriasComponent

  },
  {
    path: 'categorias/novacategoria', component: NovaCategoriaComponent
  },
  {
    path: 'categorias/atualizarcategoria/:id', component: AtualizarCategoriaComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
