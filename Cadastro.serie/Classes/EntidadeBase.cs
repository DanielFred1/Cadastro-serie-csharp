namespace Cadastro.serie
{
    public abstract class EntidadeBase
    {
        /// <summary>
        /// Classe abstrata que vai ser utilizada por todas as classes no projeto fornecendo Id,
        /// dentro do namespace Cadastro.serie ela fica acessível para todas as entidades.
        /// </summary>
        /// <value>int ID</value>
        public int Id { get; protected set; }
        
        
    }
}