<template>

<div v-if="cult" class="container-fluid">
  <div class="row cover-img">

    <div class="col-12">
      <i class="fs-1 mdi mdi-close rounded-circle border-danger"></i>
    </div>
    <div class="col-12">
      <p class="cult-title fs-1">{{ cult.name }}</p>
      <button class="btn btn-danger px-5">Join</button>
    </div>
  </div>
  <div class="row justify-content-between text-light p-5">
    <div class="col-4">
      <p>
        {{ cult.description }}
      </p>
    </div>
    <div class="col-5 text-start">
      <p class="fs-1 cult-title">Cult Leader</p>
      <img class="img-fluid rounded-circle mb-5" :src="cult.leader.picture" alt="">
      <p class="fs-2 cult-title">Members: <span>{{ cultist.length }}</span></p>
      <div v-if="cultist" v-for="cultist in cultist" :key="cultist.id" class="row">
        <div class="col-2">
          <img class="img-fluid rounded-circle" :src="cultist.picture" :title="cultist.name" alt="">
        </div>
      </div>
    </div>
  </div>
</div>

</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { cultsService } from '../services/CultsService.js';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';


export default {



setup() {
  const route = useRoute();

  onMounted(() => {
    getCultById();
    getCultist();
  })

  async function getCultById() {
    try {
      cultsService.getCultById(route.params.cultId)
    } catch (error) {
      logger.error('[ERROR]',error)
      Pop.error(('[ERROR]'), error.message)
    }
  }

  async function getCultist() {
    try {
      cultsService.getCultist(route.params.cultId)
    } catch (error) {
      logger.error('[ERROR]',error)
      Pop.error(('[ERROR]'), error.message)
    }
  }


  return {
    cult: computed(() => AppState.activeCult),
    cultist: computed(() => AppState.cultist),
    coverImage:computed(() => `url(${AppState.activeCult?.coverImg})`),

}}}
</script>

<style scoped>

.cover-img {
  height: 45dvh;
  background-image: v-bind(coverImage);
  background-position: center;
  background-size: cover;
}

.cult-title {
color: #781C14;
text-shadow: 1px 1px 5px rgb(255, 255, 255);
font-family: Amarante;
font-size: 64px;
font-style: normal;
font-weight: 400;
line-height: normal;
}

</style>
