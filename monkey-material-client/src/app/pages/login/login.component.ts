import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/_services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  authenticationService: AuthService;

  constructor(private injector: Injector) {
    this.authenticationService = this.injector.get(AuthService);

  }

  ngOnInit(): void {}

  myFunc():void {
    this.authenticationService.login('string','string');
  }
}
