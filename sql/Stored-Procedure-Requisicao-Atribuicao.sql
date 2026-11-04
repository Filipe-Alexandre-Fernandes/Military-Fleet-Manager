USE [GestaoViaturasAtual]
GO
/****** Object:  StoredProcedure [dbo].[sp_CriarRequisicaoEAtribuicao]    Script Date: 04/11/2026 09:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[sp_CriarRequisicaoEAtribuicao]
    @ViaturaID INT,
    @OperacaoID INT,
    @MilitarID INT,
    @UnidadeMilitarID INT,
    @DataSaida DATETIME = NULL,
    @DataRegresso DATETIME = NULL,
    @DataSaidaEfetiva DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN;

        INSERT INTO RequisicaoViatura
            (ViaturaID, OperacaoID, MilitarID, DataSaida, DataRegresso, UnidadeMilitarID)
        VALUES
            (@ViaturaID, @OperacaoID, @MilitarID, @DataSaida, @DataRegresso, @UnidadeMilitarID);

        DECLARE @RequisicaoID INT = SCOPE_IDENTITY();

        INSERT INTO AtribuicaoViatura
            (RequisicaoID, DataSaidaEfetiva, MilitarID)
        VALUES
            (@RequisicaoID, @DataSaidaEfetiva, @MilitarID);

        COMMIT;

        SELECT @RequisicaoID AS RequisicaoCriada;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
