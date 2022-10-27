USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Horario]    Script Date: 10/27/2022 4:42:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Horario]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Dia,
            HoraInicio,
            HoraFin,
            Sede,
            Aula
	FROM Horario
	WHERE Codigo = @Codigo
END 
GO

