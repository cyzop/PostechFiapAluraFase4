# Cadastro para Consultório
[![License](https://img.shields.io/badge/license-MIT-green)](./LICENSE)

rep-test-project

# Sobre o Projeto

O Cadastro para consultório foi desenvolvido para atender ao Tech Challenge correspondente à FASE 4 do curso ARQUITETURA DE SISTEMAS .NET COM AZURE da FIAP.

Este cadastro tem o intuito de armazenar, de forma simplificada, os médicos cadastrados para atendimento, os pacientes, e registrar os atendimentos médicos que são realizados.

A aplicação consiste em uma listagem de pacientes, representando os pacientes cadastrados. Uma listagem dos médicos cadastrados e um cadastro de atendimentos onde é possível pesquisar os atendimentos realizados por um médico, os atendimentos de um paciente ou a listagem de atendimentos em uma data específica. 

Para registrar um atendimento médico é preciso que tanto o médico quanto o paciente sejam cadastrados.

Mais informações sobre o projeto podem ser encontradas na documentação disponível [aqui](https://github.com/cyzop/blob/Master/PostechFiapAluraFase4/ConsultorioMedicoDoc.docx)

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


## Requisitos do Software

# Cadastro de Médicos

Requisito 1.1 - O sistema deve permitir o cadastro dos médicos que serão utilizado para registrar os atendimentos médicos
Critérios de aceite: Médico com informações válidas cadastrado no sistema

Requisito 1.2 - Para cadastrar um médico as informações de CRM (Registro no Conselho Regional de Medicina), Nome, Data de Nascimento e Data de Registro (CRM) são obrigatórios
Critérios de aceite: Médico com informações não preenchidas recusado pelo sistema

Requisito 1.3 - Um médico será considerado apto ao trabalho se tiver com idade entre 20 e 70 anos.
Critérios de aceite: Médico com idade fora da faixa válida recusado pelo sistema

Requisito 1.4 - O registro de CRM deverá obedecer ao padrão de formação que é, [numero]-[UF] onde:
		- [numero] é um valor numérico inteiro de até 7 posições
		- [UF] campo de duas letras que representam o estado onde foi registrado
		
                Exemplo: 1234567-RJ para um registro de número 1234567 realizado no Conselho Regional de Medicina do Estado do Rio de Janeiro

Critérios de aceite: Médico com CRM fora da especificação recusado pelo sistema

Requisito 1.5 - O sistema não poder cadastrar CRM duplicado 
Critérios de aceite: Novo Médico com CRM já cadastrado, recusado pelo sistema

Observação:
As informações publicas dos médicos, que incluem o CRM e Nome, podem ser verificada junto ao Conselho Federal de Medicina que disponibiliza o serviço através de um WebService.

Para maiores detalhes, vide link abaixo:
https://sistemas.cfm.org.br/listamedicos/informacoes

* Esta aplicação não possui integração com o WebService mencionado!

# Cadastro de Pacientes

Requisito 2.1 - O sistema deve permitir o cadastro dos pacientes que receberam ou receberão atendimento.
Critérios de aceite: Paciente com informações válidas cadastrado no sistema

Requisito 2.1 - Identificador, Nome do Paciente e Data de Nascimento são obrigatórios
Critérios de aceite: Paciente sem alguma destas informações será recusado pelo

Requisito 2.2 - Identificador, Nome do Paciente e Data de Nascimento são obrigatórios
Critérios de aceite: Paciente sem alguma destas informações será recusado pelo

Requisito 2.3 - O sistema não poder cadastrar Identificador de paciente duplicado 
Critérios de aceite: Novo Paciente com Identificador já cadastrado, recusado pelo sistema

Requisito 2.4 - Aceitar pacientes com idade entre 0 (recém nascido) e 110 anos
Critérios de aceite: Novo Paciente com idade fora da faixa, recusado pelo sistema

# Cadastro de Atendimentos Médicos Realizado

Requisito 3.1 - O sistema devera permitir o cadastro somente se o Médico, identificado pelo CRM, já estiver cadastrado como Médico.
Critérios de aceite: Registro do atendimento recusado pelo sistema

Requisito 3.2 - O sistema devera permitir o cadastro somente se o Paciente, identificado pelo campo Identificador, já estiver cadastrado como Paciente.
Critérios de aceite: Registro do atendimento recusado pelo sistema

Requisito 3.3 - O sistema devera permitir o cadastro somente com data de atendimento sendo do dia corrente ou anterior.
Critérios de aceite: Registro do atendimento com data futura recusado pelo sistema


## Integrantes do Grupo de Trabalho (Grupo 36)
- Ricardo Moreira RM351064 
