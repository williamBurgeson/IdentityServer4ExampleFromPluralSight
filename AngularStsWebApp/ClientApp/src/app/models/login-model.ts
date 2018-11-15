export interface LoginModel {
  username: string;
  password: string;
  rememberLogin: boolean;
  returnUrl: string;
  allowRememberLogin: boolean;
  enableLocalLogin: boolean;
  redirectTo: string | null;
  cancelLogin: boolean;
}
