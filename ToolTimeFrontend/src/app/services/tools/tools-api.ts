import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tool } from '../../models/tool';
import { Api } from '../api';
@Injectable({
  providedIn: 'root'
})
export class ToolsApi extends Api {

  constructor(private http: HttpClient) { 
    super();
  }
  
  getTools(): Observable<any[]> {
    return this.http.get<Tool[]>(`${this.baseUrl}/tools`);
  }

  addTool(tool: Tool): Observable<Tool> {
    return this.http.post<Tool>(`${this.baseUrl}/tools`, tool);
  }
}
