import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthenticationComponent } from './authentication.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [AuthenticationComponent, RegisterComponent],
  imports: [CommonModule, AuthenticationRoutingModule],
  exports: [],
  providers: [],
})
export class AuthenticationModule {}
