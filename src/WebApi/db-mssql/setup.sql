IF DB_ID ('$MSSQL_DB') IS NULL
BEGIN
  CREATE DATABASE $MSSQL_DB;
END
GO

USE $MSSQL_DB;
IF NOT EXISTS 
BEGIN
  CREATE LOGIN [$MSSQL_USER] WITH PASSWORD = '$MSSQL_PASSWORD';
  CREATE USER [$MSSQL_USER] FOR LOGIN [$MSSQL_USER];
  ALTER SERVER ROLE sysadmin ADD MEMBER [$MSSQL_USER];

  CREATE SCHEMA [statistics];

  CREATE TABLE [statistics].[prices] (
      registered_time Datetime NOT NULL,
      [value] DECIMAL NOT NULL,
      city_of_registration NVARCHAR(64) NOT NULL,
      good_id int NOT NULL
  );

  CREATE TABLE [statistics].[goods_dictionary] (
     [id] INT NOT NULL,
     [Name] NVARCHAR(64) NOT NULL
  );

  CREATE UNIQUE INDEX [statistics].UI_goods_dictionary_name
     ON [statistics].[goods_dictionary] (Name);

END

