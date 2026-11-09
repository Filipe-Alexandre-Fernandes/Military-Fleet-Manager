# Military Fleet Manager — Gestão de Viaturas Militares

Código C# de uma aplicação Windows Forms para consultar viaturas militares, atualizar o estado e o quartel e criar requisições de viaturas em lote através de SQL Server.

[English](README.md)

> **Estado do projeto:** o projeto Windows Forms em .NET 10, a solução, os Designer e os recursos foram recuperados da entrega da Etapa 4. As consultas SQL analíticas, o procedimento armazenado e as imagens da aplicação estão incluídos. O script de criação da base de dados está incluído; continuam a faltar os dados iniciais, pelo que uma base de dados criada de raiz fica vazia. A compilação e a execução completa ainda não foram verificadas neste ambiente.

## Funcionalidades presentes no código

- **Consulta da frota:** matrícula, modelo, marca, tipo, ano de fabrico, estado e quartel.
- **Atualização de viaturas:** alteração do estado e do quartel com SQL parametrizado.
- **Requisições em lote:** seleção de operação, militar, unidade e várias viaturas, com validação de seleções vazias e viaturas repetidas.
- **Escrita transacional:** chamada de `sp_CriarRequisicaoEAtribuicao` para cada viatura numa única transação, com commit do lote em caso de sucesso ou tentativa de rollback em caso de erro.
- **Verificação da ligação:** apresentação do estado da ligação à base de dados ao abrir o menu.

Esta lista descreve o código disponível, não uma versão testada de ponta a ponta. O procedimento armazenado está incluído e os seus sete parâmetros e resultado escalar correspondem à chamada da aplicação.

## Imagens da aplicação

Capturas fornecidas pelo autor, incluindo a consulta com viaturas carregadas.

### Menu principal

![Menu principal](docs/screenshots/Menu-principal.png)

### Consulta de viaturas

![Lista de viaturas](docs/screenshots/Listar-Viaturas.png)

### Atualização de viaturas

![Atualizar viatura](docs/screenshots/Atualizar-viaturas.png)

### Requisição e atribuição

![Requisição de viaturas](docs/screenshots/Requisicao-viaturas.png)

## Tecnologias

| Componente | Tecnologia |
| --- | --- |
| Linguagem | C# |
| Interface desktop | Windows Forms |
| Base de dados | Microsoft SQL Server |
| Acesso a dados | ADO.NET com `Microsoft.Data.SqlClient` |
| Apresentação de dados | `DataTable` e `DataGridView` |

O projeto recuperado utiliza **.NET 10 para Windows** (`net10.0-windows`) e **Microsoft.Data.SqlClient 6.1.3**.

## Organização

| Ficheiro | Responsabilidade |
| --- | --- |
| [Program.cs](Program.cs) | Ponto de entrada da aplicação |
| [FrmMenu.cs](FrmMenu.cs) | Navegação e verificação da ligação |
| [FrmConsultas.cs](FrmConsultas.cs) | Consulta da frota e apresentação dos resultados |
| [FrmAtualizarViatura.cs](FrmAtualizarViatura.cs) | Atualização do estado e do quartel |
| [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs) | Seleção, validação e transação das requisições |
| [Db.cs](Db.cs) | Métodos auxiliares de consulta e execução SQL |

## Compilar e executar

Em Windows, instalar o **SDK .NET 10**. Para editar os formulários, utilizar Visual Studio com suporte a .NET 10 e a carga de trabalho **Desenvolvimento para ambiente de trabalho com .NET**.

```powershell
git clone https://github.com/Filipe-Alexandre-Fernandes/Military-Fleet-Manager.git
cd Military-Fleet-Manager
dotnet restore GestaoViaturasWinForms.csproj
dotnet build GestaoViaturasWinForms.csproj --configuration Release
```

Também é possível abrir [GestaoViaturasWinForms.slnx](GestaoViaturasWinForms.slnx) numa versão compatível do Visual Studio.

Antes de executar, seguir a preparação da base de dados abaixo: criar o esquema, instalar o procedimento armazenado e carregar dados de demonstração adequados. As [consultas analíticas](sql/Militares-Querys.sql) consultam registos existentes; não preenchem a base de dados. Configurar a ligação em [Db.cs](Db.cs) e [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs) e executar:

```powershell
dotnet run --project GestaoViaturasWinForms.csproj
```

Estes comandos descrevem o processo previsto; a compilação e a execução com a base de dados ainda não foram verificadas neste ambiente.

O código atual utiliza uma instância local de SQL Server, a base de dados `GestaoViaturasAtual` e autenticação integrada do Windows. A opção `TrustServerCertificate=True` deve ser revista para ambientes além do desenvolvimento local.

## Modelo de dados

O diagrama original apresenta as relações entre viaturas, militares, unidades, operações, requisições, manutenção e ordens de serviço.

[Abrir o diagrama em tamanho completo](docs/database-schema.png)

![Esquema da base de dados de gestão de viaturas militares e relações entre tabelas](docs/database-schema.png)

A imagem mantém as designações e a notação de tipos do modelo académico. Consultar [sql/AAD.sql](sql/AAD.sql) como referência da implementação em SQL Server, incluindo os tipos de dados e as restrições exatos.

## Preparar a base de dados

Utilizar o SQL Server Management Studio com uma conta que possa criar bases de dados e objetos. Executar pela seguinte ordem:

