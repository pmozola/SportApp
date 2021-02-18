import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { ExerciseDetail } from '../class/exercise-detail';
import { ExerciseDataService } from '../services/exercise.data.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
})
export class DetailPage implements OnInit {
  detail: ExerciseDetail
  videoUrl: SafeResourceUrl;
  constructor(private dataService: ExerciseDataService, public sanitizer: DomSanitizer, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.dataService
      .get(+this.route.snapshot.paramMap.get('id'))
      .subscribe(x => {
        this.videoUrl = this.sanitizer.bypassSecurityTrustResourceUrl(x.videoUrl);
        this.detail = x;
      })
  }
}
