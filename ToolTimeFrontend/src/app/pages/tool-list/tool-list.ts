import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToolsApi } from '../../services/tools/tools-api';
import { Tool } from '../../models/tool';
import { AuthService } from '../../services/auth/auth-service';

@Component({
  selector: 'app-tool-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './tool-list.html',
  styleUrl: './tool-list.scss'
})
export class ToolList implements OnInit {
  tools: Tool[] = [];
  errorMessage: string = '';
  newTool: Partial<Tool> = {};
  isLoggedIn: boolean = false;

  constructor(private api: ToolsApi, private auth: AuthService, private router: Router) {}

  ngOnInit() {
    this.isLoggedIn = this.auth.isLoggedIn();
    if (this.isLoggedIn) {
      this.loadTools();
    } else {
      this.errorMessage = 'You must be logged in to view tools.';
    }
  }

  loadTools() {
    this.api.getTools().subscribe({
      next: (data) => {
        this.tools = data;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load tools. Please try again later.';
        console.error('Error loading tools:', error);
      }
    });
  }

  addTool() {
    if (!this.newTool.name || !this.newTool.type || !this.newTool.serialNumber) return;
    this.api.addTool(this.newTool as Tool).subscribe({
      next: () => {
        this.newTool = {};
        this.loadTools();
      },
      error: (error) => {
        this.errorMessage = 'Failed to add tool. Please try again.';
        console.error('Error adding tool:', error);
      }
    });
  }

  goToLogin() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
