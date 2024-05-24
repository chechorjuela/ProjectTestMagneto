import {Component, EventEmitter, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {signUpRequest} from "../../../store/actions/auth.actions";
import {Router} from "@angular/router";
import {Store} from "@ngrx/store";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss'
})
export class SignUpComponent {
  registerForm: FormGroup;
  hide = true;
  @Output() toggleFormEvent = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private store: Store,
              private route: Router) {
    this.registerForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(form: FormGroup): any {
    return form.controls['password'].value === form.controls['confirmPassword'].value
      ? null : {mismatch: true};
  }

  onRegister() {
    const credentials = {
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      username: this.registerForm.value.username,
      password: this.registerForm.value.password,
      confirmPassword: this.registerForm.value.confirmPassword
    };

    this.store.dispatch(signUpRequest({credentials}));
  }

  toggleForm() {
    this.route.navigate(['/signin'])
  }
}
