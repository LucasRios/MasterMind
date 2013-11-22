USE [MasterMind]
GO

/****** Object:  Table [dbo].[Ranking]    Script Date: 21/11/2013 23:49:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Drop Table Ranking;

CREATE TABLE [dbo].[Ranking](
	[Id_Ranking] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NULL,
    [qtde_partidas_ganhas] [int] NULL,
	[qtde_certas] [int] NULL,
	[qtde_erradas] [int] NULL,
	[qtde_respostas] [int] NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[Id_Ranking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Ranking]  WITH CHECK ADD  CONSTRAINT [FK_ranking] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Usuario] ([Id_user])
GO

ALTER TABLE [dbo].[Ranking] CHECK CONSTRAINT [FK_ranking]
GO

