# FiapTechChallengeFase1

Desafio Tech Challenge Fase 1 da FIAP do curso de Arquitetura de Sistemas .Net

Sou Rafael Wandenkolk, Grupo 75 - rm359336


#Orientações:

O projeto foi desenvolvido com entity framework, 
se atentar com a string de conexão do banco de dados dentro do projeto:
FIAP.Grupo75.Contacts.API

Após isso, rodar o comando update-database apontando para o projeto:
FIAP.Grupo75.Contacts.Infra.Data

Após rodar o projeto, primeiro precisa autenticar com a chamada do método LoginUser,
utilizar o usuário e senha:

Usuário: admin@localhost
Senha: Grupo75#2024

Adicionar o usuário e senha, copiar o token gerado, clicar no botão authorize,
adicionar "bearer tokenCopiado" no campo e clicar no botão authorize.

É possível criar outros usuário através do método CreateUser.

O token dura 10 minutos.