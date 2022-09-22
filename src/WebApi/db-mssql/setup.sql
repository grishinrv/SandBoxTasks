CREATE DATABASE $(MSSQL_DB);
GO
USE $(MSSQL_DB);
GO
CREATE LOGIN $(MSSQL_USER) WITH PASSWORD = '$(MSSQL_PASSWORD)';
GO
CREATE USER $(MSSQL_USER) FOR LOGIN $(MSSQL_USER);
GO
ALTER SERVER ROLE sysadmin ADD MEMBER [$(MSSQL_USER)];
GO

USE price_stat;
GO
CREATE SCHEMA [statistics];
GO
CREATE TABLE [statistics].[prices] (
    registered_time Datetime NOT NULL,
    [value] DECIMAL NOT NULL,
    city_of_registration NVARCHAR(64) NOT NULL,
    good_id int NOT NULL
);
GO

CREATE TABLE [statistics].[goods_dictionary] (
    [id] INT NOT NULL,
    [Name] NVARCHAR(64) NOT NULL
);
GO
CREATE UNIQUE INDEX [statistics].UI_goods_dictionary_name
    ON [statistics].[goods_dictionary] (Name);
GO

