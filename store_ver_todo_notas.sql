USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Todos_Notas]    Script Date: 10/27/2022 4:45:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Notas]	

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
	
END 
GO

