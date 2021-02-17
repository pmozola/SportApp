import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ExerciseInfo } from './class/exercise-info';
import { ExerciseDataService } from './services/exercise.data.service';

@Component({
  selector: 'app-exercise',
  templateUrl: './exercise.page.html',
  styleUrls: ['./exercise.page.scss'],
})
export class ExercisePage implements OnInit {
  exercises: Observable<ExerciseInfo[]>;

  constructor(private dataService: ExerciseDataService, private route: Router) { }

  ngOnInit() {
    this.exercises = this.dataService.getExerciseList();
  }

  navigateToExercise(id: number) {
    this.route.navigate(['exercise', 'detail', id]);
  }
}
