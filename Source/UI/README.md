# Instruções

- Baixar o projeto
- Abrir o prompt de comando no path do projeto
- No prompt, rodar o comando 'npm-install' para instalação dos packages
- Ao término da instalação, rodar o comando 'ng-serve'
- A aplicação estará rodando na porta 'http://localhost:4200/'
- Usuário de acesso a aplicação é 'admin'


# Melhorias e pendências

- Endereço dos restaurantes utilizadno api google maps, localização mais fiel do restaurante.
- Alteração de imagem do restaurante, uma foto real do restaurante. 
- Sessão de comentários dos restaurantes, dando poder de influência na decisão de outro usuário.
- Job que zera no banco os dados da votação do dia.
- Criação e edição de usuários, usuários estão pré-definidos.
- Criação e remoção de restaurantes, restaurantes estão pré-definidos.


# Estrutura do projeto

# Telas

## Login
- Página de autenticação do usuário, caso usuário não exista ele pode cadatrar um novo
- Campo para inserir o usuário
- Ou Cadastro caso usuário não exista

## Restaurantes
- Página que contém todos os restaurantes, apresentando cada um com suas informações principai como:
- Foto do restaurante
- Nome do restaurante
- Número de votos
- Destacar o restaurante mais votado
- Distância(caso de tempo rs)

## Restaurante (detalhes)
- Página com os detalhes do restaurante
- Foto do restaurante
- Nome do restaurante
- Endereço
- Número de votos
- Lista de usuários votantes
- Votar
- Comentários
- opção de excluir??(votação para exclusão de restaurante)
- Distância(caso de tempo rs)

## Restaurante (adicionar)
- Página com formulário para inserção de um restaurante
- Foto do restaurante
- Nome do restaurante
- Endereço(api google maps?)

# Models

## Usuário
- Id usuário
- Nome de usuário
- Data do último voto
- Ja votou hoje

# Restaurante
- Id restaurante
- Nome do restaurante
- Endereço
- Numero de votos
- Lista de usuários votantes
- Comentários

# Comentário
- Id comentário
- Comentário
- Usuário