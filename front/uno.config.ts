// uno.config.ts
import { defineConfig, presetUno, presetIcons } from 'unocss'

export default defineConfig({
  // ...UnoCSS options
  presets: [presetUno(), presetIcons(
    {
      extraProperties: {
        display: 'inline-block',
        width: '1.2em',
        height: '1.2em',
        
      }
    }
  )]
})
