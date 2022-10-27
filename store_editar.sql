USE [ProyectoULACIT_3C2022]
GO

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

CREATE PROCEDURE [dbo].[Editar_Curso]
    @Codigo int,
    @Nombre varchar(50),
	@Creditos varchar(25),
	@CodigoHorario int,
	@Estado varchar(10)


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Curso
			SET 
             Nombre = @Nombre,
             Creditos = @Creditos, 
             CodigoHorario = @CodigoHorario,
             Estado = @Estado
		FROM Curso 
		WHERE Codigo = @Codigo	

		SELECT 
            Nombre,
            Creditos,
            CodigoHorario,
            Estado
	FROM Curso
	WHERE Codigo = @Codigo
END 
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

CREATE PROCEDURE [dbo].[Editar_Profesor]
    @Codigo int,
    @Identificacion varchar(30),
	@NombreCompleto varchar(100),
	@CorreoElectronico varchar(50),
	@Estado varchar(10),
	@CodigoColegiatura int


AS BEGIN 
	SET NOCOUNT ON;

		UPDATE Profesor
			SET 
            Identificacion = @Identificacion,
             NombreCompleto = @NombreCompleto,
             CorreoElectronico = @CorreoElectronico, 
             Estado = @Estado,
             CodigoColegiatura = @CodigoColegiatura
		FROM Profesor 
		WHERE Codigo = @Codigo	

		SELECT 
            Identificacion,
            NombreCompleto,
            CorreoElectronico,
            Estado,
            CodigoColegiatura
	FROM Profesor
	WHERE Codigo = @Codigo
END 
GO
