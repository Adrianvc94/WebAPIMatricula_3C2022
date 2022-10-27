USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Todos_Errores]    Script Date: 10/27/2022 4:44:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Errores]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
				Codigo,
				CodigoUsuario,
				FechaHora,
				Modulo,
				Clase,
				Metodo,
				Fuente,
				Numero,
				Excepcion
	FROM Error
	
END 
GO

