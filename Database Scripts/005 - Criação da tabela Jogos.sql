USE [MasterMind]
GO

/****** Object:  Table [dbo].[Jogos]    Script Date: 10/11/2013 21:05:57 ******/
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

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_jogo_user] FOREIGN KEY([Id_user])
REFERENCES [dbo].[Usuario] ([Id_user])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_jogo_user]
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

