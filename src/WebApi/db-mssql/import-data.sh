# log function
log () {
  echo "[import_data] $1"
}

# check in a loop if the SQL SERVER is up; because the timing for when the SQL instance is ready is indeterminate
for i in {1..50};
do
  /opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P $(eval echo \$\{MSSQL_SA_PASSWORD\}) -Q "SELECT * FROM sys.schemas;" -b
  if [ $? -eq 0 ]
  then
    log "SQL SERVER is ready"
      break
  else
    log "SQL SERVER is not ready yet..."
    sleep 1
  fi
done

cd import

log "run the sql scripts to create the DB, User, schema and tables"
for x in *.sql; 
do     
  log "Parsing $x environment variables..."
  envsubst < $x > temp.sql
  log "$x parsed. Executing..."
  /opt/mssql-tools18/bin/sqlcmd -S localhost -C -U sa -P $(eval echo \$\{MSSQL_SA_PASSWORD\}) -i temp.sql -b
  if [ $? -eq 0 ]
  then
    log "$x executed succesfully"
  else
    log "error executing $x"
    break
  fi
done

if [ $? -eq 0 ]
then
  log "DB setup completed succesfully"
  rm temp.sql
else
  log "DB setuo error!"
  sleep 1
fi

