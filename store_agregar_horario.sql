USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Agregar_Horario]    Script Date: 10/27/2022 4:36:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Agregar_Horario]
    @Dia VARCHAR(15),
	@HoraInicio VARCHAR(7),
	@HoraFin VARCHAR(7),
	@Sede VARCHAR(25),
	@Aula VARCHAR(15)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Horario(Dia, HoraInicio, HoraFin, Sede, Aula)
	SELECT 
        @Dia,
        @HoraInicio,
        @HoraFin,
        @Sede,	
		@Aula		
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

