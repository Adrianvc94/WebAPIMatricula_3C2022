USE [MatriculaULACIT_3C2022]
GO

/****** Object:  StoredProcedure [dbo].[Editar_Estudiante]    Script Date: 10/27/2022 4:38:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Editar_Estudiante]
	@Codigo INT, 
	@Identificacion VARCHAR(30), 
	@NombreCompleto VARCHAR(100),
	@CorreoElectronico VARCHAR(50),
	@Estado VARCHAR(10)


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Estudiante
			SET 	
			 Identificacion = @Identificacion,
			 NombreCompleto = @NombreCompleto,
			 CorreoElectronico = @CorreoElectronico,
			 Estado = @Estado
		FROM Estudiante 
		WHERE Codigo = @Codigo	

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

