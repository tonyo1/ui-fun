import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './pages/home/home.component';
import { WizardComponent } from './pages/wizard/wizard.component';
import {MatToolbarModule} from '@angular/material/toolbar'; 
 
 import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
 
import {MatStepperModule} from '@angular/material/stepper';

import {ReactiveFormsModule} from '@angular/forms';

import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatInputModule } from '@angular/material/input';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import { LoginComponent } from './pages/login/login.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    WizardComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, 
    MatToolbarModule, 
    MatIconModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatButtonModule ,
    MatFormFieldModule,
    MatInputModule,
    MatGridListModule,
    MatCardModule
 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
