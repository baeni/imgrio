<script setup lang="ts">
import { onMounted } from "vue";
import { signOutUser } from "../composables/useSupabase";

onMounted(async () => {
  await signOutUser();
  navigateTo("/");
});
</script>
