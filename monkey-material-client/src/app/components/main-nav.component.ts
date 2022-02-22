import { Component, OnInit } from '@angular/core';
import { __asyncValues } from 'tslib';
import { AuthService } from '../_services/auth-service.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css'],
})
export class MainNavComponent implements OnInit {
  isLoggedIn: boolean = false;
  constructor(private _authService: AuthService) {
    this._authService.isLoggedIn().subscribe((res) => {
      this.isLoggedIn = res;
    });
  }

  ngOnInit(): void {}
  logOut() {
    this._authService.logout();
  }
}
