USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Detalle_Colegiatura]    Script Date: 10/27/2022 4:41:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Colegiatura]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Facultado,
            GradoAcademico,
            Acreditada
	FROM Colegiatura
	WHERE Codigo = @Codigo
END 
GO

