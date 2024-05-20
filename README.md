# Cadastro para Consultório
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

rep-test-project

# Sobre o Projeto

O Cadastro para consultório foi desenvolvido para atender ao Tech Challenge correspondente à FASE 4 do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP.

Este cadastro tem o intuito de armazenar, de forma simplificada, os médicos cadastrados para atendimento, os pacientes, e registrar os atendimentos médicos que são realizados.

A aplicação consiste em uma listagem de pacientes, representando os pacientes cadastrados. Uma listagem dos médicos cadastrados e um cadastro de atendimentos onde é possível pesquisar os atendimentos realizados por um médico, os atendimentos de um paciente ou a listagem de atendimentos em uma data específica. 

Para registrar um atendimento médico é preciso que tanto o médico quanto o paciente sejam cadastrados.

Este repositório se refere ao back end da aplicação e caso desejado pode ser utilizado com o Swagger (disponível em modo Debug).

# Requisitos

O documento com o levanto de requisitos do software e seus critérios de aceite podem ser encontradas no arquivo "ConsultorioMedicoDoc.pdf" na raiz do projeto ou por [aqui](https://github.com/cyzop/PostechFiapAluraFase4/blob/master/ConsultorioMedicoDoc.pdf)

# 📋 Tecnologias utilizadas

- Microsoft .Net Core 7
- MongoDB
- XUnit 

## Banco de Dados

Em função do propósito da aplicação representar uma associação entre diferentes entidades, como Médicos, Pacientes e Atendimentos, poderia ser utilizado um banco de dados relacional, porém optamos por seguir uma abordagem mais desacoplada/flexível utilizando um banco de dados NoSql com repositórios distintos.

Este decisão facilita a evolução dos sistema para entrega em microserviços mais atômicos, isolados e autocontidos. Também permite que seja aplicada camadas de segurança distintas entre os repositórios e a adoção de segurança adequada à cada um dele. Lembrando que os prontuários de atendimentos são representam dados sensíveis e devem estar bem protegidos.

## Framework de Testes

Para garantir a correta integração e que as diferentes partes do sistema funcionem corretamente é essencial que se utilize os testes de integração.
Em nosso projeto, além dos testes unitários, também realizamos testes de integração com xUnit, desta forma é possível verificar se diferentes componentes do sistema funcionam corretamente juntos.

# Arquitetura do Projeto

Para melhorar organização do código, adotamos o uso de diretórios e dentro de cada um os projetos pertinentes. 
Estes diretórios e projetos estão organizados da seguinta maneira:

📁API
 - PosTech.Consultorio.Api
   
📁Controller
 - PosTech.Consultorio.Controllers
   
📁Entity
 - PosTech.Consultorio.Enities
   
📁Gateway
 - PosTech.Consultorio.Gateways
   
📁Interface
 - PosTech.Consultorio.Interfaces
   
📁Presenter
 - PosTech.Consultorio.Adapters
 - PosTech.Consultorio.DAO
   
📁Resources
 - PosTech.Consultorio.Resource.NoSql
   
📁Tests
 - PosTech.Consultorio.MongoDB.Tests
 - PosTech.Consultorio.Tests
 - PosTech.Consultorio.Api.Tests
   
📁Tests
  - PosTech.Consultorio.UseCases
    
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
