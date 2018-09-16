using Overbooking.Compartilhado.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Overbooking.Negocio.Interfaces
{
    public interface IServicoDeVoo 
    {
        void AdicionePassageiro(IPassageiroVoo passageiroVoo);
        IEnumerable<IPassageiroVoo> ObtenhaTodosPassageiros();
    }
}
