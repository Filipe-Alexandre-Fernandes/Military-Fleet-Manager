# Military Fleet Manager

C# Windows Forms source code for managing military vehicles, updating their status and barracks, and creating vehicle requisitions in batches through SQL Server.

[Português](README.pt-PT.md)

> **Project status:** incomplete source snapshot. The repository contains application logic, but the Visual Studio project, form Designer files and database scripts are not included. It cannot currently be built or run from a fresh clone.

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

The target .NET version and NuGet package versions cannot be confirmed without the original project file.

## Source guide

| File | Responsibility |
| --- | --- |
| [Program.cs](Program.cs) | Application entry point |
| [FrmMenu.cs](FrmMenu.cs) | Navigation and database connection check |
| [FrmConsultas.cs](FrmConsultas.cs) | Joined fleet query and results display |
| [FrmAtualizarViatura.cs](FrmAtualizarViatura.cs) | Vehicle status and barracks updates |
| [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs) | Batch selection, validation and transaction |
| [Db.cs](Db.cs) | Query and command helpers |

## What is needed to run it

Restore the original project assets before attempting to build:

1. The `.csproj` and, if available, the Visual Studio solution.
2. The `.Designer.cs` files defining `InitializeComponent()`, controls and event wiring for each form, plus any associated `.resx` resources.
3. SQL scripts defining the schema and `sp_CriarRequisicaoEAtribuicao`.
4. Synthetic sample data and any configuration required by the original project.

Once those assets are restored:

1. Use Windows and a Visual Studio installation with the **.NET desktop development** workload and the SDK targeted by the restored project.
2. Restore the project's NuGet dependencies, including `Microsoft.Data.SqlClient`.
3. Create the SQL Server database from the restored scripts.
4. Configure the database connection in both [Db.cs](Db.cs) and [FrmRequisicoesLote.cs](FrmRequisicoesLote.cs).
5. Build and run the restored Windows Forms project.

The current source uses a local SQL Server instance, the `GestaoViaturasAtual` database and Windows integrated authentication. Its `TrustServerCertificate=True` setting should be reviewed for any environment beyond local development.

## Database dependencies

The source references these tables:

`Viatura`, `Modelo`, `Marca`, `TipoViatura`, `Quartel`, `Operacao`, `Militar` and `UnidadeMilitar`.

Batch creation expects `sp_CriarRequisicaoEAtribuicao` to accept:

`@ViaturaID`, `@OperacaoID`, `@MilitarID`, `@UnidadeMilitarID`, `@DataSaida`, `@DataRegresso` and `@DataSaidaEfetiva`.

The caller reads a scalar result and converts it to the created requisition ID. The schema, constraints and procedure behavior must be checked against the original database.

## Next steps

- [ ] Restore the project, Designer resources and database scripts.
- [ ] Centralize the connection string in configuration.
- [ ] Add date-order validation and clearer handling of connection failures.
- [ ] Add automated tests for validation and transactional behavior.
- [ ] Add screenshots using synthetic data and a short demonstration.
- [ ] Document a verified installation process and supported versions.

## Background

Maintained by [Filipe Fernandes](https://github.com/Filipe-Alexandre-Fernandes). The repository's original identifier is **AAD**; the application namespace remains `GestaoViaturasWinForms`.

## License

No license file is currently included.
