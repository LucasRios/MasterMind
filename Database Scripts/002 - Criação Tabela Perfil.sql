USE [MasterMind]
GO

CREATE TABLE [dbo].[Perfil](
	[id_perfil] [int] NOT NULL,
	[descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[id_perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into perfil values(1,'Admin');

insert into perfil values(2,'Jogador');


ALTER TABLE Usuario
ADD Id_perfil int null,
CONSTRAINT FK_perfil  FOREIGN KEY(Id_perfil) REFERENCES Perfil(Id_perfil)

GO


