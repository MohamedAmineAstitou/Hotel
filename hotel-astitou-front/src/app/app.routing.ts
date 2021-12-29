import { Routes, RouterModule } from '@angular/router';
import { AddApartmentComponent } from './apartment/add-apartment/add-apartment.component';
import { EditApartmentComponent } from './apartment/edit-apartment/edit-apartment.component';
import { ListApartmentComponent } from './apartment/list-apartment/list-apartment.component';
import { AddBookingComponent } from './booking/add-booking/add-booking.component';
import { EditBookingComponent } from './booking/edit-booking/edit-booking.component';
import { ListBookingComponent } from './booking/list-booking/list-booking.component';
import { EditGuarantorComponent } from './guarantor/edit-guarantor/edit-guarantor.component';
import { ListGuarantorComponent } from './guarantor/list-guarantor/list-guarantor.component';

import { HomeComponent } from './home';
import { AddLodgerComponent } from './lodger/add-lodger/add-lodger.component';
import { EditLodgerComponent } from './lodger/edit-lodger/edit-lodger.component';
import { ListLodgerComponent } from './lodger/list-lodger/list-lodger.component';
import { LoginComponent } from './login';
import { AddUserComponent } from './user/add-user/add-user.component';
import { EditUserComponent } from './user/edit-user/edit-user.component';
import { ListUserComponent } from './user/list-user/list-user.component';
import { AuthGuard } from './_helpers';

const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'add-user', component: AddUserComponent,canActivate: [AuthGuard] },
    { path: 'edit-user', component: EditUserComponent,canActivate: [AuthGuard] },
    { path: 'list-user', component: ListUserComponent,canActivate: [AuthGuard] },
    { path: 'add-lodger', component: AddLodgerComponent,canActivate: [AuthGuard] },
    { path: 'edit-lodger', component: EditLodgerComponent,canActivate: [AuthGuard] },
    { path: 'list-lodger', component: ListLodgerComponent,canActivate: [AuthGuard] },
    { path: 'add-apartment', component: AddApartmentComponent,canActivate: [AuthGuard] },
    { path: 'edit-apartment', component: EditApartmentComponent,canActivate: [AuthGuard] },
    { path: 'list-apartment', component: ListApartmentComponent,canActivate: [AuthGuard] },
    { path: 'edit-booking', component: EditBookingComponent,canActivate: [AuthGuard] },
    { path: 'list-booking', component: ListBookingComponent,canActivate: [AuthGuard] },
    { path: 'edit-guarantor', component: EditGuarantorComponent,canActivate: [AuthGuard] },
    { path: 'list-guarantor', component: ListGuarantorComponent, canActivate: [AuthGuard] },
    { path: 'add-booking', component: AddBookingComponent, canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);