<template>
  <div class="news-list">
    <div class="news-item" v-for="newsItem in news" :key="newsItem.id">
      <div class="row">
        <div class="col">{{newsItem.title}}</div>
        <div class="col">{{new Date(newsItem.publishDate)}}</div>
      </div>
      <div>{{newsItem.content}}</div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { httpGet } from "@/helpers/httpHelper";
import urls from "../constants/urls";

export default Vue.extend({
  name: "NewsList",
  data() {
    return {
      news: []
    };
  },
  created(): void {
    this.getNews();
  },
  methods: {
    getNews(): void {
      httpGet(urls.getNews).then((response: any) => {
        this.news = response;
      });
    }
  }
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.news-list {  
  .news-item {
    margin-bottom: 2rem;
  }
}
</style>
