import { ref } from 'vue';
import { defineStore } from 'pinia';

export const useFilesStore = defineStore('filesStore', () => {
  const files = ref([
    {
      id: '1',
      name: 'Mercedes, Mercedes ...',
      type: '',
      size: '',
      uploadedAt: '7/9/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689170649735-a8c259851e2d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=688&q=80'
    },
    {
      id: '2',
      name: 'Cityyy',
      type: '',
      size: '',
      uploadedAt: '7/9/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689157611532-5cc61e96cc0f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80'
    },
    {
      id: '3',
      name: 'A Bird',
      type: '',
      size: '',
      uploadedAt: '7/9/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689198923121-c9df32e192eb?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw3fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '4',
      name: 'Castle of Doom oderso',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689244352181-708d13b4eb38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw5fHx8ZW58MHx8fHx8&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '5',
      name: 'Elephant baby boo',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1688048110668-f07715ee9156?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=733&q=80'
    },
    {
      id: '6',
      name: 'Mountains vac',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689085781839-2e1ff15cb9fe?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwyOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '7',
      name: 'Blonde Woman',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689058949660-9a77ea19e86d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzNHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '8',
      name: 'Church I guess?',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689082754713-636f853a615b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '9',
      name: 'Woman in Nature',
      type: '',
      size: '',
      uploadedAt: '3/23/2023 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689089376904-4755ada5058a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwzOXx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=500&q=60'
    },
    {
      id: '10',
      name: 'Korean school girl c.c',
      type: '',
      size: '',
      uploadedAt: '9/2/2022 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1689426308960-6917b05ab2d0?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80'
    },
    {
      id: '11',
      name: 'Illustration',
      type: '',
      size: '',
      uploadedAt: '9/2/2022 09:52:52 AM',
      uploadedBy: '',
      isExternal: true,
      externalUri:
        'https://images.unsplash.com/photo-1687988999982-7bd925b9bdc5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=803&q=80'
    }
  ]);

  return { files };
});
