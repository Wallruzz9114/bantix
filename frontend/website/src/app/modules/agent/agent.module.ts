import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AgentRoutingModule } from './agent-routing.module';
import { AgentComponent } from './agent.component';
<<<<<<< HEAD
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [AgentComponent, MovementsComponent],
=======
import { AgentTransactionComponent } from './components/agent-transaction/agent-transaction.component';

@NgModule({
  declarations: [AgentComponent, AgentTransactionComponent],
>>>>>>> added-agent
  imports: [CommonModule, AgentRoutingModule],
  exports: [],
  providers: [],
})
export class AgentModule {}
