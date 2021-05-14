import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BoardRoutingModule } from './board-routing.module';
import { BoardComponent } from './board.component';
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [BoardComponent, MovementsComponent],
  imports: [
    CommonModule,
    BoardRoutingModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
  ],
  exports: [],
  providers: [],
})
export class BoardModule {}
