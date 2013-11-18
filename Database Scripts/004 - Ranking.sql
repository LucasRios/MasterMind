USE [MasterMind]
GO

 --Object  Table [dbo].[Ranking]    Script Date 10112013 144205 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ranking](
	[Id_Ranking] [int] IDENTITY(1,1) NOT NULL,
	[Id_User] [int] NULL,
	[qtde_certas] [int] NOT NULL,
	[qtde_erradas] [int] NOT NULL,
	[qtde_respostas] [int] NOT NULL,
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