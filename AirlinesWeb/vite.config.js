import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import devtools from "vite-plugin-vue-devtools"

export default defineConfig({
    plugins: [vue(), devtools()],
    server: {
        port: 8080,
        open: true,
        host: true
    },
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url)),
            '@assets': fileURLToPath(new URL('./src/assets', import.meta.url)),
            '@components': fileURLToPath(new URL('./src/components', import.meta.url)),
            '@layouts': fileURLToPath(new URL('./src/layouts', import.meta.url)),
            '@pages': fileURLToPath(new URL('./src/pages', import.meta.url)),
            '@stores': fileURLToPath(new URL('./src/stores', import.meta.url)),
            '@utils': fileURLToPath(new URL('./src/utils', import.meta.url)),
            '~bootstrap': fileURLToPath(new URL('./node_modules/bootstrap', import.meta.url)),
        }
    },
    build: {
        outDir: process.env.OUTPUT_DIR
    }
})
