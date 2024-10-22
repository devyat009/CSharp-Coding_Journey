import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CadastroRequest } from './cadastro-request.model';

@Injectable({
  providedIn: 'root'
})

export class CadastroService {
  private apiUrl = 'http://localhost:5021/api/cadastro';

  constructor(private http: HttpClient) { }

  // Para obter todos os usuários
  obterTodos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Para cadastrar um novo usuário
  // Cadastra um novo usuário
  cadastrarService(cadastroRequest: CadastroRequest): Observable<string> {
    return this.http.post<string>(this.apiUrl, cadastroRequest);
  }
}
