import {
  Component, Input, NgModule,
} from '@angular/core';
import { CommonModule, LowerCasePipe, DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { DxButtonModule, DxToastModule } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

import { Task } from 'src/app/types/task';

import { UserAvatarComponent } from '../user-avatar/user-avatar.component';

@Component({
    selector: 'task-kanban-card',
    templateUrl: './task-kanban-card.component.html',
    styleUrls: ['./task-kanban-card.component.scss'],
    standalone: true,
    imports: [
        DxButtonModule,
        UserAvatarComponent,
        LowerCasePipe,
        DatePipe,
    ],
})
export class TaskKanbanCardComponent {
  @Input() task: Task;

  constructor(private router: Router) {
  }

  getAvatarText = (name: string) => name.split(' ').map((name) => name[0]).join('');

  notify = (e) => {
    e.event.stopPropagation();
    notify(`Edit '${this.task.text}' card event`);
  };

  navigateToDetails = () => {
    this.router.navigate(['/planning-task-details']);
  };
}


