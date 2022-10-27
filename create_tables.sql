USE [ProyectoULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Colegiatura]    Script Date: 10/27/2022 4:28:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colegiatura](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Facultado] [varchar](50) NOT NULL,
	[GradoAcademico] [varchar](25) NOT NULL,
	[Acreditada] [varchar](4) NOT NULL,
 CONSTRAINT [PK_Colegiatura] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Curso](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Creditos] [varchar](25) NOT NULL,
	[CodigoHorario] [int] NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Curso_1] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Error](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Modulo] [varchar](50) NOT NULL,
	[Clase] [varchar](50) NOT NULL,
	[Metodo] [varchar](50) NOT NULL,
	[Fuente] [varchar](50) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Excepcion] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Estudiante](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
	[NombreCompleto] [varchar](100) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Horario](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [varchar](15) NOT NULL,
	[HoraInicio] [varchar](7) NOT NULL,
	[HoraFin] [varchar](7) NOT NULL,
	[Sede] [varchar](25) NULL,
	[Aula] [varchar](15) NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Matricula](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [int] NOT NULL,
	[CodigoCurso] [int] NOT NULL,
	[CodigoEstudiante] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Nota](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCurso] [int] NOT NULL,
	[CodigoEstudiante] [int] NOT NULL,
	[CodigoProfesor] [int] NOT NULL,
	[Nota] [numeric](5, 2) NOT NULL,
	[Estado] [varchar](15) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Profesor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
	[NombreCompleto] [varchar](100) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[CodigoColegiatura] [int] NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuario](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
	[NombreCompleto] [varchar](100) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[NumeroTelefono] [varchar](20) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Horario] FOREIGN KEY([CodigoHorario])
REFERENCES [dbo].[Horario] ([Codigo])
GO

ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Horario]
GO

ALTER TABLE [dbo].[Error]  WITH CHECK ADD  CONSTRAINT [FK_Error_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO

ALTER TABLE [dbo].[Error] CHECK CONSTRAINT [FK_Error_Usuario]
GO

ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Curso] FOREIGN KEY([CodigoCurso])
REFERENCES [dbo].[Curso] ([Codigo])
GO

ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Curso]
GO

ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Estudiante] FOREIGN KEY([CodigoEstudiante])
REFERENCES [dbo].[Estudiante] ([Codigo])
GO

ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Estudiante]
GO

ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO

ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Usuario]
GO

ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Curso] FOREIGN KEY([CodigoCurso])
REFERENCES [dbo].[Curso] ([Codigo])
GO

ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Curso]
GO

ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Estudiante] FOREIGN KEY([CodigoEstudiante])
REFERENCES [dbo].[Estudiante] ([Codigo])
GO

ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Estudiante]
GO

ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Profesor] FOREIGN KEY([CodigoProfesor])
REFERENCES [dbo].[Profesor] ([Codigo])
GO

ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Profesor]
GO

ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Colegiatura] FOREIGN KEY([CodigoColegiatura])
REFERENCES [dbo].[Colegiatura] ([Codigo])
GO

ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Colegiatura]
GO
