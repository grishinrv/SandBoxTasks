# SandBoxTasks
## Build db image
change directory:
````
cd src/WebApi/db-mssql/
````
execute command:
````
docker build --no-cache -t db-price-statistics-mssql:v1 .
````
## Connect to database
Need to set:
````
trustServerCertificate=true
````
