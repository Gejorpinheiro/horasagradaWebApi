export class Usuario {
    id: number;
    nome: string;
    dataVotacao: Date | null;
    
    public get votouHoje() : boolean {
        if (this.dataVotacao == null)
            return false;
            
        return (this.dataVotacao.toLocaleDateString()) == (new Date().toLocaleDateString());
    }

    constructor(id, nome, dataVotacao) {
        this.id = id;
        this.nome = nome;
        this.dataVotacao = dataVotacao;
    }
}