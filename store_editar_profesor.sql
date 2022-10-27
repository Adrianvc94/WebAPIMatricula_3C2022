USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Profesor]    Script Date: 10/27/2022 4:39:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Editar_Profesor]
    @Codigo int,
    @Identificacion varchar(30),
	@Nombre varchar(100),
	@Correo varchar(50),
	@Estado varchar(10),
	@CodigoColegiatura int


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Profesor
			SET 
            Identificacion = @Identificacion,
             Nombre = @Nombre,
             Correo = @Correo, 
             Estado = @Estado,
             CodigoColegiatura = @CodigoColegiatura
		FROM Profesor 
		WHERE Codigo = @Codigo	

		SELECT 
            Identificacion,
             Nombre,
            Correo,
            Estado,
            CodigoColegiatura
	FROM Profesor
	WHERE Codigo = @Codigo
END 
GO

