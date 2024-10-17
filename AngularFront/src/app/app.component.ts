import { HttpClient } from '@angular/common/http';
import {HttpClientModule} from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { CepDictionary } from './cepDictionary';

import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


// implments onInit usado para teste rapido de função
export class AppComponent implements OnInit {
  title = 'AngularFront';
  http = inject(HttpClient);
  url = 'http://localhost:5021';
  //cep$: CepDictionary[] = [];
  cep$: CepDictionary | null = null;
  //cep$: CepDictionary[] | null = null;
  ngOnInit(): void {
    this.obterCep("27010000");
  }
  //throw new Error('Metodo não implementado')
  
  obterCep(cep: string) {
    
    const payload = { cep }; // Formata o corpo da requisição
    
    this.http.post<CepDictionary>(`${this.url}/apicep`, payload)
      .subscribe({
        next: (response) => {
          this.cep$ = response;
          console.log('Resposta:', response);
          // Aqui você pode fazer algo com a resposta, como armazenar ou exibir
        },
        error: (error) => {
          this.cep$ = null;
          console.error('Erro mizeravel:', error);
        }
      });
  }

}
