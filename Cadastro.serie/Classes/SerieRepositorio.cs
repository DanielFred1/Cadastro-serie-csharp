using System;
using System.Collections.Generic;
using Cadastro.serie.Interfaces;

namespace Cadastro.serie
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSeries = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            ListaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            ListaSeries.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}