--1-Quantos os helicópteros que já foram usadas em operações com destino 'Lisboa' e 
--também em operações com destino 'Porto'?
Select Count(*) NumHeli From(
Select V.ViaturaId
From Viatura V
Join TipoViatura TV on V.TipoViaturaID=TV.TipoViaturaID
Join RequisicaoViatura RV on V.ViaturaID=RV.ViaturaId
Join Operacao O on RV.OperacaoId=O.OperacaoId
Where DescricaoTipoViatura='Helicóptero'
and DestinoOperacao='Lisboa'
Intersect
Select V.ViaturaId
From Viatura V
Join TipoViatura TV on V.TipoViaturaID=TV.TipoViaturaID
Join RequisicaoViatura RV on V.ViaturaID=RV.ViaturaId
Join Operacao O on RV.OperacaoId=O.OperacaoId
Where DescricaoTipoViatura='Helicóptero'
and DestinoOperacao='Porto') A

Select Count(*) as 'Numero de Helicópteros' From(
Select V.ViaturaID, Matricula
From Viatura V
Join TipoViatura TV on V.TipoViaturaID=TV.TipoViaturaID
Join RequisicaoViatura RV on V.ViaturaID=RV.ViaturaID
Join Operacao O on RV.OperacaoID=O.OperacaoID
where DescricaoTipoViatura='Helicóptero'
and DestinoOperacao='Lisboa'
intersect
Select V.ViaturaID, Matricula
From Viatura V
Join TipoViatura TV on V.TipoViaturaID=TV.TipoViaturaID
Join RequisicaoViatura RV on V.ViaturaID=RV.ViaturaID
Join Operacao O on RV.OperacaoID=O.OperacaoID
where DescricaoTipoViatura='Helicóptero'
and DestinoOperacao='Porto') Tab

--2-Quais os militares dos Comandos que nunca efetuaram qualquer abastecimento de viaturas?
Select NomeMilitar, MilitarID
From Militar M
Join UnidadeMilitar UM on M.UnidadeMilitarID=UM.UnidadeMilitarID
Where NomeUM='Comandos'
and MilitarId not in(Select MilitarId
From Abastecimento)

Select MilitarId, NomeMilitar
From Militar M
Join UnidadeMilitar UM on M.UnidadeMilitarID=UM.UnidadeMilitarID
Where NomeUM='Comandos' 
and MilitarId not in (Select MilitarID
From Abastecimento)

--3-Qual a média de litros abastecidos por viatura registada no sistema desde o inicio do ano?
Select Avg(Soma) Media From(
Select Sum(QtdCombustivel) Soma, V.ViaturaId, Matricula
From Viatura V
Join Abastecimento A on V.ViaturaId=A.ViaturaId
Where Year(DataAbastecimento)=Year(Getdate())
Group by V.ViaturaId, Matricula) V

Select Avg(Litros) as MediaViatura
From (Select A.ViaturaID, Sum(QtdCombustivel) as Litros
    From Abastecimento A
    Where Year(DataAbastecimento)=Year(Getdate())
    Group by A.ViaturaID) Tab;

-- 4 - Qual o número de operações do tipo 'Missão', 'Treino' e 'Serviço Administrativo' 
--em que cada unidade militar já participou?
Select UM.UnidadeMilitarId, NomeUM, NMISSAO, NTREINO, NSERVICOS
From UnidadeMilitar UM
Left Join (Select Count(Distinct O.OperacaoId) NMISSAO, UnidadeMilitarId
From Destacamento D
Join Operacao O on D.OperacaoId=O.OperacaoId
Join TipoOperacao T on O.TipoOperacaoId=T.TipoOperacaoId
Where DescricaoTipoOperacao='Missão'
Group by UnidadeMilitarId) MIS on UM.UnidadeMilitarID=MIS.UnidadeMilitarID
Left Join (Select Count(Distinct O.OperacaoId) NTREINO, UnidadeMilitarId
From Destacamento D
Join Operacao O on D.OperacaoId=O.OperacaoId
Join TipoOperacao T on O.TipoOperacaoId=T.TipoOperacaoId
Where DescricaoTipoOperacao='Treino'
Group by UnidadeMilitarId) TR on UM.UnidadeMilitarID=TR.UnidadeMilitarID
Left Join (Select Count(Distinct O.OperacaoId) NSERVICOS, UnidadeMilitarId
From Destacamento D
Join Operacao O on D.OperacaoId=O.OperacaoId
Join TipoOperacao T on O.TipoOperacaoId=T.TipoOperacaoId
Where DescricaoTipoOperacao='Serviço Administrativo'
Group by UnidadeMilitarId) SA on UM.UnidadeMilitarID=SA.UnidadeMilitarID


