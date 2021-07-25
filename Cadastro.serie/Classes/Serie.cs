using System;
namespace Cadastro.serie
{
    public class Serie : EntidadeBase
    {
        // Atributos da classe
        private Genero Genero { get; set; }

        private string Titulo { get; set; }
        
        private string Descricao { get; set; }
        
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        
        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        /// <summary>
        /// Método que converte o objeto em string para apresentá-lo no console
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            // Environment.NewLine identifica qual configuração de quebra de linha vai
            // ser utilizada por cada sistema operacional/ambiente (/n, /r, etc)
            // link para doc: https://docs.microsoft.com/pt-br/dotnet/api/system.environment.newline?view=net-5.0
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de início: " + this.Ano + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
    }
}