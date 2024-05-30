import { defineConfig } from 'vite'
import UnoCSS from 'unocss/vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  server: {

    proxy: {
      
      "/api": {
        target: "http://127.0.0.1:8000",
        changeOrigin: true,
        secure:false
        // rewrite: (path) => path.replace(/^\/api/, ''),
      }
    }
  },
  plugins: [
    react(),
    UnoCSS(),
  ],
})
