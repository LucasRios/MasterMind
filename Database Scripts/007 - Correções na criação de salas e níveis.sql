USE [MasterMind]
GO

ALTER TABLE Pergunta ADD Id_nivel int;

GO

ALTER TABLE [dbo].[Jogos] DROP CONSTRAINT [FK_jogo_user]
GO

ALTER TABLE [dbo].[Jogos] DROP CONSTRAINT [FK_jogo_tema]
GO

ALTER TABLE [dbo].[Jogos] DROP CONSTRAINT [FK_jogo_sala]
GO

/****** Object:  Table [dbo].[Salas]    Script Date: 13/11/2013 21:17:48 ******/
DROP TABLE [dbo].[Salas]
GO

/****** Object:  Table [dbo].[Salas]    Script Date: 13/11/2013 21:17:48 ******/
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
	[Id_nivel] [int] NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[Id_Sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Salas]  WITH CHECK ADD  CONSTRAINT [FK_sala_nivel] FOREIGN KEY([Id_nivel])
REFERENCES [dbo].[Nivel] ([id_nivel])
GO

ALTER TABLE [dbo].[Salas] CHECK CONSTRAINT [FK_sala_nivel]
GO


SET ANSI_PADDING OFF
GO

USE [MasterMind]
GO

/****** Object:  Table [dbo].[Jogos]    Script Date: 13/11/2013 21:18:10 ******/
DROP TABLE [dbo].[Jogos]
GO

/****** Object:  Table [dbo].[Jogos]    Script Date: 13/11/2013 21:18:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jogos](
	[Id_Jogo] [int] IDENTITY(1,1) NOT NULL,
	[Id_user] [int] NOT NULL,
	[Id_sala] [int] NOT NULL,
	[Id_tema] [int] NOT NULL,
 CONSTRAINT [PK_Jogos] PRIMARY KEY CLUSTERED 
(
	[Id_Jogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_jogo_sala] FOREIGN KEY([Id_sala])
REFERENCES [dbo].[Salas] ([Id_Sala])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_jogo_sala]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_jogo_tema] FOREIGN KEY([Id_tema])
REFERENCES [dbo].[Temas] ([Id_tema])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_jogo_tema]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_jogo_user] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Usuario] ([Id_user])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_jogo_user]
GO

