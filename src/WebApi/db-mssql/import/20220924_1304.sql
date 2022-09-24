USE [$MSSQL_DB];

IF NOT EXISTS 
    (SELECT TABLE_NAME 
     FROM INFORMATION_SCHEMA.TABLES
     WHERE TABLE_SCHEMA = 'statistics'
     AND TABLE_NAME = 'prices')
BEGIN
  CREATE TABLE [statistics].[prices] (
      registered_time Datetime NOT NULL
      , [value] DECIMAL NOT NULL
      , city_of_registration NVARCHAR(64) NOT NULL
      , good_id int NOT NULL
      , CONSTRAINT FK_prices_goods_dictionary FOREIGN KEY (good_id)
        REFERENCES [statistics].[goods_dictionary] (id)
        ON UPDATE CASCADE
  );

END
GO

