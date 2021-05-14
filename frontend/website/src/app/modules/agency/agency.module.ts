import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AgenciaRoutingModule } from './components/agency/agency-routing.module';
import { AgencyComponent } from './components/agency/agency.component';
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [AgencyComponent, MovementsComponent],
  imports: [CommonModule, AgenciaRoutingModule],
})
export class AgencyModule {}
