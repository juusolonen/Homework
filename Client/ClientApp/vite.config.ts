import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import { fileURLToPath } from 'url';
import fs from 'fs';
import path from 'path';
import type { ServerOptions } from 'https';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    warmup: {
      clientFiles: [
        './src/App.tsx',
        './src/main.tsx',
        './src/Components/ProductListing.tsx',
        './src/Components/ProductCard.tsx',
      ]
   },
    port: 5002,
    https: (() => {
      try {
        // Try to read certificates, fall back to HTTP in case of error
        const homePath = process.env.HOME || '';
        const keyPath = path.resolve(homePath, '.aspnet/https/devcert.key');
        const certPath = path.resolve(homePath, '.aspnet/https/devcert.pem');
        
        if (fs.existsSync(keyPath) && fs.existsSync(certPath)) {
          return {
            key: fs.readFileSync(keyPath),
            cert: fs.readFileSync(certPath),
          } as ServerOptions;
        } else {
          console.warn('HTTPS certificates not found, falling back to HTTP');
          return undefined;
        }
      } catch (e) {
        console.warn('Error reading HTTPS certificates:', e);
        return undefined;
      }
    })(),
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:5001', 
        secure: false,
        changeOrigin: true
      }
    }
  },
  build: {
    modulePreload: true,
    outDir: '../wwwroot',
    emptyOutDir: true,
    rollupOptions: {
      output: {
        manualChunks: {
          vendor: ['react', 'react-dom'],
        },
        // Ensure assets are properly hashed and placed in the right directories
        assetFileNames: 'assets/[name].[hash].[ext]',
        chunkFileNames: 'js/[name].[hash].js',
        entryFileNames: 'js/[name].[hash].js'
      },
    },
  },
  base: '/',
})
