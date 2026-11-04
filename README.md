# Military Fleet Manager

C# Windows Forms source code for managing military vehicles, updating their status and barracks, and creating vehicle requisitions in batches through SQL Server.

[Português](README.pt-PT.md)

> **Project status:** the .NET 10 Windows Forms project, solution, Designer files and resources have been restored from the Stage 4 submission. SQL scripts are still missing: running the application requires the original database. Compilation and end-to-end execution have not yet been verified in this environment.

## Features represented in the source

- **Fleet overview:** query vehicles with registration, model, brand, type, manufacture year, status and barracks.
- **Vehicle updates:** change a vehicle's status and assigned barracks using parameterized SQL.
- **Batch requisitions:** select an operation, military member, unit and multiple vehicles; reject duplicate vehicles and empty selections.
- **Transactional writes:** call `sp_CriarRequisicaoEAtribuicao` for each selected vehicle in one SQL transaction, committing the batch on success or attempting rollback on failure.
- **Connection check:** display database connectivity information when the main menu opens.

These describe the available code, not a verified end-to-end release. The stored procedure implementation is not present.

## Technology

| Component | Technology |
| --- | --- |
| Language | C# |
| Desktop interface | Windows Forms |
| Database | Microsoft SQL Server |
| Data access | ADO.NET with `Microsoft.Data.SqlClient` |
| Data binding | `DataTable` and `DataGridView` |

The restored project targets **.NET 10 for Windows** (`net10.0-windows`) and references **Microsoft.Data.SqlClient 6.1.3**.

## Source guide

| File | Responsibility |
| --- | --- |
| [Program.cs](Program.cs) | Application entry point |
| [FrmMenu.cs](FrmMenu.cs) | Navigation and database connection check |
| [FrmConsultas.cs](FrmConsultas.cs) | Joined fleet query and results display |
| [FrmAtualizarViatura.cs](FrmAtualizarViatura.cs) | Vehicle status and barracks updates |
| [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs) | Batch selection, validation and transaction |
| [Db.cs](Db.cs) | Query and command helpers |

## Build and run

On Windows, install the **.NET 10 SDK**. For visual editing, use Visual Studio with .NET 10 support and the **.NET desktop development** workload.

```powershell
git clone https://github.com/Filipe-Alexandre-Fernandes/Military-Fleet-Manager---AAD-Project.git
cd Military-Fleet-Manager---AAD-Project
dotnet restore GestaoViaturasWinForms.csproj
dotnet build GestaoViaturasWinForms.csproj --configuration Release
```

You can also open [GestaoViaturasWinForms.slnx](GestaoViaturasWinForms.slnx) in a compatible Visual Studio version.

Before running, restore the original SQL Server schema, stored procedure and suitable sample data. **Neither supplied ZIP includes SQL scripts or a database backup.** Configure the connection in both [Db.cs](Db.cs) and [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs), then run:

```powershell
dotnet run --project GestaoViaturasWinForms.csproj
```

These commands are the intended workflow; a successful build and database run have not been verified here.

The current source uses a local SQL Server instance, the `GestaoViaturasAtual` database and Windows integrated authentication. Its `TrustServerCertificate=True` setting should be reviewed for any environment beyond local development.

## Database dependencies

The source references these tables:

`Viatura`, `Modelo`, `Marca`, `TipoViatura`, `Quartel`, `Operacao`, `Militar` and `UnidadeMilitar`.

Batch creation expects `sp_CriarRequisicaoEAtribuicao` to accept:

`@ViaturaID`, `@OperacaoID`, `@MilitarID`, `@UnidadeMilitarID`, `@DataSaida`, `@DataRegresso` and `@DataSaidaEfetiva`.

The caller reads a scalar result and converts it to the created requisition ID. The schema, constraints and procedure behavior must be checked against the original database.

## Next steps

- [x] Restore the project, solution and Designer resources.
- [ ] Restore the SQL schema, stored procedure and sample data.
- [ ] Centralize the connection string in configuration.
- [ ] Add date-order validation and clearer handling of connection failures.
- [ ] Add automated tests for validation and transactional behavior.
- [ ] Add screenshots using synthetic data and a short demonstration.
- [ ] Document a verified installation process and supported versions.

## Background

Academic project for **Armazenamento e Acesso a Dados** (January 2026), by **Ana Rita Ranito, Filipe Fernandes and Nuno Araújo**.

[Stage 4 report](docs/relatorio-etapa-4.pdf) includes the project description, data model and interface screenshots.

Repository maintained by [Filipe Fernandes](https://github.com/Filipe-Alexandre-Fernandes). The repository's original identifier is **AAD**; the application namespace remains `GestaoViaturasWinForms`.

## License

No license file is currently included.

