import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AgentRoutingModule } from './agent-routing.module';
import { AgentComponent } from './agent.component';
import { AgentTransactionComponent } from './components/agent-transaction/agent-transaction.component';

@NgModule({
  declarations: [AgentComponent, AgentTransactionComponent],
  imports: [CommonModule, AgentRoutingModule],
  exports: [],
  providers: [],
})
export class AgentModule {}
