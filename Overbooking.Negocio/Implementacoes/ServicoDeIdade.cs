﻿using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeIdade : ServicoGenerico<IIdadeDoPassageiro>, IServicoDeIdade
    {
        private IRepositorio<IIdadeDoPassageiro> _repositorio;

        protected override IRepositorio<IIdadeDoPassageiro> Repositorio { get => _repositorio; }

        public ServicoDeIdade(IRepositorio<IIdadeDoPassageiro> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
