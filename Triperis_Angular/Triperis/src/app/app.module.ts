import { AuthInterceptor } from './guards/auth.interceptor';
import { UsersService } from 'src/app/services/users.service';
import { AuthGuard } from './guards/auth.guard';
import { RouterModule, CanActivate } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { CarListComponent } from './components/car-list/car-list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { LoginComponent } from './components/userComponents/login/login.component';
import { RegisterComponent } from './components/userComponents/register/register.component';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { ProfileComponent } from './components/userComponents/profile/profile.component';
import { FooterComponent } from './components/footer/footer.component';
import { UserTabsComponent } from './components/userComponents/user-tabs/user-tabs.component';
import {MatTabsModule} from '@angular/material/tabs';
import { UserListComponent } from './components/adminComponents/user-list/user-list.component';
import { ForbiddenComponent } from './components/forbidden/forbidden.component';
import { ImageUploadComponent } from './components/images/image-upload/image-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarListComponent,
    LoginComponent,
    RegisterComponent,
    ProfileComponent,
    FooterComponent,
    UserTabsComponent,
    UserListComponent,
    ForbiddenComponent,
    ImageUploadComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: '', component: CarListComponent, pathMatch: 'full'},
      {path: 'Profile', component: ProfileComponent, pathMatch: 'full', canActivate:[AuthGuard]},
      {path: 'LoginRegister', component: UserTabsComponent, pathMatch: 'full'},
      {path: 'Forbidden', component: ForbiddenComponent, pathMatch: 'full'},
      {path: 'UserList', component: UserListComponent, pathMatch: 'full', canActivate:[AuthGuard], data : {permittedRoles: ['Admin']}},
      {path: 'UploadImages', component: ImageUploadComponent, pathMatch: 'full'}
    ]),
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    FormsModule,
    MatTabsModule
  ],
  providers: [UsersService,{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
