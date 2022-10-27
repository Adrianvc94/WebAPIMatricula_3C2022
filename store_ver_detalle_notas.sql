USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Nota]    Script Date: 10/27/2022 4:43:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Nota]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoCurso,
            CodigoEstudiante,
            CodigoProfesor,
            Nota,
            Estado
	FROM Nota
	WHERE Codigo = @Codigo
END 
GO

