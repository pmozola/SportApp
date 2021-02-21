import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { AddWeightModel } from "../class/add-weight.model";
import { WeightDetailCardModel } from "../class/weight-detail-card.model";

@Injectable({
  providedIn: 'root',
})
export class WeightDataService {

  constructor(private http: HttpClient) {
  }

  add(data: AddWeightModel): Observable<any> {
    const url = `${environment.apiUrl}/weight`
    return this.http.post(url, data);
  }

  getCardDetail(): Observable<WeightDetailCardModel> {
    const url = `${environment.apiUrl}/weight`
    return this.http.get<WeightDetailCardModel>(url);
  }
}
