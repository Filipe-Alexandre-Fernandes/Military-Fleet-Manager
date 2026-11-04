# Military Fleet Manager — Gestão de Viaturas Militares

Código C# de uma aplicação Windows Forms para consultar viaturas militares, atualizar o estado e o quartel e criar requisições de viaturas em lote através de SQL Server.

[English](README.md)

> **Estado do projeto:** versão parcial do código-fonte. Faltam o projeto Visual Studio, os ficheiros do Designer dos formulários e os scripts da base de dados. Ainda não é possível compilar ou executar a aplicação apenas com um clone deste repositório.

## Funcionalidades presentes no código

- **Consulta da frota:** matrícula, modelo, marca, tipo, ano de fabrico, estado e quartel.
- **Atualização de viaturas:** alteração do estado e do quartel com SQL parametrizado.
- **Requisições em lote:** seleção de operação, militar, unidade e várias viaturas, com validação de seleções vazias e viaturas repetidas.
- **Escrita transacional:** chamada de `sp_CriarRequisicaoEAtribuicao` para cada viatura numa única transação, com commit do lote em caso de sucesso ou tentativa de rollback em caso de erro.
- **Verificação da ligação:** apresentação do estado da ligação à base de dados ao abrir o menu.

Esta lista descreve o código disponível, não uma versão testada de ponta a ponta. A implementação do procedimento armazenado não está incluída.

## Tecnologias

| Componente | Tecnologia |
| --- | --- |
| Linguagem | C# |
| Interface desktop | Windows Forms |
| Base de dados | Microsoft SQL Server |
| Acesso a dados | ADO.NET com `Microsoft.Data.SqlClient` |
| Apresentação de dados | `DataTable` e `DataGridView` |

Sem o ficheiro de projeto original, não é possível confirmar a versão de .NET nem as versões dos pacotes NuGet.

## Organização

| Ficheiro | Responsabilidade |
| --- | --- |
| [Program.cs](Program.cs) | Ponto de entrada da aplicação |
| [FrmMenu.cs](FrmMenu.cs) | Navegação e verificação da ligação |
| [FrmConsultas.cs](FrmConsultas.cs) | Consulta da frota e apresentação dos resultados |
| [FrmAtualizarViatura.cs](FrmAtualizarViatura.cs) | Atualização do estado e do quartel |
| [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs) | Seleção, validação e transação das requisições |
| [Db.cs](Db.cs) | Métodos auxiliares de consulta e execução SQL |

## O que falta para executar

Recuperar primeiro os seguintes elementos do projeto original:

1. O ficheiro `.csproj` e, se existir, a solução Visual Studio.
2. Os ficheiros `.Designer.cs` com `InitializeComponent()`, os controlos e a associação dos eventos de cada formulário, além dos recursos `.resx` associados.
3. Os scripts SQL do esquema e do procedimento `sp_CriarRequisicaoEAtribuicao`.
4. Dados de demonstração fictícios e a configuração necessária.

Depois de recuperar esses elementos:

1. Utilizar Windows e Visual Studio com a carga de trabalho **Desenvolvimento para ambiente de trabalho com .NET** e o SDK indicado no projeto recuperado.
2. Restaurar as dependências NuGet, incluindo `Microsoft.Data.SqlClient`.
3. Criar a base de dados SQL Server com os scripts recuperados.
4. Configurar a ligação em [Db.cs](Db.cs) e [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs).
5. Compilar e executar o projeto Windows Forms recuperado.

O código atual utiliza uma instância local de SQL Server, a base de dados `GestaoViaturasAtual` e autenticação integrada do Windows. A opção `TrustServerCertificate=True` deve ser revista para ambientes além do desenvolvimento local.

## Dependências da base de dados

O código referencia as tabelas:

`Viatura`, `Modelo`, `Marca`, `TipoViatura`, `Quartel`, `Operacao`, `Militar` e `UnidadeMilitar`.

A criação em lote espera que `sp_CriarRequisicaoEAtribuicao` aceite:

`@ViaturaID`, `@OperacaoID`, `@MilitarID`, `@UnidadeMilitarID`, `@DataSaida`, `@DataRegresso` e `@DataSaidaEfetiva`.

O código lê um resultado escalar e converte-o no identificador da requisição criada. O esquema, as restrições e o comportamento do procedimento devem ser confirmados na base de dados original.

## Próximos passos

- [ ] Recuperar o projeto, os recursos do Designer e os scripts SQL.
- [ ] Centralizar a configuração da ligação à base de dados.
- [ ] Validar a ordem das datas e melhorar o tratamento de falhas de ligação.
- [ ] Adicionar testes de validação e do comportamento transacional.
- [ ] Incluir imagens com dados fictícios e uma demonstração curta.
- [ ] Documentar uma instalação verificada e as versões suportadas.

## Contexto

Mantido por [Filipe Fernandes](https://github.com/Filipe-Alexandre-Fernandes). O identificador original do repositório é **AAD**; o namespace da aplicação mantém-se `GestaoViaturasWinForms`.

## Licença

O repositório ainda não inclui um ficheiro de licença.
