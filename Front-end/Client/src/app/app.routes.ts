import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { AccountComponent } from './pages/account/account.component';
import { AuthService } from './services/auth.service';
import { authGuard } from './guards/auth.guard';
import { UsersComponent } from './admin/users/users.component';
import { roleGuard } from './guards/role.guard';
import { RoleComponent } from './admin/role/role.component';
import { UserdetailComponent } from './admin/userdetail/userdetail.component';
import { UsercreateComponent } from './admin/usercreate/usercreate.component';
import { UserupdateComponent } from './admin/userupdate/userupdate.component';
import { UserdeleteComponent } from './admin/userdelete/userdelete.component';
import { StationsComponent } from './mastermanagement/station/stations/stations.component';
import { StationdetailComponent } from './mastermanagement/station/stationdetail/stationdetail.component';
import { StationcreateComponent } from './mastermanagement/station/stationcreate/stationcreate.component';
import { StationupdateComponent } from './mastermanagement/station/stationupdate/stationupdate.component';
import { StationdeleteComponent } from './mastermanagement/station/stationdelete/stationdelete.component';
import { TraincreateComponent } from './mastermanagement/train/traincreate/traincreate.component';
import { TrainupdateComponent } from './mastermanagement/train/trainupdate/trainupdate.component';
import { TraindeleteComponent } from './mastermanagement/train/traindelete/traindelete.component';
import { TrainsComponent } from './mastermanagement/train/trains/trains.component';
import { TraindetailComponent } from './mastermanagement/train/traindetail/traindetail.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'account/:id',
        component: AccountComponent,
        canActivate: [authGuard]
    },
    //Admin
    {
        path: 'users',
        component: UsersComponent,
        canActivate: [roleGuard],
        data: {
            role: 'Admin',
        },
    },
    {
        path: 'roles',
        component: RoleComponent,
        canActivate: [roleGuard],
        data: {
            role: 'Admin',
        },
    },
    {
        path: 'users/detail/:id',
        component: UserdetailComponent
    },
    {
        path: 'users/create',
        component: UsercreateComponent
    },
    {
        path: 'users/update/:id',
        component: UserupdateComponent
    },
    {
        path: 'users/delete/:id',
        component: UserdeleteComponent
    },
    //Master Management
    //Station
    {
        path: 'stations',
        component: StationsComponent,
        canActivate: [roleGuard],
        data: {
            role: 'MasterManagement',
        }
    },
    {
        path: 'station/detail/:stationID',
        component: StationdetailComponent
    },
    {
        path: 'station/create',
        component: StationcreateComponent
    },
    {
        path: 'station/update/:stationID',
        component: StationupdateComponent
    },
    {
        path: 'station/delete/:stationID',
        component: StationdeleteComponent
    },

    //Train
    {
        path: 'trains',
        component: TrainsComponent,
        canActivate: [roleGuard],
        data: {
            role: 'MasterManagement',
        }
    },
    {
        path: 'train/detail/:trainID',
        component: TraindetailComponent
    },
    {
        path: 'train/create',
        component: TraincreateComponent
    },
    {
        path: 'train/update/:trainID',
        component: TrainupdateComponent
    },
    {
        path: 'train/delete/:trainID',
        component: TraindeleteComponent
    },

    //Compartment
    // {
    //     path: 'compartment/create',
        
    // }
];

