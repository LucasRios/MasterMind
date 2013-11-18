USE [MasterMind]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 17/11/2013 15:51:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE USUARIO ADD Id_person [int]; 

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_perso] FOREIGN KEY([Id_person])
REFERENCES [dbo].[Personagens] ([Id_person])
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_perso]
GO

