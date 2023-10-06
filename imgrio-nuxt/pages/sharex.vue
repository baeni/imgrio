<script setup lang="ts">
import { Button } from '@/components/ui/button';
</script>

<template>
  <section class="container pt-28">
    <div>
      <p class="text-2xl font-bold mb-9">What is ShareX?</p>
      <p class="text-lg w-2/3">
        ShareX is a free, open-source and ad-free software for capturing screenshots and much more.
        For the perfect experience, simply follow the steps on the left side and start uploading to
        imgrio using ShareX!
      </p>

      <div class="grid grid-cols-3 gap-8 mt-24">
        <div
          class="bg-zinc-900 shadow-lg h-fit p-8 border border-zinc-500 border-opacity-20 rounded-3xl translate-y-14"
        >
          <p class="text-lg font-semibold text-zinc-400 mb-2">1 – Installation.</p>
          <p class="text-lg mb-9">
            First of all, you should install ShareX. Click the button below, then click on
            "Download" to get the lastest version. During setup, you can always click "Next" until
            the installation of ShareX is complete.
          </p>
          <a href="https://getsharex.com/" target="_blank"
            ><Button variant="secondary">Download ShareX</Button></a
          >
        </div>

        <div
          class="bg-zinc-900 shadow-xl h-fit p-8 border border-zinc-500 border-opacity-20 rounded-3xl"
        >
          <p class="text-lg font-semibold text-zinc-400 mb-2">2 – Configuration.</p>
          <p class="text-lg mb-9">
            Next up, we configure everything so that ShareX works with imgrio. Since we have already
            done most of this for you, all you have to do is download out configuration file.
          </p>
          <a href="/imgrio-sharex-config.sxcu" download
            ><Button variant="secondary">Download config</Button></a
          >
          <p class="text-lg mt-9">
            Perfect! Now, simply import the said configuration file into ShareX with a double click
            on it.
          </p>
        </div>

        <div
          class="bg-zinc-800 shadow-2xl h-fit p-8 border border-zinc-400 border-opacity-20 rounded-3xl translate-y-10"
        >
          <p class="text-lg font-semibold text-zinc-400 mb-2">3 – Almost there...</p>
          <p class="text-lg mb-9">
            With the configuration file imported, the only thing left is to insert your personal
            access token. Happy uploading!
          </p>
          <NuxtLink to="/dashboard/files"><Button>View Dashboard</Button></NuxtLink>
        </div>
      </div>
    </div>

    <!--    <div class="w-5/12">-->
    <!--      <p class="text-2xl font-bold mb-9">What is ShareX?</p>-->
    <!--      <p class="text-lg">-->
    <!--        ShareX is a free, open-source and ad-free software for capturing screenshots and much more.-->
    <!--        For the perfect experience, simply follow the steps on the left side and start uploading to-->
    <!--        imgrio using ShareX!-->
    <!--      </p>-->
    <!--    </div>-->

    <!--    <div class="grid grid-cols-2 gap-8">-->
    <!--      <div-->
    <!--        class="bg-zinc-900 shadow-lg h-fit p-12 border border-zinc-500 border-opacity-20 rounded-3xl translate-y-16"-->
    <!--      >-->
    <!--        <p class="text-lg font-semibold text-zinc-400 mb-2">1 – Installation.</p>-->
    <!--        <p class="text-lg mb-9">-->
    <!--          First of all, you should install ShareX. Click the button below, then click on "Download"-->
    <!--          to get the lastest version. During setup, you can always click "Next" until the-->
    <!--          installation of ShareX is complete.-->
    <!--        </p>-->
    <!--        <a href="https://getsharex.com/" target="_blank"-->
    <!--          ><Button variant="secondary">Download ShareX</Button></a-->
    <!--        >-->
    <!--      </div>-->

    <!--      <div-->
    <!--        class="bg-zinc-900 shadow-xl h-fit p-12 border border-zinc-500 border-opacity-20 rounded-3xl -translate-y-20"-->
    <!--      >-->
    <!--        <p class="text-lg font-semibold text-zinc-400 mb-2">2 – Configuration.</p>-->
    <!--        <p class="text-lg mb-9">-->
    <!--          Next up, we configure everything so that ShareX works with imgrio. Since we have already-->
    <!--          done most of this for you, all you have to do is download out configuration file.-->
    <!--        </p>-->
    <!--        <a href="/imgrio-sharex-config.sxcu" download-->
    <!--          ><Button variant="secondary">Download config</Button></a-->
    <!--        >-->
    <!--        <p class="text-lg mt-9">-->
    <!--          Perfect! Now, simply import the said configuration file into ShareX with a double click on-->
    <!--          it.-->
    <!--        </p>-->
    <!--      </div>-->

    <!--      <div-->
    <!--        class="bg-zinc-800 shadow-2xl h-fit p-12 border border-zinc-400 border-opacity-20 rounded-3xl -translate-y-32 translate-x-96"-->
    <!--      >-->
    <!--        <p class="text-lg font-semibold text-zinc-400 mb-2">3 – Almost there...</p>-->
    <!--        <p class="text-lg mb-9">-->
    <!--          With the configuration file imported, the only thing left is to insert your personal-->
    <!--          access token. Happy uploading!-->
    <!--        </p>-->
    <!--        <NuxtLink to="/dashboard/files"><Button>View Dashboard</Button></NuxtLink>-->
    <!--      </div>-->
    <!--    </div>-->
  </section>
</template>
