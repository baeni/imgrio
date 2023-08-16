import { createRouter, createWebHistory } from 'vue-router';
import { registerGuard } from './Guard';

import DefaultLayout from '../layouts/DefaultLayout.vue';
import DashboardLayout from '../layouts/DashboardLayout.vue';

import HomeView from '../views/HomeView.vue';
import ShareXView from '../views/ShareXView.vue';
import FilesView from '../views/dashboard/FilesView.vue';
import HistoryView from '../views/dashboard/HistoryView.vue';
import FavoritesView from '../views/dashboard/FavoritesView.vue';
import SettingsView from '../views/dashboard/SettingsView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      children: [
        {
          path: '',
          component: HomeView
        },
        {
          path: 'sharex',
          component: ShareXView
        },
        {
          path: '/v/:id',
          component: () => import('../views/FileView.vue')
        }
      ]
    },
    {
      path: '/dashboard',
      redirect: '/dashboard/files',
      component: DashboardLayout,
      children: [
        {
          path: 'files',
          component: FilesView
        },
        {
          path: 'history',
          component: HistoryView
        },
        {
          path: 'favorites',
          component: FavoritesView
        },
        {
          path: 'settings',
          component: SettingsView
        }
      ],
      meta: {
        requiresAuth: true
      }
    },
    { path: '/:pathMatch(.*)*', name: 'NotFound', redirect: '/' }
  ]
});

registerGuard(router);

export default router;
