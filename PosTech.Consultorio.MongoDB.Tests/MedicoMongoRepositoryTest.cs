﻿using Bogus;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.MongoDB.Tests.MongoDB;
using PosTech.Consultorio.Resource.NoSql.Model;
using PosTech.Consultorio.Resource.NoSql.Repositories;

namespace PosTech.Consultorio.MongoDB.Tests
{
    public class MedicoMongoRepositoryTest : MedicoMongoDBTest
    {
        public IMedicalDoctorRepository repositorioMedicos;
        private readonly Faker _faker;

        public MedicoMongoRepositoryTest()
        {
            base.TestInitialize();
            repositorioMedicos = new MedicoRepositoryMongo(_mongoDataBase);
            _faker = new Faker();

            //initialize with 5 register
            collectionMedico.InsertMany(new List<MedicoModel>() {
               new MedicoModel("10001-RJ", DateTime.Today.AddYears(-10), "Medico 1", DateTime.Today.AddYears(-25), "Clinico"),
               new MedicoModel("10002-DF", DateTime.Today.AddYears(-10),"Medico 2", DateTime.Today.AddYears(-26), "Pediatra"),
               new MedicoModel("10003-BH", DateTime.Today.AddYears(-10),"Medico 3", DateTime.Today.AddYears(-27), "Osteopata"),
               new MedicoModel("10004-SP", DateTime.Today.AddYears(-10),"Medico 4", DateTime.Today.AddYears(-28), "Geriatra"),
               new MedicoModel("10005-RS", DateTime.Today.AddYears(-10),"Medico 5", DateTime.Today.AddYears(-29), "Urologista")
            });
        }

        ~MedicoMongoRepositoryTest() => base.TestCleanup();


        [Fact(DisplayName = "Validando inclusão de medico no banco Mongo")]
        [Trait("PacienteModel", "Validando inclusão de novo medico no banco de dados")]
        public void Create_Should_Return_SameCreated()
        {
            //Arrange
            var crm = $"{_faker.Random.Number(999999)}-RJ";
            var especialid = _faker.Person.Email;
            var nome = _faker.Name.FullName();

            var medicoEntity = new MedicoEntity(nome, DateTime.Today.AddYears(-30), new CRMEntity(crm), DateTime.Today.AddYears(-10), "Neuro Cirurgião");

            //Act
            repositorioMedicos.IncluirMedico(medicoEntity);
            var medicoBusca = repositorioMedicos.ObterPorIdentificacao(medicoEntity.CRM.ToString());

            //Assert
            Assert.NotNull(medicoBusca);
            Assert.Equal(medicoBusca.CRM.ToString(), medicoEntity.CRM.ToString());
            Assert.Equal(medicoBusca.Nome, medicoEntity.Nome);
            Assert.Equal(medicoBusca.Especialidade, medicoEntity.Especialidade);
            Assert.Equal(medicoBusca.DataNascimento.ToShortDateString(), medicoEntity.DataNascimento.ToShortDateString());
        }

        [Fact(DisplayName = "Validando exclusão de medico no banco Mongo")]
        [Trait("PacienteModel", "Validando exclusão de medico no banco de dados")]
        public void Remote_Should_Return_Sucess()
        {
            //Arrange
            var medicosIniciais = repositorioMedicos.ObterMedicos();
            var randomElement = _faker.Random.ArrayElement(medicosIniciais.ToArray());

            //Act
            repositorioMedicos.RemoverMedico(randomElement);
            var medicoBusca = repositorioMedicos.ObterPorIdentificacao(randomElement.CRM.ToString());

            var quantidadeRestante = repositorioMedicos.ObterMedicos().Count;
            //Assert
            Assert.Null(medicoBusca);
            Assert.Equal(medicosIniciais.Count - 1, quantidadeRestante);
        }
    }
}
