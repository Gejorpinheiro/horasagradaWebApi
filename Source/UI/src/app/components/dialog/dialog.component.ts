import { Component, Inject, OnInit} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Usuario } from 'src/app/models/Usuario';
import { Restaurante } from 'src/app/models/Restaurante';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit{
  restauranteForm = new FormGroup({
    nome: new FormControl(this.data.restaurante.nome, Validators.required),
    endereco: new FormControl(this.data.restaurante.endereco, Validators.required)
  });

  modo = 'Ver';
  bloqueiaVoto = false;
  
  votos: number;
  usuario: Usuario;
  usuariosVotantes: Array<Usuario> = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any
    , private dialogRef:MatDialogRef<DialogComponent>
  ) { }

  ngOnInit(): void {
    this.modo = this.data.modo;
    this.votos = this.data.restaurante.votos;
    this.usuario = this.data.usuario;
    this.usuariosVotantes = this.data.restaurante.usuariosVotantes;
    
    this.setupForm();
    this.disableVoto();
  }

  setupForm() {
    if (this.modo == 'Ver') {
      this.restauranteForm.controls["nome"].disable();
      this.restauranteForm.controls["endereco"].disable();
    }
  }

  salvar() {
    if (this.modo == 'Editar') {
      this.data.restaurante.nome = this.restauranteForm.controls["nome"].value;
      this.data.restaurante.endereco = this.restauranteForm.controls["endereco"].value;
    }
    
    if (this.modo == 'Ver') {
      this.data.restaurante.votos = this.votos;
      this.usuario.dataVotacao = new Date();
      this.data.restaurante.usuariosVotantes = this.usuariosVotantes;
    }

    if (this.modo == 'Novo') {
      let novoRestaurante = new Restaurante(
        this.restauranteForm.controls["nome"].value,
        this.restauranteForm.controls["endereco"].value,
        0,
        null,
        null
      );

      this.data.restaurante = novoRestaurante;
    }

    this.dialogRef.close(this.data.restaurante);
  }

  votar() {
    if (!this.usuario.votouHoje) {
      this.votos++;
      this.bloqueiaVoto = true;
      this.usuariosVotantes.push(this.usuario);
    } 
  }

  disableVoto() {
    if (this.data.votacaoEncerrada || this.data.restaurante.votadoNaSemana || this.usuario.votouHoje) {
      this.bloqueiaVoto = true;
    }
  }
}
