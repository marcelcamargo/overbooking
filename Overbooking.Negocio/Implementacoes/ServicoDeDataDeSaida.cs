using Overbooking.Compartilhado.Interfaces;
using Overbooking.Dados.Interfaces;
using Overbooking.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overbooking.Negocio.Implementacoes
{
    public class ServicoDeDataDeSaida : IServicoDeDataDeSaida
    {
        private IRepositorio<IDataDeSaida> _repositorio;

        public ServicoDeDataDeSaida(IRepositorio<IDataDeSaida> repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
