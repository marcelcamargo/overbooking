﻿using Overbooking.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Overbooking.Dados.Implementacoes
{
    internal class RepositorioEmMemoria<T> : IRepositorio<T> where T : class
    {
        private IList<T> _listaDeEntidades;

        public RepositorioEmMemoria()
        {
            _listaDeEntidades = new List<T>();
        }

        public void Adicione(T entidade)
        {
            _listaDeEntidades.Add(entidade);
        }

        public void Atualize(T entidade)
        {            
            Remova(entidade);
            Adicione(entidade);
        }

        public IEnumerable<T> Obtenha(Func<T, bool> expressao)
        {
            return _listaDeEntidades.Where(expressao);
        }

        public T Obtenha(T entidade)
        {
            return _listaDeEntidades.FirstOrDefault(x => x.Equals(entidade));
        }

        public IEnumerable<T> ObtenhaTodos()
        {
            return _listaDeEntidades;
        }

        public void Remova(T entidade)
        {            
            _listaDeEntidades.Remove(entidade);
        }
    }
}
