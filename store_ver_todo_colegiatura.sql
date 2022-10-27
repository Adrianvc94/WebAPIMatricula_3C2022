USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Todos_Colegiaturas]    Script Date: 10/27/2022 4:44:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Colegiaturas]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Facultado,
            GradoAcademico,
            Acreditada
	FROM Colegiatura
	
END 
GO

