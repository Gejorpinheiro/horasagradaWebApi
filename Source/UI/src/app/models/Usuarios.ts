import { Usuario } from "./Usuario";

export const ListaUsuarios: Array<Usuario> = [
    new Usuario(1, 'admin', null),
    new Usuario(2, 'claudio', new Date()),
    new Usuario(3, 'pedro', new Date()),
    new Usuario(4, 'rita', new Date('2020/07/15')),
    new Usuario(5, 'elisa', new Date()),
    new Usuario(6, 'joao', null),
    new Usuario(7, 'Tiago', null),
    new Usuario(8, 'Beatriz', new Date())
];