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
  form1: FormGroup = new FormGroup({
    prop1: new FormControl(''),
    prop2: new FormControl(''),
  });
  form2: FormGroup = new FormGroup({
    prop1: new FormControl(''),
    prop2: new FormControl(''),
  });
  form3: FormGroup = new FormGroup({
    prop1: new FormControl(''),
    prop2: new FormControl(''),
  });
  constructor() {}

  ngOnInit() {}

  get f(): { [key: string]: AbstractControl } {
    return this.form1.controls;
  }

  onSubmit(): void {}
}
