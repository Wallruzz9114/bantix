import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AgentRoutingModule } from './agent-routing.module';
import { AgentComponent } from './agent.component';
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [AgentComponent, MovementsComponent],
  imports: [CommonModule, AgentRoutingModule],
  exports: [],
  providers: [],
})
export class AgentModule {}
