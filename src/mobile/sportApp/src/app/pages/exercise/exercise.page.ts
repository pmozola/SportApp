import { Component, OnInit } from '@angular/core';
import { ExerciseDataService } from './services/exercise.data.service';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.page.html',
  styleUrls: ['./exercise.page.scss'],
})
export class ExercisePage implements OnInit {

  constructor(private dataService: ExerciseDataService) { }

  ngOnInit() {
    this.dataService.getExerciseList().subscribe(x => console.log(x));
  }
}
