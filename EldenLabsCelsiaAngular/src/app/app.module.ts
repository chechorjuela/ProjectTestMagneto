import { NgModule } from '@angular/core';
import {BrowserModule, provideClientHydration} from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './pages/auth/sign-in/sign-in.component';
import { SignUpComponent } from './pages/auth/sign-up/sign-up.component';
import { DashboardComponent } from './pages/home/dashboard/dashboard.component';
import { MeasurenmentComponent } from './pages/home/measurenment/measurenment.component';
import {measurenmentReducer} from "./store/reducers/measurenment.reducer";
import {StoreModule} from "@ngrx/store";
import {authReducer} from "./store/reducers/auth.reducer";
import {EffectsModule} from "@ngrx/effects";
import {AuthEffects} from "./store/effects/auth.effects";
import {StoreDevtoolsModule} from "@ngrx/store-devtools";
import {ReactiveFormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withFetch} from "@angular/common/http";
import {MatInputModule} from "@angular/material/input";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatButtonModule} from "@angular/material/button";
import {MatTableModule} from "@angular/material/table";
import {MatDialogModule} from "@angular/material/dialog";
import {MatNativeDateModule} from "@angular/material/core";
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatToolbarModule} from "@angular/material/toolbar";
import {HttpHelperService} from "./utils/http-helper.service";
import {AuthInterceptor} from "./interceptors/auth.interceptor";
import {provideAnimationsAsync} from "@angular/platform-browser/animations/async";
import { LayoutComponent } from './organismis/layout/layout.component';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    DashboardComponent,
    MeasurenmentComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule,
    MatNativeDateModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
    MatToolbarModule,
    StoreModule.forRoot({
      measurenment: measurenmentReducer,
      auth: authReducer
    }),
    EffectsModule.forRoot([AuthEffects, AuthEffects]),
    StoreDevtoolsModule.instrument({maxAge: 25}),
  ],
  providers: [
    HttpHelperService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    provideHttpClient(withFetch()),
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
