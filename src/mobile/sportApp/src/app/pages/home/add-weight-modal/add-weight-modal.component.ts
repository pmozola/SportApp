import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalController, PickerController } from '@ionic/angular';
import { WeightDataService } from '../services/weight.data.service';

@Component({
  selector: 'app-add-weight-modal',
  templateUrl: './add-weight-modal.component.html',
  styleUrls: ['./add-weight-modal.component.scss'],
})
export class AddWeightModalComponent implements OnInit {
  form: FormGroup;
  defaultDate: string;

  constructor(private modalController: ModalController, private dataService: WeightDataService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.defaultDate = new Date().toISOString().substring(0, 10);
    this.form = this.formBuilder.group({
      date: [this.defaultDate, Validators.required],
      value: ['', Validators.required]
    })
  }

  submit() {
    if (!this.form.valid) {
      return;
    }

    this.dataService
      .add(this.form.value)
      .subscribe();
  }

  cancel() { }
}
