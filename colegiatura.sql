USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Colegiatura]    Script Date: 10/24/2022 4:02:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colegiatura](
	[Codigo] [int] NOT NULL,
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

