import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Api {
  protected baseUrl = "http://localhost:5281/api"

  constructor() { }
}

