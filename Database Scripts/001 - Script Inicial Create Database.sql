CREATE DATABASE MasterMind
GO

USE MasterMind
GO

CREATE TABLE Temas (
    Id_tema         INT           NOT NULL IDENTITY(1,1),
    Desc_tema       VARCHAR(15)   NOT NULL,
    CONSTRAINT PK_Func_tema PRIMARY KEY(Id_tema),
)
GO

CREATE TABLE Personagens (
    Id_person         INT           NOT NULL IDENTITY(1,1),
    Desc_person       VARCHAR(15)   NOT NULL,
    CONSTRAINT PK_Func_person PRIMARY KEY(Id_person),
)
GO

CREATE TABLE Pergunta (
    Id_Perg          INT           NOT NULL IDENTITY(1,1),
    Txt_Perg         VARCHAR(256)  NOT NULL,
    CONSTRAINT PK_Func_Perg PRIMARY KEY(Id_Perg)
)
GO

CREATE TABLE Resposta (
    Id_resp         INT           NOT NULL IDENTITY(1,1),
    Resp_txt        VARCHAR(30)   NOT NULL,
    OpcaoCerta      BIT           NOT NULL DEFAULT 0
    CONSTRAINT PK_Func_Resp PRIMARY KEY(Id_resp),
)
GO

CREATE TABLE Usuario (
    Id_user          INT           NOT NULL IDENTITY(1,1),
    Nome             VARCHAR(20)   NOT NULL,
    Sobrenome        Varchar(30)   NOT NULL,
    Email            Varchar(64)   Not Null,
    Senha            Varchar(20)   NOT NULL,
    Dt_nasc          char(10)      NOT NULL,
    Pais             Varchar(30)   NOT NULL,
    Cidade           Varchar(30)   NOT NULL,
    Estado           Varchar(30)   NOT NULL,
    Sexo             Char(1)       NOT NULL
    CONSTRAINT PK_Func_User PRIMARY KEY(Id_user),
)
GO

CREATE TABLE Perg_Resp (
    Id_perg          INT           NOT NULL,
    Id_resp          INT           NOT NULL,
    CONSTRAINT PK_Func_PergResp PRIMARY KEY(Id_perg, Id_resp),
    CONSTRAINT FK_Func_perg  FOREIGN KEY(Id_perg) REFERENCES Pergunta(Id_Perg),
    CONSTRAINT FK_Func_resp  FOREIGN KEY(Id_resp) REFERENCES Resposta(Id_resp)
)
GO

CREATE TABLE Pers_Tema (
    Id_pers          INT           NOT NULL,
    Id_tema          INT           NOT NULL,
    CONSTRAINT PK_Func_PersTema PRIMARY KEY(Id_pers, Id_tema),
    CONSTRAINT FK_Func_pers  FOREIGN KEY(Id_pers) REFERENCES Personagens(Id_Person),
    CONSTRAINT FK_Func_tema  FOREIGN KEY(Id_tema) REFERENCES Temas(Id_tema)
)
GO

CREATE TABLE Perg_Tema (
    Id_perg          INT           NOT NULL,
    Id_tema          INT           NOT NULL,
    CONSTRAINT PK_Func_PergTema PRIMARY KEY(Id_perg, Id_tema),
    CONSTRAINT FK_Func_perg2  FOREIGN KEY(Id_perg) REFERENCES Pergunta(Id_Perg),
    CONSTRAINT FK_Func_tema2  FOREIGN KEY(Id_tema) REFERENCES Temas(Id_tema)
)
GO
