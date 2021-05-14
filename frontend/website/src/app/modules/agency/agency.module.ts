import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AgencyRoutingModule } from './agency-routing.module';
import { AgencyComponent } from './agency.component';
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [AgencyComponent, MovementsComponent],
  imports: [CommonModule, AgencyRoutingModule],
  exports: [],
  providers: [],
})
export class AgencyModule {}
