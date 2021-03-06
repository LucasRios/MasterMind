USE [MasterMind]
GO
ALTER TABLE [dbo].[Personagens] DROP CONSTRAINT [FK_person_tema]
GO

GO
ALTER TABLE [dbo].[Personagens] DROP COLUMN [Id_tema]
GO

USE [MasterMind]
GO

USE [MasterMind]
GO

/****** Object:  Table [dbo].[Salas]    Script Date: 10/11/2013 14:25:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Salas](
	[Id_Sala] [int] IDENTITY(1,1) NOT NULL,
	[Sala] [varchar](50) NOT NULL,
	[Id_Usuario] [int] NULL,
	[Perfil] [int] NOT NULL,
	[Senha] [varchar](25) NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[Id_Sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO