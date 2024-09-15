import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  { path: '', pathMatch: 'full', redirectTo: '/home' },
  { path: 'signed-in-redirect', pathMatch: 'full', redirectTo: '/home' },
  {
    path: '',
    children: [
      {
        path: 'home',
        loadChildren: () => import('../app/modules/home/home.module').then(module => module.HomeModule)
      }
    ]
  }
];
