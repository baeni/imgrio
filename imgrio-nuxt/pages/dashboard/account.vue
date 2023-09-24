<script setup lang="ts">
import { apiClient } from "@/axios.conf";
import { Label } from "@/components/ui/label"
import { Button } from "@/components/ui/button"
import {
  AlertDialog,
  AlertDialogAction, AlertDialogCancel,
  AlertDialogContent, AlertDialogDescription,
  AlertDialogFooter, AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger
} from "@/components/ui/alert-dialog";

async function handleGenerateToken() {
  const response = (await apiClient.get('me/token')).data;
  copyToClipboard(response);
}

function copyToClipboard(text: string) {
  navigator.clipboard.writeText(text);
}
</script>

<template>
  <section class="container pt-28">
    <p class="text-2xl font-bold mb-9">Account</p>
    
    <AlertDialog>
      <AlertDialogTrigger>
        <Button class="hover:bg-red-500" variant="secondary" size="sm">Generate new access token</Button>
      </AlertDialogTrigger>
      <AlertDialogContent>
        <AlertDialogHeader>
          <AlertDialogTitle>Are you sure?</AlertDialogTitle>
          <AlertDialogDescription>
            <p>Generating a new access token will immediately invalidate your previous one. Perform with caution!</p>
          </AlertDialogDescription>
        </AlertDialogHeader>
        <AlertDialogFooter>
          <AlertDialogCancel>Cancel</AlertDialogCancel>
          <AlertDialogAction class="hover:bg-red-500 hover:text-foreground" @click="async () => await handleGenerateToken()">Yes, generate new</AlertDialogAction>
        </AlertDialogFooter>
      </AlertDialogContent>
    </AlertDialog>
  </section>
</template>