Select UM.UnidadeMilitarID, UM.NomeUM, NumMissoes, NumTreinos, NumServicosAdm
From UnidadeMilitar UM
Left Join (Select D.UnidadeMilitarID, Count(Distinct D.OperacaoID) as NumMissoes
    From Destacamento D
    Join Operacao O on O.OperacaoID = D.OperacaoID
    Join TipoOperacao T on T.TipoOperacaoID = O.TipoOperacaoID
    Where T.DescricaoTipoOperacao = 'Missão'
    Group by D.UnidadeMilitarID) as Missoes on Missoes.UnidadeMilitarID = UM.UnidadeMilitarID
Left Join (Select D.UnidadeMilitarID, Count(Distinct D.OperacaoID) as NumTreinos
    From Destacamento D
    Join Operacao O on O.OperacaoID = D.OperacaoID
    Join TipoOperacao T on T.TipoOperacaoID = O.TipoOperacaoID
    Where T.DescricaoTipoOperacao = 'Treino'
    Group by D.UnidadeMilitarID) as Treinos on Treinos.UnidadeMilitarID = UM.UnidadeMilitarID
Left Join (Select D.UnidadeMilitarID, Count(Distinct D.OperacaoID) as NumServicosAdm
    From Destacamento D
    Join Operacao O on O.OperacaoID = D.OperacaoID
    Join TipoOperacao T on T.TipoOperacaoID = O.TipoOperacaoID
    Where T.DescricaoTipoOperacao = 'Serviço Administrativo'
    Group by D.UnidadeMilitarID) as ServAdm on ServAdm.UnidadeMilitarID = UM.UnidadeMilitarID;

--5-Qual o Mecânico do quartel com o id 4, com o maior número total de horas de reparação? 
Select M.MecanicoId, NomeMecanico, Sum(HorasReparacao) Horas
From Mecanico M
Join PrestacaoServico P on M.MecanicoId=P.MecanicoId
Where QuartelId=4
Group by M.MecanicoId, NomeMecanico
Having Sum(HorasReparacao)>=All(
Select Sum(HorasReparacao)
From Mecanico M
Join PrestacaoServico P on M.MecanicoId=P.MecanicoId
Where QuartelId=4
Group by M.MecanicoId)

Select M.MecanicoID, M.NomeMecanico, Sum(PS.HorasReparacao) as TotalHorasReparacao
From Mecanico M
Join PrestacaoServico PS on PS.MecanicoID = M.MecanicoID
Where QuartelID=4
Group by M.MecanicoID, M.NomeMecanico
Having Sum(PS.HorasReparacao)>=All(Select Sum(HorasReparacao)
From Mecanico M
Join PrestacaoServico PS on PS.MecanicoID=M.MecanicoID
Where QuartelID=4
Group by M.MecanicoID)

--6-Para cada atribuição de viatura que já tenha devolução registada, 
--quantos dias decorreram entre a data de saída efetiva e a data de devolução?
Select V.ViaturaId, Matricula, AV.AtribuicaoID, DateDiff(day,DatasaidaEfetiva, Datadevolucao) Dias
From Viatura V
Join RequisicaoViatura RV on V.ViaturaId=RV.ViaturaId
Join AtribuicaoViatura AV on RV.RequisicaoId=AV.RequisicaoID
Join DevolucaoViatura DV on AV.AtribuicaoID=DV.AtribuicaoID

Select V.ViaturaID, V.Matricula, DATEDIFF(day, AV.DatasaidaEfetiva, DV.DataDevolucao) as DiasUtilizacao
From AtribuicaoViatura AV
Join DevolucaoViatura DV on DV.AtribuicaoID = AV.AtribuicaoID
Join RequisicaoViatura RV on RV.RequisicaoID = AV.RequisicaoID
Join Viatura V on V.ViaturaID = RV.ViaturaID;

