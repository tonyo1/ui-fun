import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AppUser } from 'src/app/models/app-user';
import { AuthService } from 'src/app/_services/auth-service.service';
import {FormGroup, FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  isLoggedIn: boolean = false;
  user: AppUser = new AppUser();
  form: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(public _authService: AuthService)  {

    this._authService
      .isLoggedIn()
      .subscribe((res) => {
          this.isLoggedIn=res;
          if (res) this.user = _authService.getAppUser();
        });
   }

  ngOnInit(): void {}

  login():void {
    this._authService.login(this.form.get('username')?.value,
                            this.form.get('password')?.value);
  }

  logout():void {
    this._authService.logout();
  }

  @Input() error: string | null | undefined;

  @Output() submitEM = new EventEmitter();
}
