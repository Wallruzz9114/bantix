import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoardComponent } from './board.component';
import { MovementsComponent } from './components/movements/movements.component';

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
