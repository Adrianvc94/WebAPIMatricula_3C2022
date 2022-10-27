USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Colegiatura]    Script Date: 10/27/2022 4:35:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Agregar_Colegiatura]
    @Nombre VARCHAR(50),
    @Facultado VARCHAR(50),
    @GradoAcademico VARCHAR(25),
    @Acreditada VARCHAR(4)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Colegiatura(Nombre, Facultado, GradoAcademico, Acreditada)
	SELECT 
        @Nombre,
        @Facultado,
        @GradoAcademico,
        @Acreditada	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

