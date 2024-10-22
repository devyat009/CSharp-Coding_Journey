import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CadastroRoutingModule } from './cadastro-routing.module';
import { CadastroComponent } from './cadastro.component';
import { HttpClientModule } from '@angular/common/http';

  
@NgModule({
  declarations: [
    CadastroComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    CadastroRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [CadastroComponent]
})
export class CadastroModule { }
