import { Component } from '@angular/core';
import { CadastroService } from './cadastro.service';
import { CadastroRequest } from './cadastro-request.model';

@Component({
  selector: 'app-cadastro',
  template: '<app-cadastro></app-cadastro>',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  cadastroRequest: CadastroRequest = {
    nome: '',
    idade: 0,
    datanascimento: '',
    cpf: '',
    cep: ''
  };

   constructor(private cadastroService: CadastroService) { }

  cadastrarComponent() {
    this.cadastroService.cadastrarService(this.cadastroRequest).subscribe(
      response => {
        console.log(this.cadastroService)
        console.log(response);
        alert("Cadastro realizado com sucesso!"); 
        // Aqui você pode lidar com a resposta, exibir uma mensagem de sucesso, etc.
      },
      error => {
        console.error(error);
        alert("Erro ao realizar o cadastro.");
        // Aqui você pode lidar com erros
      }
    );
  }

  obterTodos() {
    this.cadastroService.obterTodos().subscribe(
      users => {
        console.log(users);
        // Aqui você pode lidar com a lista de usuários
      },
      error => {
        console.error(error);
      }
    );
  }
}
