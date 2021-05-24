import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoardComponent } from './board.component';
import { BoardTransactionComponent } from './components/board-transaction/board-transaction.component';

const routes: Routes = [
  {
    path: '',
    component: BoardComponent,
    children: [
      { path: '', component: BoardTransactionComponent },
      { path: 'transactions', component: BoardTransactionComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BoardRoutingModule {}
