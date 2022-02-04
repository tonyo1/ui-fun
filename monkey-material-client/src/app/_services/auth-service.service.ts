import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { AppUser } from '../models/app-user';

import { catchError, map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {
  isLoginSubject = new BehaviorSubject<boolean>(this.hasToken());
  constructor(private http: HttpClient) {}

  login(username: string, password: string) {
    return this.http
      .post<any>('https://localhost:7296/AppUsers', { username, password })
      .subscribe(
        (response) => {
          //Next callback
          console.log('response received');
          this.setSession({
            expiresIn: response['expires_at'],
            idToken: response['id_token'],
          });
        },
        (error) => {
          //Error callback
          console.error('error caught in component');
          console.log(error);
          //throw error;   //You can also throw the error to a global error handler
        }
      );
  }

  private setSession(authResult: {
    expiresIn: moment.DurationInputArg1;
    idToken: string;
  }) {
    this.isLoginSubject.next(true);
    const expiresAt = moment().add(authResult.expiresIn, 'second');

    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', JSON.stringify(expiresAt.valueOf()));
  }

  logout() {
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    this.isLoginSubject.next(false);
  }

  hasToken() {
    return localStorage.getItem('id_token') != null;
  }

  isLoggedIn(): Observable<boolean> {
    return this.isLoginSubject.asObservable();
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  getExpiration() {
    const expiration = localStorage.getItem('expires_at') + '';
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }
}
