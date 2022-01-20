import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { WizardComponent } from './pages/wizard/wizard.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'wizard', component: WizardComponent   } ,
  { path: '', component: HomeComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
