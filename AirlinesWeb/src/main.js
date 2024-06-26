import { createApp } from 'vue'
import { createPinia } from 'pinia'
import router from '@utils/router'
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate'
import { plugin, defaultConfig } from "@formkit/vue"
import App from '@/App.vue'
import 'bootstrap'
import 'bootstrap-icons/font/bootstrap-icons.css'
import '@assets/app.scss'

const app = createApp(App)

const pinia = createPinia()
pinia.use(piniaPluginPersistedstate)

app.use(router)
app.use(plugin, defaultConfig)
app.use(pinia)

app.mount('#app')
