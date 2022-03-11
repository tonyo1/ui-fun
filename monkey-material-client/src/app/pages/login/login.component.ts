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
  putresult: string = '';

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
  putter():void {


      fetch('https://localhost:7296/AppUsers', {
        method: 'PUT', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer: ' + this._authService.getToken(),
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
       // body: JSON.stringify(data) // body data type must match "Content-Type" header
      }).then(response => response.json())
      .then(data => { this.putresult = data.toString()});
    }


  @Input() error: string | null | undefined;

  @Output() submitEM = new EventEmitter();
}
