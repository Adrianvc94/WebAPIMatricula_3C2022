USE [ProyectoULACIT_3C2022]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Agregar_Colegiatura]
    @Nombre VARCHAR(50),
    @Facultado VARCHAR(50),
    @GradoAcademico VARCHAR(25),
    @Acreditada VARCHAR(4)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Colegiatura(Nombre, Facultado, GradoAcademico, Acreditada)
	SELECT 
        @Nombre,
        @Facultado,
        @GradoAcademico,
        @Acreditada	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Curso]
    @Nombre varchar(50),
	@Creditos varchar(25),
	@CodigoHorario int,
	@Estado varchar(10)
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Curso(Nombre, Creditos, CodigoHorario, Estado)
	SELECT
        @Nombre,
        @Creditos,
        @CodigoHorario,
        @Estado	
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Error]
	@CodigoUsuario INT,
	@FechaHora Datetime, 
	@Modulo VARCHAR(50), 
	@Clase VARCHAR(50), 
	@Metodo VARCHAR(50),
	@Fuente VARCHAR(100),
	@Numero INT,
	@Excepcion VARCHAR(max)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Error(
				CodigoUsuario,
				FechaHora,
				Modulo,
				Clase,
				Metodo,
				Fuente,
				Numero,
				Excepcion)
	SELECT 
				@CodigoUsuario,
				@FechaHora,
				@Modulo,
				@Clase,
				@Metodo,
				@Fuente,
				@Numero,
				@Excepcion	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 

GO

CREATE PROCEDURE [dbo].[Agregar_Estudiante]
	@Identificacion VARCHAR(30), 
	@NombreCompleto VARCHAR(100),
	@CorreoElectronico VARCHAR(50),
	@Estado VARCHAR(10)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Estudiante(Identificacion, NombreCompleto, CorreoElectronico, Estado)
	SELECT 
		@Identificacion, 
		@NombreCompleto, 
		@CorreoElectronico,
		@Estado		
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Horario]
    @Dia VARCHAR(15),
	@HoraInicio VARCHAR(7),
	@HoraFin VARCHAR(7),
	@Sede VARCHAR(25),
	@Aula VARCHAR(15)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Horario(Dia, HoraInicio, HoraFin, Sede, Aula)
	SELECT 
        @Dia,
        @HoraInicio,
        @HoraFin,
        @Sede,	
		@Aula		
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Matricula]
    @CodigoUsuario int,
	@CodigoCurso int,
	@CodigoEstudiante int,
	@FechaHora datetime
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Matricula(CodigoUsuario, CodigoCurso, CodigoEstudiante, FechaHora)
	SELECT 
        @CodigoUsuario,
        @CodigoCurso,
        @CodigoEstudiante,
        @FechaHora	
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Nota]
    @CodigoCurso int,
    @CodigoEstudiante int,
    @CodigoProfesor int,
    @Nota numeric,
    @Estado VARCHAR(10)
	
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Nota(CodigoCurso, CodigoEstudiante, CodigoProfesor, Nota, Estado)
	SELECT 
	    @CodigoCurso,
        @CodigoEstudiante,
        @CodigoProfesor,
        @Nota,
        @Estado	
				
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO

CREATE PROCEDURE [dbo].[Agregar_Profesor]
    @Identificacion varchar(30),
	@NombreCompleto varchar(100),
	@CorreoElectronico varchar(50),
	@Estado varchar(10),
	@CodigoColegiatura int
AS BEGIN 
	SET NOCOUNT ON;		

	INSERT INTO Profesor(Identificacion, NombreCompleto, CorreoElectronico, Estado, CodigoColegiatura)
	SELECT @Identificacion,
        @NombreCompleto,
        @CorreoElectronico,
        @Estado,
        @CodigoColegiatura	
	SELECT SCOPE_IDENTITY() AS Codigo
		
END 
GO
