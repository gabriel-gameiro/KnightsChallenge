<template>
  <div>
    <!-- Para melhor reutilizacao, o header eh um componente a parte e fixo do site -->
    <HeaderComponent/>
    <HomePage/>
  </div>
</template>

<script>
import HeaderComponent from './components/HeaderComponent.vue';
import HomePage from './components/HomePage.vue';


export default {
  name: 'App',
  components: {
    HomePage,
    HeaderComponent
  }
}
</script>
