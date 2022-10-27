USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Colegiatura]    Script Date: 10/27/2022 4:38:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Editar_Colegiatura]
	@Codigo INT, 
	@Nombre VARCHAR(50),
    @Facultado VARCHAR(50),
    @GradoAcademico VARCHAR(25),
    @Acreditada VARCHAR(4)


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Colegiatura
			SET 
             Nombre = @Nombre, 
             Facultado = @Facultado,
             GradoAcademico = @GradoAcademico,
             Acreditada = @Acreditada
		FROM Colegiatura 
		WHERE Codigo = @Codigo	

		SELECT 
		 Nombre,
            Facultado,
            GradoAcademico,
            Acreditada
	FROM Colegiatura
	WHERE Codigo = @Codigo
END 
GO

