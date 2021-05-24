import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentComponent } from './agent.component';
import { AgentTransactionComponent } from './components/agent-transaction/agent-transaction.component';

const routes: Routes = [
  {
    path: '',
    component: AgentComponent,
    children: [
      { path: '', component: AgentTransactionComponent },
      { path: 'transaction', component: AgentTransactionComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgentRoutingModule {}
