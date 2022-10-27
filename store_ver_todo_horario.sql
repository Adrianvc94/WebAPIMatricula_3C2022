USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Ver_Todos_Horarios]    Script Date: 10/27/2022 4:45:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Horarios]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Dia,
            HoraInicio,
            HoraFin,
            Sede,
            Aula
	FROM Horario
	
END 
GO

