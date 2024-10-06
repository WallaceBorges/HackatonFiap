<h1 align="center"> Health&Med - Hackaton .Net  </h1>

<p align="center">
  <img src="http://img.shields.io/static/v1?label=TESTES&message=%3E100&color=GREEN&style=for-the-badge"/>
   <img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

### Tópicos 

:small_blue_diamond: [Descrição do projeto](#descrição-do-projeto)

:small_blue_diamond: [Requisitos Funcionais](#requisitos-funcionais)

:small_blue_diamond: [Requisitos Não Funcionais](#requisitos-não-funcionais)

:small_blue_diamond: [Como clonar o projeto](#como-clonar-o-projeto)

:small_blue_diamond: [Como rodar o projeto](#como-rodar-o-projeto)

:small_blue_diamond: [Tecnologias](#tecnologias)

:small_blue_diamond: [Links](#links)

## Descrição do projeto 

<p align="justify">
  Esse projeto tem como objetivo criar um processo de agendamentos e consulta médicas, dando visibilidade para o médico é o paciente.
  As funcionalidades foram criadas para Operadora de Saúde Health&Med.
</p>

## Requisitos Funcionais

:heavy_check_mark: Poderá ser realizado o cadastro de médico e paciente, informando seus usuários e senhas.

:heavy_check_mark: O médico poderá cadastrar/editar horários disponíveis para atendimento.

:heavy_check_mark: O paciente poderá consultar os médicos disponíveis e realizar o agendamento da consulta.

:heavy_check_mark: O médico receberá um email com a consulta agendada.

## Requisitos Não Funcionais

:heavy_check_mark: O sistema deve garantir apenas uma marcação de consulta no horário.

:heavy_check_mark: O sistema deve validar conflitos de horários.

## Como clonar o projeto

No terminal, clone o projeto: 
```
git clone https://github.com/WallaceBorges/HackatonFiap.git
```

## Como rodar o projeto

No terminal, entre no diretório de Infra:
```
cd localDoProjeto\HackatonFiap\HealthAndMed.Infra.Data
```

Dentro de Infra, executa o comando abaixo para atualizar o banco de dados:
```
dotnet ef database update
```

Show, agora com o banco atualizado, vamos rodar nossa aplicação.
Primeiro entre na pasta da api:
```
cd localDoProjeto\HackatonFiap\HealthAndMed.Presentation
```

Agora execute o comando abaixo para rodar aplicação:
```
dotnet run
```

Pronto, agora a aplicação esta rodando. Segue o link do swagger:
```
http://localhost:5073/swagger/index.html
```

## Tecnologias

O projeto foi desenvolvido na versão .Net 8.0, com banco de dados SQL Server.

## Desenvolvedores/Contribuintes :arrow_forward:

| [<img src="https://avatars.githubusercontent.com/u/31574481?s=400&u=c256fa50a65feb93d2b537776c538304f1ba6efe&v=4" width=115><br><sub>Thiago Pereira</sub>](https://github.com/TSP17) |  [<img src="https://avatars.githubusercontent.com/u/17633740?v=4" width=115><br><sub>Gabriel Seles</sub>](https://github.com/SelesGabriel) |  [<img src="https://avatars.githubusercontent.com/u/46162170?v=4" width=115><br><sub>Wallace Borges</sub>](https://github.com/WallaceBorges) |[<img src="https://avatars.githubusercontent.com/u/77901483?v=4" width=115><br><sub>Simon Mendes</sub>](https://github.com/simpmendes) |
| :---: | :---: | :---: | :---: 

## Links

Seegue abaixo links com explicações do projeto

Parte 1
```
https://youtu.be/J-3eQnVFV04
```

Parte 2
```
https://youtu.be/ohIXEUEHk6k
```

