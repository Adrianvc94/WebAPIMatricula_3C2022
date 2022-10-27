USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Horario]    Script Date: 10/27/2022 4:38:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Editar_Horario]
    @Codigo int,
	@Dia VARCHAR(15),
	@HoraInicio VARCHAR(7),
	@HoraFin VARCHAR(7),
	@Sede VARCHAR(25),
	@Aula VARCHAR(15)


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Horario
			SET 
             Dia = @Dia,
             HoraInicio = @HoraInicio, 
             HoraFin = @HoraFin,
             Sede = @Sede,
             Aula = @Aula
		FROM Horario 
		WHERE Codigo = @Codigo	

		SELECT 
            Dia,
		    HoraInicio,
            HoraFin,
            Sede,
            Aula
	FROM Horario
	WHERE Codigo = @Codigo
END 
GO

