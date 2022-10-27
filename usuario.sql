USE [ProyectoULACIT_3C2022]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 10/27/2022 4:26:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

