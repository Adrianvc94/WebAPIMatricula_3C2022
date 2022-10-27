USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Matricula]    Script Date: 10/27/2022 4:38:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Editar_Matricula]
    @Codigo int,
    @CodigoUsuario int,
	@CodigoCurso int,
	@CodigoEstudiante int,
	@FechaHora datetime


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Matricula
			SET 
             CodigoUsuario = @CodigoUsuario,
             CodigoCurso = @CodigoCurso, 
             CodigoEstudiante = @CodigoEstudiante,
             FechaHora = @FechaHora
		FROM Matricula 
		WHERE Codigo = @Codigo	

		SELECT 
            CodigoUsuario,
		    CodigoCurso,
            CodigoEstudiante,
            FechaHora
	FROM Matricula
	WHERE Codigo = @Codigo
END 
GO

