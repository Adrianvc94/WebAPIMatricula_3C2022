USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Estudiante]    Script Date: 10/27/2022 4:35:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Agregar_Estudiante]
	@Identificacion VARCHAR(30), 
	@NombreCompleto VARCHAR(100),
	@CorreoElectronico VARCHAR(50),
	@Estado VARCHAR(10)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Estudiante(Identificacion, NombreCompleto, CorreoElectronico, Estado)
	SELECT 
		@Identificacion, 
		@NombreCompleto, 
		@CorreoElectronico,
		@Estado		
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

