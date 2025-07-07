import { Routes } from '@angular/router';
import { ToolList } from './pages/tool-list/tool-list';
import { Home } from './pages/home/home';
import { MaintenanceRequests } from './pages/maintenance-requests/maintenance-requests';
import { CheckoutRecords } from './pages/checkout-records/checkout-records';
import { Login } from './pages/login/login';

export const routes: Routes = [
    {path: '', component: Home},
    {path: 'login', component: Login},
    {path: 'tools', component: ToolList},
    {path: 'maintenance-requests', component: MaintenanceRequests},
    {path: 'checkout-records', component: CheckoutRecords},
];
