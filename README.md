# Cadastro para Consultório
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

rep-test-project

# Sobre o Projeto

O Cadastro para consultório foi desenvolvido para atender ao Tech Challenge correspondente à FASE 4 do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP.

Este cadastro tem o intuito de armazenar, de forma simplificada, os médicos cadastrados para atendimento, os pacientes, e registrar os atendimentos médicos que são realizados.

A aplicação consiste em uma listagem de pacientes, representando os pacientes cadastrados. Uma listagem dos médicos cadastrados e um cadastro de atendimentos onde é possível pesquisar os atendimentos realizados por um médico, os atendimentos de um paciente ou a listagem de atendimentos em uma data específica. 

Para registrar um atendimento médico é preciso que tanto o médico quanto o paciente sejam cadastrados.

Mais informações sobre o projeto, assim como os requisitos do software, podem ser encontradas na documentação disponível [aqui](https://github.com/cyzop/blob/Master/PostechFiapAluraFase4/ConsultorioMedicoDoc.pdf)

Este repositório se refere ao back end da aplicação e caso desejado pode ser utilizado com o Swagger (disponível em modo Debug).

# 📋 Tecnologias utilizadas

- Microsoft .Net Core 7
- MongoDB
- XUnit 
 
# 🔧 Como executar o projeto (Back End)

## Baixando o código

```bash
# clonar o repositório
git clone https://github.com/cyzop/PostechFiapAluraFase4
```

## MongoDb

Pode utilizar tanto a instalação local do banco de dados (OnPremise), quanto a utilização do banco Cloud DBaaS.

No caso de banco DBaaS, além da configuração da ConnectionString é necessário cadastrar as variáveis de ambiente abaixo para armazenar o usuário e senha autenticação com o banco de dados:

PACIENTEDBSETTINGS__SECRET
MEDICODBSETTINGS__SECRET
ATENDIMENTODBSETTINGS__SECRET

### Para utilizar instalação local
- Instalar o banco NoSql MongoDB localmente
- Ajustar a ConnectionString no arquivo appsettings.json da api (ConnectionString e Secret) para os repositórios de Paciente, Médico e Atendimentos Médicos conforme o banco escolhido.

``` AppSettings OnPremise

Exemplo:
"PacienteDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "Database": "PacienteRepository",
  "Repository": "PacienteCollection"
},
"MedicoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "Database": "MedicoRepository",
  "Repository": "MedicoCollection"
},
"AtendimentoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "Database": "AtendimentoRepository",
  "Repository": "AtendimentoCollection"
}
```

### Para utilizar banco em nuvem
- Ajustar os parâmetros de configuração no arquivo appsettings.json da api (ConnectionString), configurando a url do servidor em núvem.

``` AppSettings DBaaS
Exemplo:
"PacienteDbSettings": {
  "ConnectionString": "mongodb+srv://{0}@mongocluster.3oa3jww.mongodb.net/",
  "Database": "PacienteRepository",
  "Repository": "PacienteCollection"
},
"MedicoDbSettings": {
  "ConnectionString": "mongodb+srv://{0}@mongocluster.3oa3jww.mongodb.net/",
  "Database": "MedicoRepository",
  "Repository": "MedicoCollection"
},
"AtendimentoDbSettings": {
  "ConnectionString": "mongodb+srv://{0}@mongocluster.3oa3jww.mongodb.net/",
  "Database": "AtendimentoRepository",
  "Repository": "AtendimentoCollection"
}
```

## Utilizando o Visual Studio Community 2022 para rodar o Backend localmente

- Abrir a solução do projeto (PosTech.Arquitetura.TechChallenge.sln) no VS
- Definir o projeto PosTech.Consultorio.Api como projeto para inicialização
- Iniciar o projeto com Depuração apertando o F5, para executar o projeto utilizando o Swagger


# Testes

Por possuir uma abordagem mais moderna e facilitando nosso trabalho com a descoberta de testes sem a necessidade de classes especiais, adotamos o framework xUnit que é uma das mais populares para realização de testes em .NET

## Testes Unitários

Utilizamos o xUnit para realizar os testes unitários em nossas projetos, onde cada método é testado isoladamente para garantir que funcione como esperado, independente do restante do sistema.

Abrindo a solução do projeto pelo Visual Studio, os projetos de teste unitários estão dentro da pasta Tests, em:
- PosTech.Consultorio.Tests
- PosTech.Consultorio.Api.Tests


## Testes de Integração 

Para garantir a correta integração e que as diferentes partes do sistema funcionem corretamente é essencial que se utilize os testes de integração.
Em nosso projeto, além dos testes unitários, também realizamos testes de integração com xUnit, desta forma é possível verificar se diferentes componentes do sistema funcionam corretamente juntos.

Os testes de integração com o banco de dados estão no projeto:
- PosTech.Consultorio.MongoDB.Tests


## Integrantes do Grupo de Trabalho (Grupo 36)
- Ricardo Moreira RM351064 
