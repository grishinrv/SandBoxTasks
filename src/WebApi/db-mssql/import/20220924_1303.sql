USE [$MSSQL_DB];

IF NOT EXISTS
    (SELECT TABLE_NAME
     FROM INFORMATION_SCHEMA.TABLES
     WHERE TABLE_SCHEMA = 'statistics'
     AND TABLE_NAME = 'goods_dictionary')
BEGIN
  CREATE TABLE [statistics].[goods_dictionary] (
     [id] INT NOT NULL
     , [Name] NVARCHAR(64) NOT NULL
     , CONSTRAINT PK_goods_dictionary PRIMARY KEY CLUSTERED (id)
  );

  CREATE UNIQUE INDEX UI_goods_dictionary_name
     ON [statistics].[goods_dictionary] (Name);

  INSERT INTO [statistics].[goods.dictionary] ([id], [Name])
  VALUES (0, 'Bread'),
    (1, 'Carrot'),
    (2, 'Eggs'),
    (3, 'Milk'),
    (4, 'Meat'),
    (5, 'Oil'),
    (6, 'Potato'),
    (7, 'Sugar'),
    (8, 'Water');

END
GO

