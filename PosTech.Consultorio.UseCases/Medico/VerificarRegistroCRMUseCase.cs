using PosTech.Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class VerificarRegistroCRMUseCase
    {
        private string _parteNumerica;
        private string _parteSigla;

        public VerificarRegistroCRMUseCase(string crm)
        {
            var partes = crm.Split("-");
            if (partes.Length != 2)
                throw new ArgumentException("O CRM está inválido, ele não pode estar vazio e deve estar no formato number-UF, onde o number pode conter até 7 números!");

            _parteNumerica = partes[0];
            _parteSigla = partes[1];
        }

        public void Verificar()
        {
            if(_parteNumerica.Length>7)
                throw new ArgumentException("O número do CRM deve ser maior que 1 e só pode ter até 7 dígitos!");

            VerificarSiglaEstadoBrasileiroUseCase verificarSigla = new VerificarSiglaEstadoBrasileiroUseCase(_parteSigla);
            verificarSigla.Verificar();
        }
    }
}
