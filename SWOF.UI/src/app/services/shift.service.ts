import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';

@Injectable()
export class ShiftService {  
  constructor(private http: HttpClient) { }

  schedule(){
    return this.http.get(environment.service + "Schedule")
      .map(response => response);
  }

}
