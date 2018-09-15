using Overbooking.Compartilhado.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overbooking.Negocio.Interfaces
{
    public interface IServicoDeDataDeSaida
    {
        void Adicione(IDataDeSaida dataDeSaida);
        IEnumerable<IDataDeSaida> ObtenhaTodos();
    }
}
