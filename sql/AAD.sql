CREATE DATABASE GestaoViaturasAtual;
GO

USE GestaoViaturasAtual;
GO

CREATE TABLE UnidadeMilitar (
  UnidadeMilitarID int IDENTITY NOT NULL, 
  NomeUM           varchar(255) NULL, 
  PRIMARY KEY (UnidadeMilitarID));
CREATE TABLE Viatura (
  ViaturaID       int IDENTITY NOT NULL, 
  Matricula       varchar(8) NULL, 
  ModeloID        int NOT NULL, 
  AnoFabrico      int NULL, 
  TipoViaturaID   int NOT NULL, 
  DescricaoEstado varchar(255) NULL, 
  QuartelID       int NOT NULL, 
  PRIMARY KEY (ViaturaID));
CREATE TABLE CP (
  CP         int IDENTITY NOT NULL, 
  Localidade varchar(255) NULL, 
  PRIMARY KEY (CP));
CREATE TABLE Militar (
  MilitarID        int IDENTITY NOT NULL, 
  NomeMilitar      varchar(255) NULL, 
  PatenteID        int NOT NULL, 
  UnidadeMilitarID int NOT NULL, 
  DataEntrada      datetime NOT NULL, 
  PRIMARY KEY (MilitarID));
CREATE TABLE Patente (
  PatenteID        int IDENTITY NOT NULL, 
  DescricaoPatente varchar(255) NULL, 
  PRIMARY KEY (PatenteID));
CREATE TABLE TipoViatura (
  TipoViaturaID        int IDENTITY NOT NULL, 
  DescricaoTipoViatura varchar(255) NULL, 
  PRIMARY KEY (TipoViaturaID));
CREATE TABLE Quartel (
  QuartelID   int IDENTITY NOT NULL, 
  NomeQuartel varchar(255) NULL, 
  Rua         varchar(255) NULL, 
  CP          int NOT NULL, 
  PRIMARY KEY (QuartelID));
CREATE TABLE SedeUM (
  UnidadeMilitarID int NOT NULL, 
  QuartelID        int NOT NULL, 
  PRIMARY KEY (UnidadeMilitarID, 
  QuartelID));
CREATE TABLE Abastecimento (
  AbastecimentoID   int IDENTITY NOT NULL, 
  ViaturaID         int NOT NULL, 
  QtdCombustivel    int NULL, 
  Quilometragem     varchar(10) NULL, 
  MilitarID         int NOT NULL, 
  DataAbastecimento datetime NULL, 
  PRIMARY KEY (AbastecimentoID));
CREATE TABLE Destacamento (
  OperacaoID       int NOT NULL, 
  UnidadeMilitarID int NOT NULL, 
  DataDestacamento datetime NOT NULL, 
  PRIMARY KEY (OperacaoID, 
  UnidadeMilitarID, 
  DataDestacamento));
CREATE TABLE Operacao (
  OperacaoID        int IDENTITY NOT NULL, 
  TipoOperacaoID    int NOT NULL, 
  Prioridade        int NULL, 
  DescricaoOperacao varchar(255) NULL, 
  DestinoOperacao   varchar(255) NULL, 
  PRIMARY KEY (OperacaoID));
CREATE TABLE TipoOperacao (
  TipoOperacaoID        int IDENTITY NOT NULL, 
  DescricaoTipoOperacao varchar(255) NULL, 
  PRIMARY KEY (TipoOperacaoID));
CREATE TABLE RequisicaoViatura (
  RequisicaoID     int IDENTITY NOT NULL, 
  ViaturaID        int NOT NULL, 
  OperacaoID       int NOT NULL, 
  MilitarID        int NOT NULL, 
  DataSaida        datetime NULL, 
  DataRegresso     datetime NULL, 
  UnidadeMilitarID int NOT NULL, 
  PRIMARY KEY (RequisicaoID));
CREATE TABLE Manutencao (
  ManutencaoID        int IDENTITY NOT NULL, 
  TipoManutencaoID    int NOT NULL, 
  ViaturaID           int NOT NULL, 
  ValorManutencao     varchar(10) NULL, 
  DescricaoManutencao varchar(255) NULL, 
  PRIMARY KEY (ManutencaoID));
CREATE TABLE TipoManutencao (
  TipoManutencaoID        int IDENTITY NOT NULL, 
  DescricaoTipoManutencao varchar(255) NULL, 
  PRIMARY KEY (TipoManutencaoID));
CREATE TABLE Peca (
  PecaID     int IDENTITY NOT NULL, 
  TipoPecaID int NOT NULL, 
  PrecoPeca  varchar(20) NULL, 
  PRIMARY KEY (PecaID));
CREATE TABLE AplicacaoDePeca (
  PecaID             int NOT NULL, 
  PrestacaoServicoID int NOT NULL, 
  Quantidade         int NULL, 
  PRIMARY KEY (PecaID, 
  PrestacaoServicoID));
