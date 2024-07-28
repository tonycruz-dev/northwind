import { LOCALE_ID, NgModule } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule } from '@ngx-translate/core';
import { TranslateLoader } from '@ngx-translate/core';
import { DomSanitizer } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { MatIconRegistry } from '@angular/material/icon';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { MATERIAL } from './shared-material.module';
import { NgxSpinnerModule } from "ngx-spinner";
export function createTranslateLoader( http: HttpClient) {
  return new TranslateHttpLoader(http);
}


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgxSpinnerModule,
    ...MATERIAL,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateLoader),
        deps: [HttpClient]
      },
      defaultLanguage: 'en'
    }),
    ToastrModule.forRoot({timeOut: 2000, positionClass: 'toast-bottom-right',preventDuplicates: true}),
    ReactiveFormsModule, FormsModule
  ],
  exports: [
    CommonModule,
    NgxSpinnerModule,
    ...MATERIAL,
    TranslateModule,
    ToastrModule,
    ReactiveFormsModule, FormsModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'en' },
  ]
})
export class SharedModule { 
  constructor(private matIconRegistry: MatIconRegistry, private domSanitizer: DomSanitizer) {
    this.matIconRegistry.addSvgIconSet(
      this.domSanitizer.bypassSecurityTrustResourceUrl('../assets/mdi.svg')
    );
  }
}