USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Nota]    Script Date: 10/27/2022 4:36:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Agregar_Nota]
    @CodigoCurso int,
    @CodigoEstudiante int,
    @CodigoProfesor int,
    @Nota numeric,
    @Estado VARCHAR(10)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Nota(CodigoCurso, CodigoEstudiante, CodigoProfesor, Nota, Estado)
	SELECT 
	    @CodigoCurso,
        @CodigoEstudiante,
        @CodigoProfesor,
        @Nota,
        @Estado	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

