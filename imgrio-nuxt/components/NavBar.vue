<template>
  <div class="navbar section--padding">
    <div class="navbar__container">
      <NuxtLink class="navbar__container-brand" to="/">
        <img src="/logo.svg" alt="imgrio" />
      </NuxtLink>
      <div class="navbar__container-links">
        <NuxtLink to="/sharex">{{ $t("pages.sharex.title") }}</NuxtLink>
        <NuxtLink to="/dashboard/files">{{
          $t("pages.dashboard.title")
        }}</NuxtLink>
      </div>
      <div class="navbar__container-sign">
        <div v-if="user">
          <LogoutButton small transparent />
          <Avatar :user="user" />
        </div>
        <LoginButton small transparent v-else />
      </div>
      <div class="navbar__container-burger" @click="toggleMenu">
        <img src="../assets/icons/burger-open.svg" v-if="!isMenuActive" />
        <img src="../assets/icons/burger-close.svg" v-else />
      </div>
    </div>
    <div class="navbar__menu" v-if="isMenuActive">
      <NuxtLink to="/sharex">{{ $t("pages.sharex.title") }}</NuxtLink>
      <NuxtLink to="/dashboard/files">{{
        $t("pages.dashboard.title")
      }}</NuxtLink>

      <LogoutButton small transparent v-if="user" />
      <LoginButton small transparent v-else />
      <LoginButton small transparent />
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";

import LoginButton from "./LoginButton.vue";
import LogoutButton from "./LogoutButton.vue";
import Avatar from "./Avatar.vue";

const user = useCurrentUser();

const isMenuActive = ref(false);

function toggleMenu() {
  isMenuActive.value = !isMenuActive.value;
}
</script>

<style scoped>
.navbar {
  display: flex;
  position: fixed;
  justify-content: center;
  padding-block: 0;
  height: 6.25rem;
  width: 100%;
  top: 0;
  backdrop-filter: blur(10px);
  z-index: 999;
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

.navbar__container-sign,
.navbar__container-sign div {
  display: flex;
  text-align: right;
  justify-content: right;
  align-items: center;
  gap: 10px;
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
  color: var(--color-light);
  text-align: center;
}

.navbar__container-links a {
  margin-inline: 1rem;
}

.navbar__container-burger {
  display: none;
  cursor: pointer;
  z-index: 999;
}

.navbar__menu {
  display: none;
  position: absolute;
  width: 100%;
  height: 100vh;
  padding: 3rem;
  background: var(--color-bg);
}

.navbar__menu a {
  display: block;
  padding: 0.75rem 0;
  font-family: var(--font-family);
  font-size: 1.75rem;
  font-weight: 500;
  line-height: 35px;
  color: var(--color-light);
}

.router-link-active {
  color: #fff !important;
}

@media screen and (max-width: 768px) {
  .navbar__container-links {
    display: none;
  }

  .navbar__container-sign {
    display: none;
  }

  .navbar__container-burger {
    display: block;
  }

  .navbar__menu {
    display: block;
  }
}
</style>
