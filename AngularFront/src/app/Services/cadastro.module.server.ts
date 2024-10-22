import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';

import { CadastroModule } from './cadastro.module';
import { CadastroComponent } from './cadastro.component';

@NgModule({
  imports: [
    CadastroModule,
    ServerModule,
  ],
  bootstrap: [CadastroComponent],
})
export class AppServerModule { }