CREATE TABLE TipoPeca (
  TipoPecaID        int IDENTITY NOT NULL, 
  DescricaoTipoPeca varchar(255) NULL, 
  PRIMARY KEY (TipoPecaID));
CREATE TABLE Marca (
  MarcaID   int IDENTITY NOT NULL, 
  NomeMarca varchar(255) NULL, 
  PRIMARY KEY (MarcaID));
CREATE TABLE Modelo (
  ModeloID   int IDENTITY NOT NULL, 
  NomeModelo varchar(255) NULL, 
  MarcaID    int NOT NULL, 
  PRIMARY KEY (ModeloID));
CREATE TABLE AtribuicaoViatura (
  AtribuicaoID     int IDENTITY NOT NULL, 
  RequisicaoID     int NOT NULL, 
  DataSaidaEfetiva datetime NULL, 
  MilitarID        int NOT NULL, 
  PRIMARY KEY (AtribuicaoID));
CREATE TABLE DevolucaoViatura (
  AtribuicaoID    int NOT NULL, 
  DescricaoEstado varchar(255) NULL, 
  DataDevolucao   datetime NOT NULL, 
  PRIMARY KEY (AtribuicaoID, 
  DataDevolucao));
CREATE TABLE DesativacaoViatura (
  ViaturaID         int NOT NULL, 
  DataDesativacao   datetime NOT NULL, 
  MotivoDesativacao varchar(255) NULL, 
  MilitarID         int NOT NULL, 
  PRIMARY KEY (ViaturaID));
CREATE TABLE OrdemServico (
  OrdemServicoID int IDENTITY NOT NULL, 
  DataEmissao    datetime NULL, 
  Valor          varchar(10) NULL, 
  ManutencaoID   int NOT NULL, 
  PRIMARY KEY (OrdemServicoID));
CREATE TABLE LinhaOrdemServico (
  OrdemServicoID     int NOT NULL, 
  PrestacaoServicoID int NOT NULL, 
  PRIMARY KEY (OrdemServicoID, 
  PrestacaoServicoID));
CREATE TABLE Mecanico (
  MecanicoID   int IDENTITY NOT NULL, 
  NomeMecanico varchar(255) NULL, 
  QuartelID    int NOT NULL, 
  PRIMARY KEY (MecanicoID));
CREATE TABLE PrestacaoServico (
  PrestacaoServicoID int IDENTITY NOT NULL, 
  ManutencaoID       int NOT NULL, 
  MecanicoID         int NOT NULL, 
  HorasReparacao     int NULL, 
  PRIMARY KEY (PrestacaoServicoID));
CREATE TABLE Motivo (
  MotivoID        int IDENTITY NOT NULL, 
  DescricaoMotivo varchar(255) NULL, 
  PRIMARY KEY (MotivoID));
CREATE TABLE MotivoDesativacao (
  MotivoID  int NOT NULL, 
  ViaturaID int NOT NULL, 
  PRIMARY KEY (MotivoID, 
  ViaturaID));
