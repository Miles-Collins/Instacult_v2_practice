<template>

<div  class="row bg-dark rounded-card text-light">
  <div class="d-flex p-3">
    <div class="col-2">
      <img class="img-fluid rounded-circle" :src="cult.leader.picture" alt="">
    </div>
    <div class="col-10 d-flex align-items-center">
      <p class="ps-3 m-0 fs-1 text-cult">{{ cult.leader.name }}</p>
    </div>
  </div>
  <div class="col-12 p-0">
    <img class="img-fluid" :src="cult.coverImg" alt="">
  </div>
  <div class="col-12">
    <p class="m-0 fs-2 py-3 ps-4 text-cult">
      {{ cult.name }}
    </p>
    <p class="fs-6 py-3 ps-4 text-cult-description">{{ cult.description }}</p>
  </div>
  <div class="col-12 text-end pb-4">
      <router-link :to="{name: 'CultDetails', params:{cultId: cult.id}}">
        <button class="btn btn-danger text-light p-3 w-50 w-md-25 text-cult-description">
          See More
        </button>
    </router-link>
  </div>
</div>

</template>

<script>
import { Cult } from '../models/Cult.js';
import { cultsService } from '../services/CultsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';


export default {
props: {cult: {type: Cult, required: true}},


setup() {



  return {

}}}
</script>

<style scoped>

.rounded-card {
border-radius: 19px;
border: 1px solid #5F0202;
background-color: #3F3B3B;
box-shadow: 5px 5px 10px 2px rgba(123, 0, 0, 0.48);
}

@font-face {
  font-family: Megrim;
  src: url(../assets/Fonts/Megrim-Regular.ttf);
}

@font-face {
  font-family: Amarante;
  src: url(../assets/Fonts/Amarante-Regular.ttf);
}

.text-cult {
color: #FFF;
font-family: Megrim;
font-style: normal;
font-weight: 500;
line-height: normal;
}

.text-cult-description {
color: #FFF;
font-family: Amarante;
font-size: 20px;
font-style: normal;
font-weight: 400;
line-height: normal;
}

.btn {
  border-radius: 3px;
background: #781C14 !important;
}

</style>
