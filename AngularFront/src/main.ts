import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserModule} from '@angular/platform-browser';
import { CadastroModule } from './app/Services/cadastro.module';

platformBrowserDynamic().bootstrapModule(CadastroModule, {
  ngZoneEventCoalescing: true
})
  .catch(err => console.error(err));
