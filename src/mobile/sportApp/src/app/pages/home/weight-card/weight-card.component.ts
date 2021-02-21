import { Component, OnInit } from '@angular/core';
import { WeightDetailCardModel } from '../class/weight-detail-card.model';
import { WeightDataService } from '../services/weight.data.service';

@Component({
  selector: 'app-weight-card',
  templateUrl: './weight-card.component.html',
  styleUrls: ['./weight-card.component.scss'],
})
export class WeightCardComponent implements OnInit {
  userWeight: WeightDetailCardModel

  constructor(private dataService: WeightDataService) { }

  ngOnInit() {
    this.dataService.getCardDetail().subscribe(result => this.userWeight = result);
  }

}
