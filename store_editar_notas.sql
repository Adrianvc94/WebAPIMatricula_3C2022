USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Nota]    Script Date: 10/27/2022 4:39:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Editar_Nota]
	@Codigo INT, 
	@CodigoCurso INT,
    @CodigoEstudiante INT,
    @CodigoProfesor INT,
    @Nota numeric,
    @Estado VARCHAR(10)


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Nota
			SET 
             CodigoCurso = @CodigoCurso, 
             CodigoEstudiante = @CodigoEstudiante,
             CodigoProfesor = @CodigoProfesor,
             Nota = @Nota,
             Estado = @Estado
		FROM Nota 
		WHERE Codigo = @Codigo	

		SELECT 
		 CodigoCurso,
            CodigoEstudiante,
            CodigoProfesor,
            Nota,
            Estado
	FROM Nota
	WHERE Codigo = @Codigo
END 
GO

