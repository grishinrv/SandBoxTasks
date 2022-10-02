USE [$MSSQL_DB];
IF NOT EXISTS ( SELECT  *
                FROM    sys.schemas
                WHERE   name = N'statistics' )
BEGIN
    EXEC('CREATE SCHEMA [statistics] AUTHORIZATION [$MSSQL_USER]');
	
    ALTER USER [$MSSQL_USER] WITH DEFAULT_SCHEMA=[statistics];
END
GO
