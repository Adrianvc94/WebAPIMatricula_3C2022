USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Curso]    Script Date: 10/27/2022 4:28:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Curso](
	[Codigo] [int] NOT NULL,
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

ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Horario] FOREIGN KEY([CodigoHorario])
REFERENCES [dbo].[Horario] ([Codigo])
GO

ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Horario]
GO

