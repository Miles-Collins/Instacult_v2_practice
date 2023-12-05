<template>

<div class="container-fluid">
  <div class="row cult-bg align-items-center justify-content-center text-center">
    <div class="col-10 col-md-3">
      <button @click="scrollToCults" class="btn  w-100">
        Join A Cult?
      </button>
    </div>
    <div class="col-10 col-md-3">
      <button class="btn  w-100">
        Start A Cult?
      </button>
    </div>
  </div>
</div>
<div class="container">
  <section id="cults" class="row">
    <div v-for="cult in cults" :key="cult.id" class="col-12 col-md-6 offset-md-3 align-self-center my-2">
      <CultCard :cult="cult" />
    </div>
  </section>
</div>

</template>

<script>
import { computed, onMounted } from 'vue';
import {AppState} from '../AppState.js'
import {cultsService} from '../services/CultsService.js'
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import CultCard from '../components/CultCard.vue';

export default {
    setup() {
        onMounted(() => {
            getCults();
        });
        async function getCults() {
            try {
                await cultsService.getCults();
            }
            catch (error) {
                logger.error('[ERROR]', error);
                Pop.error(('[ERROR]'), error.message);
            }
        }
        return {
            cults: computed(() => AppState.cults),

            scrollToCults() {
              let cultsElem = document.getElementById("cults")
              let cult = cultsElem.offsetTop
              window.scrollTo(0, cult)
            }
        };
    },
    components: { CultCard }
}
</script>

<style scoped lang="scss">

.cult-bg {
  background-image: url(../assets/img/forest.png);
  height: 100dvh;
}

.btn {
color: #FDFDFD;
width: 313px;
height: 95px;
flex-shrink: 0;
border-radius: 13px;
border: 5px solid #781C14;
background: rgba(120, 28, 20, 0.00);
font-size: 40px;
font-family: Megrim;
}

.btn:hover {
  background-color: #781C14;
}

</style>
