import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
 
 
import { WizardComponent } from './components/wizard/wizard.component';
import { Step1Component } from './components/wizard/step1/step1.component';
import { Step2Component } from './components/wizard/step2/step2.component';
import { Step3Component } from './components/wizard/step3/step3.component';
import { Step4Component } from './components/wizard/step4/step4.component';
import { Step5Component } from './components/wizard/step5/step5.component';

@NgModule({
  declarations: [
    AppComponent,
    WizardComponent,
    Step1Component,
    Step2Component,
    Step3Component,
    Step4Component,
    Step5Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
