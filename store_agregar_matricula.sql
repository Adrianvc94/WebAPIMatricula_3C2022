USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Matricula]    Script Date: 10/27/2022 4:36:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Agregar_Matricula]
    @CodigoUsuario int,
	@CodigoCurso int,
	@CodigoEstudiante int,
	@FechaHora datetime
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Matricula(CodigoUsuario, CodigoCurso, CodigoEstudiante, FechaHora)
	SELECT 
        @CodigoUsuario,
        @CodigoCurso,
        @CodigoEstudiante,
        @FechaHora	
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

