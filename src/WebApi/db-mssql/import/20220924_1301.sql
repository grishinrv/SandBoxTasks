USE [$MSSQL_DB];

IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'statistics' )
    EXEC('CREATE SCHEMA [statistics]');
GO

IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'LoginName')
BEGIN
  CREATE LOGIN [$MSSQL_USER] WITH PASSWORD = '$MSSQL_PASSWORD';
  CREATE USER [$MSSQL_USER] FOR LOGIN [$MSSQL_USER];
  
  ALTER ROLE db_datareader ADD MEMBER [$MSSQL_USER];
  ALTER ROLE db_datawriter ADD MEMBER [$MSSQL_USER];

  ALTER USER [$MSSQL_USER] WITH DEFAULT_SCHEMA = 'statistics';
END
GO

