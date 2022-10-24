USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Nota]    Script Date: 10/24/2022 4:03:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nota](
	[CodigoCurso] [int] NOT NULL,
	[CodigoEstudiante] [int] NOT NULL,
	[CodigoProfesor] [int] NOT NULL,
	[Nota] [numeric](2, 2) NOT NULL,
	[Estado] [varchar](15) NOT NULL
) ON [PRIMARY]
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

