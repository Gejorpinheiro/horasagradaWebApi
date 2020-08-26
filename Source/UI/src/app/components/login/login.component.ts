import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UsuarioService } from "../../services/usuario.service";
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  loginForm = new FormGroup({
    usuario: new FormControl('', Validators.required)
  });

  cadastroForm = new FormGroup({
    novoUsuario: new FormControl('', Validators.required)
  });

  input: string;
  login: boolean = true;
  
  constructor(
    private router: Router,
    private snackBar: MatSnackBar,
    private usuarioService: UsuarioService
  ) {}


  logar() {
    this.input = this.loginForm.controls["usuario"].value;

    this.usuarioService.getUsuario(this.input.trim())
      .subscribe(
        usuario => {
          this.usuarioService.salvaUsuarioLogado(usuario);
          this.router.navigate(['restaurantes']);
        },
        error => {
          this.trataErro(error.status);
        }
      )
  }

  cadastrar() {
    this.input = this.cadastroForm.controls["novoUsuario"].value;
    
    this.usuarioService.postUsuario(this.input.trim())
      .subscribe(
        usuario => {
          this.usuarioService.salvaUsuarioLogado(usuario);
          this.router.navigate(['restaurantes']);
        },
        error => {
          this.trataErro(error.status);
        }
      );
  }

  toggleCadastro() {
    this.loginForm.controls["usuario"].setValue(null);
    this.loginForm.controls["usuario"].markAsUntouched();
    this.cadastroForm.controls["novoUsuario"].setValue(null);
    this.cadastroForm.controls["novoUsuario"].markAsUntouched();

    this.login = !this.login;
  }

  trataErro(errStatus: number) {
    let mensagemErro = '';

    switch (errStatus) {
      case 204:
        mensagemErro = 'Entrada inválida.'
        break;
      case 404:
        mensagemErro = 'Usuário não encontrado.'
        break;
      case 409:
        mensagemErro = 'Este usuário já existe.'
        break;
      default:
        mensagemErro = 'Algo deu errado :('
        break;
    }

    this.snackBar.open(mensagemErro, 'x', {
      duration: 2000
    });
  }
}
