USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Estudiante]    Script Date: 10/27/2022 4:42:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Estudiante]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
			Identificacion,
			NombreCompleto,
			CorreoElectronico,
			Estado
	FROM Estudiante
	WHERE Codigo = @Codigo
END 
GO

