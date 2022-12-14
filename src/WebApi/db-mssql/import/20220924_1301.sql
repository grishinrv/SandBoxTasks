USE [$MSSQL_DB];
IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = '$MSSQL_USER')
BEGIN
  CREATE LOGIN [$MSSQL_USER] WITH PASSWORD = '$MSSQL_PASSWORD';
  CREATE USER [$MSSQL_USER] FOR LOGIN [$MSSQL_USER];
  
  ALTER ROLE db_datareader ADD MEMBER [$MSSQL_USER];
  ALTER ROLE db_datawriter ADD MEMBER [$MSSQL_USER];

END
GO

