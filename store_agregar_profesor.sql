USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Profesor]    Script Date: 10/27/2022 4:37:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Agregar_Profesor]
    @Identificacion varchar(30),
	@Nombre varchar(100),
	@Correo varchar(50),
	@Estado varchar(10),
	@CodigoColegiatura int
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Profesor(Identificacion, Nombre, Correo, Estado, CodigoColegiatura)
	SELECT @Identificacion,
        @Nombre,
        @Correo,
        @Estado,
        @CodigoColegiatura	
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

