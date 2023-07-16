<script setup lang="ts">
import LoginButton from './LoginButton.vue';
import LogoutButton from './LogoutButton.vue';
import { useIsAuthenticated } from '@/composition-api/useIsAuthenticated';

const isAuthenticated = useIsAuthenticated();
</script>

<template>
  <div className="navbar section--padding">
    <div className="navbar__container">
      <a className="navbar__container-brand" href="/">
        <img src="/logo.svg" alt="imgrio" />
      </a>
      <div className="navbar__container-links">
        <a href="/sharex">ShareX</a>
        <a href="/dashboard/files">Dashboard</a>
      </div>
      <div className="navbar__container-sign">
        <LogoutButton small transparent v-if="isAuthenticated" />
        <LoginButton small transparent v-else />
      </div>
    </div>
  </div>
</template>

<style scoped>
.navbar {
  display: flex;
  position: fixed;
  justify-content: center;
  padding-block: 0;
  height: 6.25rem;
  width: 100%;
  top: 0;
}

.navbar__container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}

.navbar__container-brand img {
  width: 3.5rem;
}

.navbar__container-sign {
  text-align: right;
}

.navbar__container-brand,
.navbar__container-sign {
  flex: none;
  width: 8rem;
}

.navbar__container-links {
  flex: 2;
  font-family: var(--font-family);
  font-size: 0.9rem;
  font-weight: 500;
  line-height: 25px;
  color: #fff;
  text-align: center;
}

.navbar__container-links a {
  margin-inline: 1rem;
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
