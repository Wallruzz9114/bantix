import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgentGuard } from './guards/agent.guard';
import { AuthenticationGuard } from './guards/authentication.guard';
import { UserGuard } from './guards/user.guard';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule],
  providers: [
    { provide: LOCALE_ID, useValue: 'en-US' },
    AuthenticationGuard,
    AgentGuard,
    UserGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
