import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { AddWeightModalComponent } from './add-weight-modal/add-weight-modal.component';
import { WeightCardComponent } from './weight-card/weight-card.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule.forRoot(),
    HomePageRoutingModule,
    ReactiveFormsModule,
  ],
  declarations: [HomePage, AddWeightModalComponent, WeightCardComponent]
})
export class HomePageModule { }
