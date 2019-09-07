<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <NewsList/>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import NewsList from "@/components/NewsList.vue";

export default Vue.extend({
  name: "home",
  components: {
    NewsList
  }
});
</script>
