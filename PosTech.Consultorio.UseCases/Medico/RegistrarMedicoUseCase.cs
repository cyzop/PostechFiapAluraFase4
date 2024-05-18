﻿using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class RegistrarMedicoUseCase
    {
        private readonly MedicoEntity _novo;
        private readonly MedicoEntity _medico;

        public RegistrarMedicoUseCase(MedicoEntity novo, MedicoEntity registroBase)
        {
            _novo = novo;
            _medico = registroBase;
        }

        public MedicoEntity VerificarNovo()
        {
            if (_novo?.CRM.ToString() == _medico?.CRM.ToString())
                throw new Exception($"Medico {_novo.Nome} já cadastrado!");

            return _novo;
        }
    }
}
