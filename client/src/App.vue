<template>
  <header>
    <Navbar />
  </header>
  <main>
    <section class="main-page"></section>
    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}

header {
  background-color: #1a1919;
}

main {
  background-color: #1a1919;
}

</style>
