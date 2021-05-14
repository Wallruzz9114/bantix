import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgencyGuard } from './guards/agency.guard';
import { AuthenticationGuard } from './guards/authentication.guard';
import { UserGuard } from './guards/user.guard';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, BrowserAnimationsModule],
  providers: [
    { provide: LOCALE_ID, useValue: 'en-US' },
    AuthenticationGuard,
    AgencyGuard,
    UserGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
