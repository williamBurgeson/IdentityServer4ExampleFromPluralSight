import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginModel } from '../../models/login-model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private _http: HttpClient) { }

  getLoginModel(returnUrl: string) {
    this._http.get<LoginModel>(`api/login/${returnUrl}`);
  }

  login(loginModel: LoginModel) {
    loginModel.cancelLogin = false;
    this._http.post<LoginModel>('api/login', loginModel).subscribe(result => {
      document.location.href = result.returnUrl;
    });
  }

  cancelLogin(loginModel: LoginModel) {
    loginModel.cancelLogin = true;
    this._http.post<LoginModel>('api/login', loginModel).subscribe(result => {
      document.location.href = result.returnUrl;
    });
  }
}
