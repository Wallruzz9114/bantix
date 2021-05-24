import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgentGuard } from './guards/agent.guard';
import { AuthenticationGuard } from './guards/authentication.guard';
import { UserGuard } from './guards/user.guard';

const routes: Routes = [
  {
    path: '',
    canActivateChild: [AuthenticationGuard],
    loadChildren: () =>
      import('./modules/authentication/authentication.module').then((m) => m.AuthenticationModule),
  },
  {
    path: 'board',
    canActivateChild: [UserGuard],
    loadChildren: () => import('./modules/board/board.module').then((m) => m.BoardModule),
  },
  {
    path: 'agent',
    canActivateChild: [AgentGuard],
    loadChildren: () => import('./modules/agent/agent.module').then((m) => m.AgentModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
