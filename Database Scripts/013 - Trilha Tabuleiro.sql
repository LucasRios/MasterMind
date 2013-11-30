CREATE TABLE LayoutTabuleiro(
  Id int not null identity(1,1),
  Descricao varchar(max)
  )

CREATE TABLE TrilhasTabuleiro (
  Id int not null identity(1,1),
  IdLayout int not null,
  IdTrilha int not null,
  IdSequencia int not null,
  Linha int not null,
  Coluna int not null
);
