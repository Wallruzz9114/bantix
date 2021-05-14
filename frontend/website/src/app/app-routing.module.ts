import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgencyGuard } from './guards/agency.guard';
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
    path: 'agency',
    canActivateChild: [AgencyGuard],
    loadChildren: () => import('./modules/agency/agency.module').then((m) => m.AgencyModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
