USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Horario]    Script Date: 10/24/2022 4:17:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Horario](
	[Codigo] [int] NOT NULL,
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

