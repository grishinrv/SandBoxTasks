#run the setup script to create the DB and the schema in the DB
echo "Parsing setup.sql environment variables..."
envsubst < setup.sql > setup_parsed.sql
echo "setup.sql parsed. Executing..."

#do this in a loop because the timing for when the SQL instance is ready is indeterminate
for i in {1..50};
do
    /opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P $(eval echo \$\{MSSQL_SA_PASSWORD\}) -i setup_parsed.sql
    if [ $? -eq 0 ]
    then
        echo "DB setup completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done
