USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Eliminar_Profesor]    Script Date: 10/27/2022 4:41:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Eliminar_Profesor]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO

