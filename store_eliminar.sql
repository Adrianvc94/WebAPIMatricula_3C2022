USE [MatriculaULACIT_3C2022]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Eliminar_Colegiatura]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Curso]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Curso
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Estudiante]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Estudiante
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Horario]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Matricula]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Nota]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO

CREATE PROCEDURE [dbo].[Eliminar_Profesor]
	@Codigo INT
	
AS BEGIN 
	SET NOCOUNT ON;

	DELETE 
	FROM Nota
	WHERE Codigo = @Codigo

END 
GO
