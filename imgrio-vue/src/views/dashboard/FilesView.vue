<script setup lang="ts">
import FileCard from '../../components/FileCard.vue';

const files = [
  {
    name: 'imgrio',
    image: 'https://imgrio.com/data/files/aefb4f47-2f20-49e5-bcfe-5a09648a2808.png'
  },
  {
    name: 'baeni.de',
    image: 'https://imgrio.com/data/files/9497a7c0-2edd-4351-9800-32456842ac53.jpg'
  },
  {
    name: 'moovy',
    image: 'https://imgrio.com/data/files/574ebe95-960e-4c10-a847-be501fa0e986.png'
  },
  {
    name: 'Bird',
    image:
      'https://images.unsplash.com/photo-1689198923121-c9df32e192eb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw3fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
  },
  {
    name: 'The Castle',
    image:
      'https://images.unsplash.com/photo-1689244352181-708d13b4eb38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
  },
  {
    name: 'Mountains from 5th April',
    image:
      'https://images.unsplash.com/photo-1689085781839-2e1ff15cb9fe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    name: 'Blonde Women',
    image:
      'https://images.unsplash.com/photo-1689058949660-9a77ea19e86d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzNHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    name: 'Nature with Woman',
    image:
      'https://images.unsplash.com/photo-1689089376904-4755ada5058a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOXx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  },
  {
    name: 'Church I guess?',
    image:
      'https://images.unsplash.com/photo-1689082754713-636f853a615b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
  }
];
</script>

<template>
  <div class="section__container section--margin">
    <div class="section__container-title">
      <h1>Meine Dateien</h1>
    </div>
    <div class="section__container-subtitle">
      <p>02.07.2023</p>
    </div>
    <div class="section__container-list">
      <FileCard :file="file" v-for="file in files" />
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
