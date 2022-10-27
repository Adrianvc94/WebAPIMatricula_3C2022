USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Error]    Script Date: 10/27/2022 4:35:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Agregar_Error]
	@CodigoUsuario INT,
	@FechaHora Datetime, 
	@Modulo VARCHAR(50), 
	@Clase VARCHAR(50), 
	@Metodo VARCHAR(50),
	@Fuente VARCHAR(100),
	@Numero INT,
	@Excepcion VARCHAR(max)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Error(
				CodigoUsuario,
				FechaHora,
				Modulo,
				Clase,
				Metodo,
				Fuente,
				Numero,
				Excepcion)
	SELECT 
				@CodigoUsuario,
				@FechaHora,
				@Modulo,
				@Clase,
				@Metodo,
				@Fuente,
				@Numero,
				@Excepcion	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 

GO

