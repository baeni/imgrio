<script setup lang="ts">
import { onMounted } from 'vue';
import { signInUser } from '@/composables/useSupabase';

onMounted(() => {
  setTimeout(async () => {
    await signInUser();
  });
});
</script>
