import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentComponent } from './agent.component';
import { MovementsComponent } from './components/movements/movements.component';

const routes: Routes = [
  {
    path: '',
    component: AgentComponent,
    children: [
      { path: '', component: MovementsComponent },
      { path: 'movements', component: MovementsComponent },
    ],
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentRoutingModule {}
