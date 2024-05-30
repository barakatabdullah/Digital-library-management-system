import { defineConfig } from 'vite'
import UnoCSS from 'unocss/vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  resolve: { alias: { '@': '/src' } },
  server: {
    proxy: { 
      "/api": {
        target: "http://localhost:5199",
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
