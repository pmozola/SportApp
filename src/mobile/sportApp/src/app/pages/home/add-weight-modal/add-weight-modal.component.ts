import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-add-weight-modal',
  templateUrl: './add-weight-modal.component.html',
  styleUrls: ['./add-weight-modal.component.scss'],
})
export class AddWeightModalComponent implements OnInit {

  constructor(private modalController: ModalController) { }

  ngOnInit() { }

  dismissModal() {
    this.modalController.dismiss()
  }
  save() {
    console.log("zapisane");
    this.modalController.dismiss();
  }
}
