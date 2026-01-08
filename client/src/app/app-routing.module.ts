import { NgModule, inject } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import {
  LoginFormComponent,
  ResetPasswordFormComponent,
  CreateAccountFormComponent,
  ChangePasswordFormComponent,
} from './components';
import { AuthGuardService, AuthService } from './services';

import { SideNavOuterToolbarComponent, UnauthenticatedContentComponent } from './layouts';
 
import { CrmContactDetailsComponent } from './pages/crm-contact-details/crm-contact-details.component';
import { PlanningTaskListComponent } from './pages/planning-task-list/planning-task-list.component';
import { PlanningTaskDetailsComponent } from './pages/planning-task-details/planning-task-details.component';
import { AnalyticsDashboardComponent } from './pages/analytics-dashboard/analytics-dashboard.component';
import { AnalyticsSalesReportComponent } from './pages/analytics-sales-report/analytics-sales-report.component';
import { AnalyticsGeographyComponent } from './pages/analytics-geography/analytics-geography.component';
import { PlanningSchedulerComponent } from './pages/planning-scheduler/planning-scheduler.component';
import { AppSignInComponent } from './pages/sign-in-form/sign-in-form.component';
import { AppSignUpComponent } from './pages/sign-up-form/sign-up-form.component';
import { AppResetPasswordComponent } from './pages/reset-password-form/reset-password-form.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { HomeComponent } from './pages/home/home.component';
import { RolesComponent } from './pages/roles/roles.component';
import { UsersComponent } from './pages/users/users.component';
import { CustomersComponent } from './pages/customers/customers.component';
import { BrandsComponent } from './pages/brands/brands.component';
import { PayEasyComponent } from './pages/pay-easy/pay-easy.component';
import { VEM_ROUTES } from './pages/vem/vem.routes';

export const routes: Routes = [
  {
    path: 'auth',
    component: UnauthenticatedContentComponent,
    children: [ 
      {
        path: 'login',
        component: LoginFormComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'reset-password',
        component: ResetPasswordFormComponent,
        canActivate: [AuthGuardService],
      }, 
      {
        path: 'change-password/:recoveryCode',
        component: ChangePasswordFormComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: '**',
        redirectTo: 'login',
        pathMatch: 'full',
      },
    ]
  }, 
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: '',
    component: SideNavOuterToolbarComponent,
    canActivateChild: [() => inject(AuthService).isPageAuthenticated()],
    children: [
      {
        path: 'home',
        component: HomeComponent,
       canActivate: [AuthGuardService],
      },
      {
        path: 'roles',
        component: RolesComponent,
       canActivate: [AuthGuardService],
      },
      {
        path: 'users',
        component: UsersComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'customers',
        component: CustomersComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'brands',
        component: BrandsComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'payeasy',
        component: PayEasyComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'planning-scheduler',
        component: PlanningSchedulerComponent
      },
      {
        path: 'analytics-dashboard',
        component: AnalyticsDashboardComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'analytics-sales-report',
        component: AnalyticsSalesReportComponent,
        //  canActivate: [AuthGuardService],
      },
      {
        path: 'analytics-geography',
        component: AnalyticsGeographyComponent,
        //  canActivate: [AuthGuardService],
      },
      {
        path: 'sign-in-form',
        component: AppSignInComponent,
        // canActivate: [AuthGuardService],
      },
      {
        path: 'sign-up-form',
        component: AppSignUpComponent,
        //  canActivate: [AuthGuardService],
      },
      {
        path: 'reset-password-form',
        component: AppResetPasswordComponent,
        //  canActivate: [AuthGuardService],
      },
      {
        path: 'user-profile',
        component: UserProfileComponent
      },
      // VEM Routes
      {
        path: 'vem',
        children: VEM_ROUTES
      },
      {
        path: '**',
        redirectTo: 'home',
        pathMatch: 'full',
      },
    ]
  },
];

