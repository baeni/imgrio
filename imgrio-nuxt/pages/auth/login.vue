<script setup lang="ts">
import { onMounted } from "vue";
import { signInUser } from "@/composables/useSupabase";

onMounted(async () => {
  await signInUser();
});
</script>
