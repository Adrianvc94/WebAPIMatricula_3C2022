USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Profesor]    Script Date: 10/27/2022 4:43:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Profesor]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Identificacion,
             Nombre,
            Correo,
            Estado,
            CodigoColegiatura
	FROM Profesor
	WHERE Codigo = @Codigo
END 
GO

