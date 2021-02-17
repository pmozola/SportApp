import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { ExerciseInfo } from "../class/exercise-info";
import { environment } from "src/environments/environment";
import { ExerciseDetail } from "../class/exercise-detail";

@Injectable({
  providedIn: 'root',
})
export class ExerciseDataService {

  constructor(private http: HttpClient) {
  }

  getExerciseList(): Observable<ExerciseInfo[]> {
    const url = `${environment.apiUrl}/exercise`
    return this.http.get<ExerciseInfo[]>(url);
  }

  getExerciseDetail(id: number): Observable<ExerciseDetail> {
    const url = `${environment.apiUrl}/exercise/${id}`
    return this.http.get<ExerciseDetail>(url);
  }
}
