USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Matricula]    Script Date: 10/27/2022 4:42:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Matricula]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoUsuario,
            CodigoCurso,
            CodigoEstudiante,
            FechaHora
	FROM Matricula
	WHERE Codigo = @Codigo
END 
GO

