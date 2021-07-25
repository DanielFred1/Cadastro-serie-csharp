# Cadastro-serie-csharp
Algoritmo simples para cadastro de séries a fim de praticar conhecimentos em orientação a objetos, utilizando como base o projeto criado por **Eliézer Zarpelão** na plataforma da _Digital Innovation One_.

- Como pensar orientado a objetos, modelar domínio e utilizar recursos de coleção para salvar dados em memória.

### Primeiros passos

Criando aplicação console pelo terminal

```c#
dotnet new console -n Cadastro.serie
```

Vamos adicionar também um arquivo .gitignore para ignorar arquivos desnecessários nos commits da aplicação, não importantes para o desenvolvimento, como arquivos temporários e de sistema.

Podemos utilizar o site <https://www.toptal.com/developers/gitignore> para gerar um .gitignore automático para a linguagem C# e assim adicioná-lo ao repositório.



### Uso da classe SerieRepositorio como um "banco de dados"

O objetivo dessa classe é simular um banco de dados dentro da própria aplicação, por meio de uma lista criada com os dados inseridos.

```c#
private List<Serie> ListaSerie = new List<Serie>();
```



### Usando Enum.GetName e Enum.GetValues para retornar id e gênero da série

Essa funcionalidade permite que consigamos retornar em um foreach o id e o gênero da série registrados dentro do Enum Genero. 

```c#
foreach (int indice in Enum.GetValues(typeof(Genero)))
{
    Console.WriteLine($"{indice,3} | {Enum.GetName(typeof(Genero), indice)}");
}
```

Os links para documentação podem ser acessados aqui:

<https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0>

<https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0>



### If usando bool para apresentar controle de exclusão de séries no sistema

Como não estamos usando uma base de dados, para não haver problemas nos índices das séries depois da atualização de exclusão, foi implementada a funcionalidade de apresentar "Excluído" ou "Ativo" e de ocultar a série excluída da listagem geral.



- Listagem de séries cadastradas (todas)

```c#
foreach (var serie in lista)
{
    var excluido = serie.RetornaExcluido();
    Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()} | {(excluido ? "Excluído" : "Ativo")}");
}
```



- Listagem de séries ativas

```c#
var excluido = serie.RetornaExcluido();
if (excluido != true)
{
    Console.WriteLine($"ID {serie.RetornaId()} | {serie.RetornaTitulo()}");
}
```

