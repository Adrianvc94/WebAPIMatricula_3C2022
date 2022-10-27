USE [MatriculaULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Error]    Script Date: 10/27/2022 4:27:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

ALTER TABLE [dbo].[Error]  WITH CHECK ADD  CONSTRAINT [FK_Error_Usuario] FOREIGN KEY([CodigoUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
GO

ALTER TABLE [dbo].[Error] CHECK CONSTRAINT [FK_Error_Usuario]
GO