ALTER TABLE Operacao ADD CONSTRAINT FKOperacao546210 FOREIGN KEY (TipoOperacaoID) REFERENCES TipoOperacao (TipoOperacaoID);
ALTER TABLE Destacamento ADD CONSTRAINT FKDestacamen457203 FOREIGN KEY (OperacaoID) REFERENCES Operacao (OperacaoID);
ALTER TABLE Militar ADD CONSTRAINT FKMilitar922454 FOREIGN KEY (UnidadeMilitarID) REFERENCES UnidadeMilitar (UnidadeMilitarID);
ALTER TABLE SedeUM ADD CONSTRAINT FKSedeUM699158 FOREIGN KEY (UnidadeMilitarID) REFERENCES UnidadeMilitar (UnidadeMilitarID);
ALTER TABLE Destacamento ADD CONSTRAINT FKDestacamen628351 FOREIGN KEY (UnidadeMilitarID) REFERENCES UnidadeMilitar (UnidadeMilitarID);
ALTER TABLE SedeUM ADD CONSTRAINT FKSedeUM438578 FOREIGN KEY (QuartelID) REFERENCES Quartel (QuartelID);
ALTER TABLE Modelo ADD CONSTRAINT FKModelo465950 FOREIGN KEY (MarcaID) REFERENCES Marca (MarcaID);
ALTER TABLE Viatura ADD CONSTRAINT FKViatura573228 FOREIGN KEY (ModeloID) REFERENCES Modelo (ModeloID);
ALTER TABLE Peca ADD CONSTRAINT FKPeca35262 FOREIGN KEY (TipoPecaID) REFERENCES TipoPeca (TipoPecaID);
ALTER TABLE AplicacaoDePeca ADD CONSTRAINT FKAplicacaoD272576 FOREIGN KEY (PecaID) REFERENCES Peca (PecaID);
ALTER TABLE Militar ADD CONSTRAINT FKMilitar780607 FOREIGN KEY (PatenteID) REFERENCES Patente (PatenteID);
ALTER TABLE Quartel ADD CONSTRAINT FKQuartel905581 FOREIGN KEY (CP) REFERENCES CP (CP);
ALTER TABLE Manutencao ADD CONSTRAINT FKManutencao486971 FOREIGN KEY (TipoManutencaoID) REFERENCES TipoManutencao (TipoManutencaoID);
ALTER TABLE DesativacaoViatura ADD CONSTRAINT FKDesativaca821758 FOREIGN KEY (MilitarID) REFERENCES Militar (MilitarID);
ALTER TABLE PrestacaoServico ADD CONSTRAINT FKPrestacaoS72282 FOREIGN KEY (ManutencaoID) REFERENCES Manutencao (ManutencaoID);
ALTER TABLE AplicacaoDePeca ADD CONSTRAINT FKAplicacaoD161190 FOREIGN KEY (PrestacaoServicoID) REFERENCES PrestacaoServico (PrestacaoServicoID);
ALTER TABLE RequisicaoViatura ADD CONSTRAINT FKRequisicao324974 FOREIGN KEY (UnidadeMilitarID) REFERENCES UnidadeMilitar (UnidadeMilitarID);
ALTER TABLE Abastecimento ADD CONSTRAINT FKAbastecime983139 FOREIGN KEY (ViaturaID) REFERENCES Viatura (ViaturaID);
ALTER TABLE Viatura ADD CONSTRAINT FKViatura646785 FOREIGN KEY (TipoViaturaID) REFERENCES TipoViatura (TipoViaturaID);
ALTER TABLE LinhaOrdemServico ADD CONSTRAINT FKLinhaOrdem308379 FOREIGN KEY (OrdemServicoID) REFERENCES OrdemServico (OrdemServicoID);
ALTER TABLE LinhaOrdemServico ADD CONSTRAINT FKLinhaOrdem652207 FOREIGN KEY (PrestacaoServicoID) REFERENCES PrestacaoServico (PrestacaoServicoID);
ALTER TABLE AtribuicaoViatura ADD CONSTRAINT FKAtribuicao280842 FOREIGN KEY (RequisicaoID) REFERENCES RequisicaoViatura (RequisicaoID);
ALTER TABLE PrestacaoServico ADD CONSTRAINT FKPrestacaoS319222 FOREIGN KEY (MecanicoID) REFERENCES Mecanico (MecanicoID);
ALTER TABLE RequisicaoViatura ADD CONSTRAINT FKRequisicao153826 FOREIGN KEY (OperacaoID) REFERENCES Operacao (OperacaoID);
ALTER TABLE RequisicaoViatura ADD CONSTRAINT FKRequisicao314474 FOREIGN KEY (ViaturaID) REFERENCES Viatura (ViaturaID);
ALTER TABLE RequisicaoViatura ADD CONSTRAINT FKRequisicao531175 FOREIGN KEY (MilitarID) REFERENCES Militar (MilitarID);
ALTER TABLE Abastecimento ADD CONSTRAINT FKAbastecime199841 FOREIGN KEY (MilitarID) REFERENCES Militar (MilitarID);
ALTER TABLE Viatura ADD CONSTRAINT FKViatura78082 FOREIGN KEY (QuartelID) REFERENCES Quartel (QuartelID);
ALTER TABLE Mecanico ADD CONSTRAINT FKMecanico794889 FOREIGN KEY (QuartelID) REFERENCES Quartel (QuartelID);
ALTER TABLE OrdemServico ADD CONSTRAINT FKOrdemServi619398 FOREIGN KEY (ManutencaoID) REFERENCES Manutencao (ManutencaoID);
ALTER TABLE Manutencao ADD CONSTRAINT FKManutencao581303 FOREIGN KEY (ViaturaID) REFERENCES Viatura (ViaturaID);
ALTER TABLE AtribuicaoViatura ADD CONSTRAINT FKAtribuicao638946 FOREIGN KEY (MilitarID) REFERENCES Militar (MilitarID);
ALTER TABLE MotivoDesativacao ADD CONSTRAINT FKMotivoDesa834447 FOREIGN KEY (ViaturaID) REFERENCES DesativacaoViatura (ViaturaID);
ALTER TABLE MotivoDesativacao ADD CONSTRAINT FKMotivoDesa770661 FOREIGN KEY (MotivoID) REFERENCES Motivo (MotivoID);
ALTER TABLE MotivoDesativacao ADD CONSTRAINT FKMotivoDesa11014 FOREIGN KEY (ViaturaID) REFERENCES Viatura (ViaturaID);
ALTER TABLE DesativacaoViatura ADD CONSTRAINT FKDesativaca38460 FOREIGN KEY (ViaturaID) REFERENCES Viatura (ViaturaID);
ALTER TABLE DevolucaoViatura ADD CONSTRAINT FKDevolucaoV807263 FOREIGN KEY (AtribuicaoID) REFERENCES AtribuicaoViatura (AtribuicaoID);
