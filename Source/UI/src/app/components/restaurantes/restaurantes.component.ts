import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from "../dialog/dialog.component";
import { Restaurante } from 'src/app/models/Restaurante';
import { UsuarioService } from 'src/app/services/usuario.service';
import { RestauranteService } from 'src/app/services/restaurante.service';
import { Usuario } from 'src/app/models/Usuario';
import { Router } from '@angular/router';
import { ListaUsuarios } from 'src/app/models/Usuarios';

@Component({
  selector: 'app-restaurantes',
  templateUrl: './restaurantes.component.html',
  styleUrls: ['./restaurantes.component.css']
})
export class RestaurantesComponent implements OnInit {
  listaRestaurantes: Array<Restaurante>;

  usuario: Usuario;

  constructor(
    public dialog: MatDialog,
    private router: Router,
    private usuarioService: UsuarioService,
    private restauranteService: RestauranteService
  ) { }

  ngOnInit(): void {
    this.obterUsuarioLogado();
    this.populaRestaurantes();
  }
  
  populaRestaurantes() {
    this.restauranteService.getRestaurantes()
      .subscribe(
        restaurantes => {
          this.listaRestaurantes = restaurantes;
        },
        error => {
          console.log(error);
        })
  }

  detalhar(idRestaurante: string, modo: string): void {
    this.restauranteService.getRestaurante(idRestaurante)
      .subscribe(restaurante => {

        if (restaurante == null) {
          return;
        }

        let entradaDialog = {
          restaurante: restaurante,
          modo: modo,
          usuario: this.usuario,
          votacaoEncerrada: (this.listaRestaurantes.findIndex(r=> r.escolhido) > -1)
        }

        this.abrirDialog(entradaDialog);
      },
      err => {
        console.log(err);
      });
  }

  adicionar() {
    let entradaDialog = {
      restaurante: Restaurante,
      modo: 'Novo',
      usuario: this.usuario
    }

    this.abrirDialog(entradaDialog);
  }

  abrirDialog(entradaDialog) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '550px',
      data: entradaDialog
    });

    dialogRef.afterClosed().subscribe((result: Restaurante) => {
      if (result != undefined) {
        this.atualizaRestaurantes(result, entradaDialog.modo)
      }
    });
  }

  atualizaRestaurantes(result: Restaurante, modo: string) {
    switch (modo) {
      case 'Novo':
        
        this.restauranteService.addRestaurante(result)
        .subscribe(res => {
          this.listaRestaurantes.push(res);
        }, err => console.log(err));

        break;
      case 'Editar':
        let index = this.listaRestaurantes.findIndex(r => r.id == result.id);

        this.restauranteService.updateRestaurante(result)
        .subscribe(res => {
          if (index > -1) {
            this.listaRestaurantes[index] = res;
          }
        }, err => console.log(err));

        break;
      case 'remover':
    
        break;
    }
  }

  obterUsuarioLogado() {
    this.usuarioService.usuarioLogado$.subscribe(data => {
      this.usuario = data;

      if (this.usuario == undefined) {
        this.router.navigate(['login']);
      }
    })
  }

  encerrarVotacao() {
    let maisVotado = this.listaRestaurantes[0];

    this.listaRestaurantes.map((r) => {
      if (r.votos > maisVotado.votos) {
        maisVotado = r;
      }
    });

    this.listaRestaurantes.find(r=> r == maisVotado).escolhido = true;
    this.listaRestaurantes.find(r=> r == maisVotado).dataUltimaEscolha = new Date();
  }

  zerarVotacao() {
    let semana = this.rangeDaSemana();

    this.listaRestaurantes.map(r => {
      r.votos = 0;
      r.escolhido = false;
      r.usuariosVotantes = [];
      
      r.votadoNaSemana = this.disableVotadoNaSemana(r, semana);
    });

    ListaUsuarios.map(u => {
      u.dataVotacao = null;
    });
  }

  rangeDaSemana() : any {
    let hoje = new Date;
    let primeiroDia = hoje.getDate() - hoje.getDay();
    let ultimoDia = primeiroDia + 6;

    let inicioSemana = new Date(hoje.setDate(primeiroDia)).toLocaleDateString();
    let fimSemana = new Date(hoje.setDate(ultimoDia)).toLocaleDateString();

    return { 
      dataInicio: inicioSemana,
      dataFim: fimSemana
    }
  }

  disableVotadoNaSemana(restaurante: Restaurante, semana: any){
    if (restaurante.dataUltimaEscolha != null && semana != null) {
      if (restaurante.dataUltimaEscolha.toLocaleDateString() >= semana.dataInicio && restaurante.dataUltimaEscolha.toLocaleDateString() <= semana.dataFim) {
        console.log(restaurante.nome + ' votado na semana');
        return true;
      }
      else {
        return false;
      }
    }
  }

  manipulaCardClass(r: Restaurante) : string{
    let classe = '';

    classe += r.escolhido ? 'purple-border ' : '';
    classe += r.votadoNaSemana ? 'disabled ' : '';

    return classe;
  }
}
