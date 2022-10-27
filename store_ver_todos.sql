USE [ProyectoULACIT_3C2022]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Ver_Todos_Colegiaturas]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Facultado,
            GradoAcademico,
            Acreditada
	FROM Colegiatura
	
END 
GO

CREATE PROCEDURE [dbo].[Ver_Todos_Cursos]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            Nombre,
            Creditos,
            CodigoHorario,
            Estado
	FROM Curso
	
END 
GO

CREATE PROCEDURE [dbo].[Ver_Todos_Errores]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
				Codigo,
				CodigoUsuario,
				FechaHora,
				Modulo,
				Clase,
				Metodo,
				Fuente,
				Numero,
				Excepcion
	FROM Error
	
END 
GO

CREATE PROCEDURE [dbo].[Ver_Todos_Estudiantes]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
			Identificacion,
			NombreCompleto,
			CorreoElectronico,
			Estado
	FROM Estudiante
	
END 
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

CREATE PROCEDURE [dbo].[Ver_Todos_Matriculas]	

AS BEGIN 
	SET NOCOUNT ON;
	SELECT 
			Codigo,
            CodigoUsuario,
            CodigoCurso,
            CodigoEstudiante,
            FechaHora

	FROM Matricula
	
END 
GO

CREATE PROCEDURE [dbo].[Ver_Todos_Profesores]	

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
	
END 
GO

CREATE PROCEDURE [dbo].[Ver_Todos_Notas]	

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
	
END 
GO
