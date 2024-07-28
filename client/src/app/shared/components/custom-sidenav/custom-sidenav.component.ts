import { Component, computed, Input, signal } from '@angular/core';
import { MenuItem } from '../../Models/MenuItem';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import { NgFor, NgIf } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuItemComponent } from "../menu-item/menu-item.component";

@Component({
  selector: 'app-custom-sidenav',
  standalone: true,
  imports: [MatListModule, MatIconModule, NgFor, NgIf, RouterModule, MenuItemComponent],
  templateUrl: './custom-sidenav.component.html',
  styleUrl: './custom-sidenav.component.scss'
})
export class CustomSidenavComponent {
  sideNavCollapse = signal(false);
  @Input() set collapsed(value: boolean) {
    this.sideNavCollapse.set(value);
  }
  menuItems = signal<MenuItem[]>([
    {
      icon: 'dashboard', 
      label: 'Home', 
      route: 'home-page',
    },
    {
      icon: 'category', 
      label: 'Categories', 
      route: 'categories',
      subItems: [
        { label: 'Category Table', route: 'category-table', icon: 'view_list' },
        { label: 'Category List', route: 'category-list', icon: 'playlist_add_check' },
        { label: 'With Products', route: 'category-with-products' ,icon: 'takeout_dining'  },
      ]
    },
    {
      icon: 'analytics', 
      label: 'Analytics', 
      route: 'analytics',
    },
    {
      icon: 'comment', 
      label: 'Comments', 
      route: 'comments',
    },
  ]);
 profilePicSize = computed(() => this.sideNavCollapse() ? '32' : '100');
}
