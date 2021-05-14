import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BoardRoutingModule } from './components/board/board-routing.module';
import { BoardComponent } from './components/board/board.component';
import { MovementsComponent } from './components/movements/movements.component';

@NgModule({
  declarations: [BoardComponent, MovementsComponent],
  imports: [CommonModule, BoardRoutingModule],
})
export class BoardModule {}
