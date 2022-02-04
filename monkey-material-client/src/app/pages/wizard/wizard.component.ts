import { Component, OnInit } from '@angular/core';
//import { FormControl } from '@angular/forms';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';



@Component({
  selector: 'app-wizard',
  templateUrl: './wizard.component.html',
  styleUrls: ['./wizard.component.css'],
})
export class WizardComponent {
  firstFormGroup: FormGroup = this.init();

  secondFormGroup!: FormGroup;
  isEditable = true;

  submitted = false;
  //var isEditable: boolean = false;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {

    this.secondFormGroup = this.formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.firstFormGroup.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.firstFormGroup.invalid) {
      return;
    }

    console.log(JSON.stringify(this.firstFormGroup.value, null, 2));
  }

  onReset(): void {
    this.submitted = false;
    this.firstFormGroup.reset();
  }

  init(){
    return this.formBuilder.group(
      {
        firstName: ['', Validators.required],
        username: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(20),
          ],
        ],
        email: ['', [Validators.required, Validators.email]],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(40),
          ],
        ],
        confirmPassword: ['', Validators.required],
        acceptTerms: [false, Validators.requiredTrue],
      },
      {
        validators: [Validators.required],
      }
    );
  }
}
