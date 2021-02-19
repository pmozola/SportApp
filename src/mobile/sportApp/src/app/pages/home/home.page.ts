import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { AddWeightModalComponent } from './add-weight-modal/add-weight-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(public modalController: ModalController) { }

  ngOnInit() {
  }

 public  async openAddWeightModal() {
    const modal = await this.modalController.create({
      component: AddWeightModalComponent
    });
    return await modal.present();
  }

}
