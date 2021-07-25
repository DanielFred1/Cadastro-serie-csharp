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



