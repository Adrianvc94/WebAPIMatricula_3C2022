USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Eliminar_Estudiante]    Script Date: 10/27/2022 4:40:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Eliminar_Estudiante]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Estudiante
	WHERE Codigo = @Codigo

END 
GO