1. Executar [sql/AAD.sql](sql/AAD.sql) para criar `GestaoViaturasAtual`, **29 tabelas** e **37 chaves estrangeiras**. O DDL fornecido foi preservado. Executar apenas numa instalação de raiz: não contém verificações de existência e não é uma migração para uma base de dados existente.
2. Abrir [sql/Stored-Procedure-Requisicao-Atribuicao.sql](sql/Stored-Procedure-Requisicao-Atribuicao.sql). Nesta primeira instalação, substituir a declaração inicial `ALTER PROCEDURE` por `CREATE PROCEDURE` e executar o script. Manter `ALTER PROCEDURE` para atualizar um procedimento já existente.
3. Carregar dados de demonstração antes de testar a interface. Ainda não está incluído um script de dados iniciais. Inserir primeiro os registos referenciados: por exemplo, `Marca` antes de `Modelo`, `CP` antes de `Quartel` e `Modelo`, `TipoViatura` e `Quartel` antes de `Viatura`. As requisições também precisam de registos de `Operacao`, `Militar` e `UnidadeMilitar`.

A criação do esquema deixa as listas e os seletores vazios. As imagens mostram uma base de dados preenchida; esses registos não estão incluídos no script do esquema.

As verificações estáticas confirmaram que existem as tabelas e colunas referenciadas pelas chaves estrangeiras e as colunas de inserção do procedimento. A execução em SQL Server não foi verificada neste ambiente.

## Consultas SQL

[sql/Militares-Querys.sql](sql/Militares-Querys.sql) contém as consultas fornecidas para as dez questões do trabalho, incluindo soluções alternativas. A lógica das consultas foi preservada; a codificação original do Windows foi convertida para UTF-8.

Abrir o ficheiro no SQL Server Management Studio, selecionar a base de dados existente `GestaoViaturasAtual` e executar a seleção da consulta pretendida. O script não contém uma instrução `USE`. As consultas com `GETDATE()` dependem da data atual do SQL Server.

São consultas analíticas, **não um script de instalação**. Também referenciam tabelas além das utilizadas pela interface desktop. O esquema e o procedimento armazenado estão incluídos separadamente; continuam a ser necessários os dados iniciais. Os resultados não foram validados numa base de dados SQL Server em execução.

## Procedimento armazenado

[Stored-Procedure-Requisicao-Atribuicao.sql](sql/Stored-Procedure-Requisicao-Atribuicao.sql) insere uma requisição em `RequisicaoViatura`, insere a respetiva atribuição em `AtribuicaoViatura` e devolve o identificador da requisição através de `SELECT`. Os parâmetros correspondem à chamada do Windows Forms.

O script fornecido foi preservado, com a codificação normalizada para UTF-8. Seleciona `GestaoViaturasAtual` e utiliza **ALTER PROCEDURE**, pelo que a base de dados, as tabelas e o procedimento já têm de existir. Na primeira instalação, depois de criar o esquema, substituir `ALTER PROCEDURE` por `CREATE PROCEDURE` antes de executar o script no SQL Server Management Studio. Este script não cria tabelas nem dados de demonstração.

O procedimento inicia uma transação e faz rollback em caso de erro. A aplicação também envolve o lote numa transação; os caminhos de erro e a interação entre os rollbacks ainda precisam de testes de integração. O script foi comparado com o código que o chama, mas não foi executado neste ambiente.

## Dependências da base de dados

O código referencia as tabelas:

`Viatura`, `Modelo`, `Marca`, `TipoViatura`, `Quartel`, `Operacao`, `Militar` e `UnidadeMilitar`.

A criação em lote espera que `sp_CriarRequisicaoEAtribuicao` aceite:

`@ViaturaID`, `@OperacaoID`, `@MilitarID`, `@UnidadeMilitarID`, `@DataSaida`, `@DataRegresso` e `@DataSaidaEfetiva`.

O código lê um resultado escalar e converte-o no identificador da requisição criada. O esquema, as restrições e o comportamento do procedimento devem ser confirmados na base de dados original.

## Próximos passos

- [x] Recuperar o projeto, a solução e os recursos do Designer.
- [x] Incluir o procedimento armazenado.
- [x] Incluir o script de criação da base de dados e das tabelas.
- [ ] Adicionar dados de demonstração.
- [ ] Centralizar a configuração da ligação à base de dados.
- [ ] Validar a ordem das datas e melhorar o tratamento de falhas de ligação.
- [ ] Adicionar testes de validação e do comportamento transacional.
- [x] Incluir as imagens da aplicação fornecidas pelo autor.
- [ ] Adicionar um vídeo curto de demonstração.
- [ ] Documentar uma instalação verificada e as versões suportadas.

## Contexto

Trabalho académico de **Armazenamento e Acesso a Dados** (janeiro de 2026), realizado por **Ana Rita Ranito, Filipe Fernandes e Nuno Araújo**.

O [relatório da Etapa 4](docs/relatorio-etapa-4.pdf) inclui a descrição do projeto, o modelo de dados e imagens da interface.

Repositório mantido por [Filipe Fernandes](https://github.com/Filipe-Alexandre-Fernandes). O identificador original do repositório é **AAD**; o namespace da aplicação mantém-se `GestaoViaturasWinForms`.

## Licença

O repositório ainda não inclui um ficheiro de licença.

