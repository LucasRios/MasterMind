-- TRUNCATE TABLE  LayoutTabuleiro
-- TRUNCATE TABLE  TrilhasTabuleiro
-- SELECT * FROM LayoutTabuleiro
-- SELECT * FROM TrilhasTabuleiro
DECLARE @Layout VARCHAR(50) = '12 Jogadores, 4 Perguntas mesmo Tema';
DECLARE @IdLayout int;
DECLARE @IdTrilha INT;

INSERT INTO LayoutTabuleiro (Descricao) VALUES (@Layout);
SET @IdLayout = SCOPE_IDENTITY()

SET @IdTrilha = 1;
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 01, 0, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 02, 1, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 03, 2, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 04, 3, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 05, 4, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 06, 4, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 07, 4, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 08, 4, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 09, 5, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 10, 6, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 11, 7, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 12, 8, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 13, 8, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 14, 8, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 15, 8, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 16, 8, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 17, 7, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 18, 6, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 19, 5, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 20, 4, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 21, 4, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 22, 6, 6);

SET @IdTrilha = 2;
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 01, 0, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 02, 1, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 03, 2, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 04, 3, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 05, 4, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 06, 4, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 07, 4, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 08, 5, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 09, 6, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 10, 7, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 11, 8, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 12, 8, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 13, 8, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 14, 8, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 15, 8, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 16, 7, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 17, 6, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 18, 5, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 19, 4, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 20, 4, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 21, 4, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 22, 6, 6);

SET @IdTrilha = 3;
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 01, 0, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 02, 1, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 03, 2, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 04, 3, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 05, 4, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 06, 4, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 07, 5, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 08, 6, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 09, 7, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 10, 8, 8);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 11, 8, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 12, 8, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 13, 8, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 14, 8, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 15, 7, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 16, 6, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 17, 5, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 18, 4, 4);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 19, 4, 5);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 20, 4, 6);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 21, 4, 7);
INSERT INTO TrilhasTabuleiro (IdLayout, IdTrilha, IdSequencia, Linha, Coluna) VALUES (@IdLayout, @IdTrilha, 22, 6, 6);
