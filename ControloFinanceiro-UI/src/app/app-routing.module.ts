import { NovaCategoriaComponent } from './components/Categoria/nova-categoria/nova-categoria.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// registar componentes
import { ListagemCategoriasComponent } from './components/Categoria/listagem-categorias/listagem-categorias.component';

// registar rotas/componentes
const routes: Routes = [
  {
    path: 'categorias/listagemcategorias', component: ListagemCategoriasComponent

  },
  {
    path: 'categorias/novacategoria', component: NovaCategoriaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
