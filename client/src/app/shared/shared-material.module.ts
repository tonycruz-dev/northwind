import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule,MatIconRegistry } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

export const MATERIAL = [MatCheckboxModule, MatInputModule, MatButtonModule, MatToolbarModule, MatFormFieldModule,
  MatCardModule, MatSelectModule, MatSidenavModule, MatIconModule, MatExpansionModule,
  MatAutocompleteModule, MatDialogModule, MatDatepickerModule, MatNativeDateModule,
  MatMenuModule, MatDividerModule, MatBadgeModule, MatTooltipModule, MatButtonToggleModule,
  MatChipsModule,MatListModule,MatTableModule,MatPaginatorModule,MatSortModule,
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ...MATERIAL,
  ],
  exports: [
    ...MATERIAL
  ]
})
export class SharedMaterialModule { }
