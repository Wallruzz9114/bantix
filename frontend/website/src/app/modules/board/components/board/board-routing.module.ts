import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovementsComponent } from './../movements/movements.component';
import { BoardComponent } from './board.component';

const routes: Routes = [
  {
    path: '',
    component: BoardComponent,
    children: [
      { path: '', component: MovementsComponent },
      { path: 'movements', component: MovementsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BoardRoutingModule {}
