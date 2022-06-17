import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from './user.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'assignment-ui';
  registrationForm = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]]
  });
  submitted = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService) {
  }

  get r() { return this.registrationForm.controls; }

  onSubmit = () => {
    this.submitted = true;
    console.log({ ...this.registrationForm.value })
    this.userService.save({ ...this.registrationForm.value }).subscribe(data => {
      alert('Data saved successfully !!!')
    });
  }
}
