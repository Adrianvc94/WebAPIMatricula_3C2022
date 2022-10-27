USE [ProyectoULACIT_3C2022]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Detalle_Colegiatura]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Facultado,
            GradoAcademico,
            Acreditada
	FROM Colegiatura
	WHERE Codigo = @Codigo
END 
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Curso]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Creditos,
            CodigoHorario,
            Estado
	FROM Curso
	WHERE Codigo = @Codigo
END 
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Estudiante]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
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

CREATE PROCEDURE [dbo].[Ver_Detalle_Horario]	
	@Codigo INT
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
	WHERE Codigo = @Codigo
END 
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Matricula]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoUsuario,
            CodigoCurso,
            CodigoEstudiante,
            FechaHora
	FROM Matricula
	WHERE Codigo = @Codigo
END 
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Nota]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoCurso,
            CodigoEstudiante,
            CodigoProfesor,
            Nota,
            Estado
	FROM Nota
	WHERE Codigo = @Codigo
END 
GO

CREATE PROCEDURE [dbo].[Ver_Detalle_Profesor]	
	@Codigo INT
AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Identificacion,
             Nombre,
            Correo,
            Estado,
            CodigoColegiatura
	FROM Profesor
	WHERE Codigo = @Codigo
END 
GO

