import { NgFor, NgIf } from '@angular/common';
import { Component, input, signal } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { MenuItem } from '../../Models/MenuItem';
import { animate, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-menu-item',
  standalone: true,
  imports: [MatListModule, MatIconModule, NgFor, NgIf, RouterModule],
  templateUrl: './menu-item.component.html',
  styleUrl: './menu-item.component.scss',
  animations:[
    trigger('expandContractMenu',[
      transition(':enter', [
        style({opacity: 0, height: 0}),
        animate('500ms ease-in-out', style({opacity: 1, height: '*'}))
      ]),
      transition(':leave', [
        animate('500ms ease-in-out', style({opacity: 0, height: '0px'}))
      ])
    ] )
  ]
})
export class MenuItemComponent {
  item = input.required<MenuItem>();
  collapsed = input(false);
  nestedMenuOpen = signal(false);

   toggleNested() {
     if (!this.item().subItems) {
       return;
     }
     this.nestedMenuOpen.set(!this.nestedMenuOpen());
   }
}
