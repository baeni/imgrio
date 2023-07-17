<script setup lang="ts">
import FileCard from '../../components/FileCard.vue';

const files = [
  {
    id: '',
    name: 'Mercedes, Mercedes ...',
    type: '',
    size: '',
    uploadedAt: '7/9/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689170649735-a8c259851e2d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=688&q=80'
  },
  {
    id: '',
    name: 'Cityyy',
    type: '',
    size: '',
    uploadedAt: '7/9/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689157611532-5cc61e96cc0f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80'
  },
  {
    id: '',
    name: 'A Bird',
    type: '',
    size: '',
    uploadedAt: '7/9/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689198923121-c9df32e192eb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw3fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Castle of Doom oderso',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689244352181-708d13b4eb38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Elephant baby boo',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1688048110668-f07715ee9156?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=733&q=80'
  },
  {
    id: '',
    name: 'Mountains vac',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689085781839-2e1ff15cb9fe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Blonde Woman',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689058949660-9a77ea19e86d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzNHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Church I guess?',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689082754713-636f853a615b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Woman in Nature',
    type: '',
    size: '',
    uploadedAt: '3/23/2023 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689089376904-4755ada5058a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOXx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    id: '',
    name: 'Korean school girl c.c',
    type: '',
    size: '',
    uploadedAt: '9/2/2022 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1689426308960-6917b05ab2d0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80'
  },
  {
    id: '',
    name: 'Illustration',
    type: '',
    size: '',
    uploadedAt: '9/2/2022 09:52:52 AM',
    uploadedBy: '',
    isExternal: true,
    externalUri: 'https://images.unsplash.com/photo-1687988999982-7bd925b9bdc5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=803&q=80'
  }
];
</script>

<template>
  <div class="section__container section--margin">
    <div class="section__container-title">
      <h1>Meine Dateien</h1>
    </div>
    <div v-for="[month, mappedFiles] in filesMap">
      <div class="section__container-subtitle">
        <p>{{ month }}</p>
      </div>
      <div class="section__container-list">
        <FileCard :file="file" v-for="file in mappedFiles" />
      </div>
    </div>
  </div>
</template>

<style scoped>
.section__container {
  color: #fff;
}

.section__container-title {
  padding-bottom: 1rem;
  font-family: var(--font-family);
  font-size: 1rem;
  line-height: 55px;
}

.section__container-subtitle {
  padding-bottom: 1rem;
  color: var(--color-title);
  font-family: var(--font-family);
  font-size: 0.9rem;
  line-height: 25px;
}

.section__container-list {
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  gap: 12px;
}

@media screen and (max-width: 1600px) {
  .section__container-list {
    grid-template-columns: repeat(4, 1fr);
  }
}

@media screen and (max-width: 962px) {
  .section__container-list {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media screen and (max-width: 768px) {
  .section__container-list {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media screen and (max-width: 414px) {
  .section__container-list {
    grid-template-columns: repeat(1, 1fr);
  }
}
</style>
