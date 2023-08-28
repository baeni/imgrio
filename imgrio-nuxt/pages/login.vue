<script setup lang="ts">
import { onMounted } from "vue";
import { signInUser } from "../composables/useSupabase";

onMounted(() => {
  signInUser();
});
</script>
