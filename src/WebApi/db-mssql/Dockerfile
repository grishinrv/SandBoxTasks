FROM mcr.microsoft.com/azure-sql-edge:latest
#ENV mssql_sa=
USER root

RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

COPY . /usr/src/app/

RUN chmod +x /usr/src/app/import-data.sh

USER sa
ENTRYPOINT /bin/bash ./entrypoint.sh

