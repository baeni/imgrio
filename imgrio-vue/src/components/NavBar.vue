<script setup lang="ts">
import LoginButton from './LoginButton.vue';
import LogoutButton from './LogoutButton.vue';
import { useIsAuthenticated } from '@/composition-api/useIsAuthenticated';

const isAuthenticated = useIsAuthenticated();
</script>

<template>
  <div className="navbar section--padding">
    <div className="navbar__links">
      <a className="navbar__links-brand" href="/">
        <img src="/logo.svg" alt="imgrio" />
      </a>
      <div className="navbar__links-container">
        <p><a href="/sharex">ShareX</a></p>
        <p><a href="/dashboard/files">Dashboard</a></p>
      </div>
    </div>
    <div className="navbar__sign">
      <LogoutButton small transparent v-if="isAuthenticated" />
      <LoginButton small transparent v-else />
    </div>
  </div>
</template>

<style scoped>
.navbar {
  padding-block: 0;
  display: flex;
  position: fixed;
  top: 0;
  height: 6.25rem;
  width: 100%;
  justify-content: space-between;
  align-items: center;
  -webkit-backdrop-filter: blur(15px);
  backdrop-filter: blur(15px);
  z-index: 999;
}

.navbar__links {
  display: flex;
  flex: 1;
  justify-content: flex-start;
  align-items: center;
}

.navbar__links-brand {
  display: flex;
  justify-content: center;
  align-items: center;
  color: var(--color-primary);
  font-family: var(--font-family-brand);
  font-size: 1.25rem;
  font-weight: 600;
  line-height: 25px;
}

.navbar__links-brand img {
  width: 3.5rem;
}

.navbar__links-container {
  margin-inline: 2rem;
  display: flex;
  flex: 1;
  justify-content: center;
  align-items: center;
}

.navbar__links-container p,
.navbar__sign p,
.navbar__menu-container {
  color: #fff;
  font-family: var(--font-family);
  font-weight: 500;
  font-size: 0.9rem;
  line-height: 25px;
  text-transform: capitalize;

  margin-inline: 1rem;
  cursor: pointer;
}

/* @media screen and (max-width: 1050px) {
  .navbar {
    padding: 2rem;
  }
}

@media screen and (max-width: 650px) {
  .navbar {
    padding: 1rem;
  }
} */
</style>
