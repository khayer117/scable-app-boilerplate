import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService, AuthenticationService } from '../_services';
import { UserLogin } from './user-login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('userLoginForm',{ static: false }) UserLoginForm?: NgForm;
  userLogin: UserLogin;
  returnUrl: string;
  loginMsg: string;

  constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService
    ) {
      this.userLogin = ({} as UserLogin);
      // redirect to home if already logged in
      if (this.authenticationService.currentUserValue) {
        console.info('Already login.');
        this.router.navigate(['/']);
      }
  }

  ngOnInit(): void {
      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  submitForm() {
    console.log('user id: ' + this.userLogin.userId);
    console.log('user pwd: ' + this.userLogin.password);
    //console.log(this.UserLoginForm?.value.form.valid);
    //this.UserLoginForm?.value.form.markAllAsTouched();

    // reset alerts on submit
    this.alertService.clear();
    this.loginMsg = '';

    this.authenticationService.login(this.userLogin.userId, this.userLogin.password)
    .pipe(first())
    .subscribe(
        data => {
            this.router.navigate([this.returnUrl]);
        },
        error => {
            this.loginMsg = 'Invalid userid/password';
            console.log('invalid User Id or Password');
            //this.alertService.error(error);
        });
    }
}