--7-Quantas viaturas com mais de 200000km têm mais de 3 manutenções registadas?
Select Count(*) NumViaturas From(
Select M.ViaturaId
From Manutencao M
Join Abastecimento A on M.ViaturaId=A.ViaturaId
Where Quilometragem>200000
Group By M.ViaturaId
Having Count(Distinct ManutencaoId)>3) A

Select Count(*) as 'Num Viaturas'
From (Select M.ViaturaID
    From Manutencao M
    Join Abastecimento A on M.ViaturaID=A.ViaturaID
    where Quilometragem>200000
    Group by M.ViaturaID
    Having Count(Distinct ManutencaoId) > 3) as T;

--8-Quais os militares, com mais de 10 anos de serviço, a quem 
--foram atribuidas mais de 3 viaturas desde o início do ano?
Select M.MilitarId, NomeMilitar
From Militar M
Join AtribuicaoViatura AV on M.MilitarId=AV.MilitarId
Where DataEntrada<Dateadd(year,-10,Getdate())
and Year(DataSaidaEfetiva)=Year(Getdate())
Group by M.MilitarId,NomeMilitar
Having Count(AtribuicaoId)>3

Select M.MilitarID, M.NomeMilitar, Count(AV.AtribuicaoId) as 'Total Atribuições'
From Militar M
Join AtribuicaoViatura AV on M.MilitarID = AV.MilitarID
Where M.DataEntrada < Dateadd(Year, -10, Getdate())       
and Year(AV.DataSaidaEfetiva) = Year(Getdate())         
Group By M.MilitarID, M.NomeMilitar
Having Count(AV.AtribuicaoId) > 3;     


--9. Quais as dez viaturas mais requisitadas por militares que 
--pertencem à unidade 'Paraquedistas'?
Select TOP 10 V.ViaturaId, Matricula, Count(RequisicaoId) Req
From Viatura V
Join RequisicaoViatura RV on V.ViaturaId=RV.ViaturaId
Join UnidadeMilitar UM on RV.UnidadeMilitarID=UM.UnidadeMilitarID
Where NomeUM='Paraquedistas'
Group by V.ViaturaId, Matricula
Order by Req Desc 

Select Top 10 RV.ViaturaId, Matricula,  Count(RequisicaoId) Requisicoes
From RequisicaoViatura RV
Join Viatura V on RV.ViaturaId=V.ViaturaId
Join UnidadeMilitar UM on RV.UnidadeMilitarID=UM.UnidadeMilitarID
Where NomeUM='Paraquedistas'
Group by RV.ViaturaID, Matricula
Order by Requisicoes Desc

--10-Quais os militares cuja patente é Tenente ou superior, que foram 
--responsáveis pela desativação de mais de 2 viaturas e pela atribuição de mais de 5 viaturas?
Select M.MilitarId, NomeMilitar
From Militar M
Join DesativacaoViatura DV on M.MilitarId=DV.MilitarId
Join Patente P on M.PatenteId=P.PatenteId
Where DescricaoPatente='Tenente'
or DescricaoPatente='Capitão' 
Or DescricaoPatente='Major' 
or DescricaoPatente='Tenente-Coronel'
Or DescricaoPatente='Coronel'
Group by M.MilitarId, NomeMilitar
Having Count(DV.ViaturaId)>2
Intersect
Select M.MilitarId, NomeMilitar
From Militar M
Join AtribuicaoViatura AV on M.MilitarId=AV.MilitarId
Join Patente P on M.PatenteId=P.PatenteId
Where DescricaoPatente='Tenente'
or DescricaoPatente='Capitão' 
Or DescricaoPatente='Major' 
or DescricaoPatente='Tenente-Coronel'
Or DescricaoPatente='Coronel'
Group by M.MilitarId, NomeMilitar
Having Count(AV.AtribuicaoID)>5

Select M.MilitarID, M.NomeMilitar, P.DescricaoPatente
From Militar M
Join Patente P on P.PatenteID = M.PatenteID
Where P.DescricaoPatente in ('Tenente', 'Capitão', 'Major', 'Tenente-Coronel', 'Coronel')
and M.MilitarID in (Select DV.MilitarID
From DesativacaoViatura DV
Group by DV.MilitarID
Having Count(DV.ViaturaID) > 2)
and M.MilitarID in (Select AV.MilitarID
From AtribuicaoViatura AV
Group by AV.MilitarID
Having Count(AV.AtribuicaoID) > 5);