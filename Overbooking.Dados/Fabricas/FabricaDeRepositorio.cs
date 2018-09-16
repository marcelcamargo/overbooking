using Overbooking.Dados.Implementacoes;
using Overbooking.Dados.Interfaces;
using System;
using System.Collections.Generic;

namespace Overbooking.Dados.Fabricas
{
    public class FabricaDeRepositorio<T> where T : class
    {
        private static Dictionary<Type, IRepositorio<T>> _dicionarioDeRepositorios = new Dictionary<Type, IRepositorio<T>>();

        public static IRepositorio<T> ObtenhaRepositorio()
        {
            IRepositorio<T> repositorio;

            if(!_dicionarioDeRepositorios.TryGetValue(typeof(T), out repositorio))
            {
                repositorio = new RepositorioEmMemoria<T>();

                _dicionarioDeRepositorios[typeof(T)] = repositorio;
            }

            return repositorio;
        }

    }
}
