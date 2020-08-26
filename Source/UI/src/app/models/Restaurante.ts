import { Usuario } from "./Usuario";
import { Comentario } from "./Comentario";

export class Restaurante {
    id: string;
    nome: string;
    endereco: string;
    votos: number;
    usuariosVotantes: Array<Usuario>;
    comentarios: Array<Comentario>;
    escolhido: boolean = false;
    dataUltimaEscolha: Date | null;
    votadoNaSemana: boolean;
    
    constructor(nome: string, endereco: string, votos: number, usuariosVotantes: Usuario[], comentarios: Comentario[]) {
        this.nome = nome;
        this.endereco = endereco;
        this.votos = votos;
        this.usuariosVotantes = usuariosVotantes;
        this.comentarios = comentarios;
    }
}