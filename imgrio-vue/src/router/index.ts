import { createRouter, createWebHistory } from 'vue-router';
import { registerGuard } from './Guard';

import DefaultLayout from '../layouts/DefaultLayout.vue';
import DashboardLayout from '../layouts/DashboardLayout.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      children: [
        {
          path: '',
          component: () => import('../views/HomeView.vue')
        },
        {
          path: 'sharex',
          component: () => import('../views/ShareXView.vue')
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
          component: () => import('../views/dashboard/FilesView.vue')
        },
        {
          path: 'settings',
          component: () => import('../views/dashboard/SettingsView.vue')
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
