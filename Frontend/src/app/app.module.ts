import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import {MatTableModule} from '@angular/material/table';
import {MatIconModule} from '@angular/material/icon';
import { provideHttpClient, withInterceptorsFromDi, withXhr } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddcontactComponent } from './components/addcontact/addcontact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditcontactComponent } from './components/editcontact/editcontact.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatButtonModule} from '@angular/material/button';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatTooltipModule} from '@angular/material/tooltip';




@NgModule({ declarations: [
        AppComponent,
        HomeComponent,
        AddcontactComponent,
        EditcontactComponent
    ],
    bootstrap: [AppComponent],
    imports: [BrowserModule,
        AppRoutingModule,
        MatTableModule,
        MatIconModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        MatPaginatorModule,
        MatButtonModule,
        MatSortModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatTooltipModule], providers: [
        provideHttpClient(withXhr(), withInterceptorsFromDi())
    ] })
export class AppModule { }
