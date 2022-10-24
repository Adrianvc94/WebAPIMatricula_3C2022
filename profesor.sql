USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Profesor]    Script Date: 10/24/2022 4:04:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Profesor](
	[Codigo] [int] NOT NULL,
	[Identificacion] [varchar](30) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[CodigoColegiatura] [int] NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Colegiatura] FOREIGN KEY([CodigoColegiatura])
REFERENCES [dbo].[Colegiatura] ([Codigo])
GO

ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_Colegiatura]
GO
