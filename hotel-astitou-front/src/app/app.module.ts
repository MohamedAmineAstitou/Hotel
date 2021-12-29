import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';



import { AppComponent } from './app.component';
import { appRoutingModule } from './app.routing';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { LoginComponent } from './login';;
import { AddUserComponent } from './user/add-user/add-user.component';
import { ListUserComponent } from './user/list-user/list-user.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ListLodgerComponent } from './lodger/list-lodger/list-lodger.component';
import { AddLodgerComponent } from './lodger/add-lodger/add-lodger.component';
import { EditLodgerComponent } from './lodger/edit-lodger/edit-lodger.component';
import { ListApartmentComponent } from './apartment/list-apartment/list-apartment.component';
import { AddApartmentComponent } from './apartment/add-apartment/add-apartment.component';
import { EditApartmentComponent } from './apartment/edit-apartment/edit-apartment.component';
import { ListBookingComponent } from './booking/list-booking/list-booking.component';
import { EditBookingComponent } from './booking/edit-booking/edit-booking.component';
import { EditGuarantorComponent } from './guarantor/edit-guarantor/edit-guarantor.component';
import { ListGuarantorComponent } from './guarantor/list-guarantor/list-guarantor.component';;
import { AddBookingComponent } from './booking/add-booking/add-booking.component'

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        appRoutingModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        AddUserComponent ,
        ListUserComponent ,
        EditUserComponent ,
        ListLodgerComponent ,
        AddLodgerComponent,
        EditLodgerComponent,
        ListApartmentComponent,
        AddApartmentComponent,
        EditApartmentComponent,
        ListBookingComponent,
        EditBookingComponent,
        ListGuarantorComponent,
        EditGuarantorComponent ,
        AddBookingComponent  ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }