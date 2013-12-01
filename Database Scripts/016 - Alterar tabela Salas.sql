ALTER TABLE Salas ADD IdPerguntaAtual INT not null default 0;
ALTER TABLE Salas ADD DataPergunta DATETIME null;
ALTER TABLE Salas ADD DataResposta DATETIME null;