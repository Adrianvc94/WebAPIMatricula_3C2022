USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Todos_Matriculas]    Script Date: 10/27/2022 4:45:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Matriculas]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoUsuario,
            CodigoCurso,
            CodigoEstudiante,
            FechaHora

	FROM Matricula
	
END 
GO

