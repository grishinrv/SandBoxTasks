FROM mcr.microsoft.com/azure-sql-edge:latest
#ENV mssql_sa=
USER root

# install gnupg2 which is required which is needed for curl 
RUN apt-get update && apt-get install -y gnupg2

# adding custom MS repository
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list

# install SQL Server drivers and tools
RUN apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools18
RUN echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> ~/.bashrc
RUN /bin/bash -c "source ~/.bashrc"

# copy scripts from local machine
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

COPY . /usr/src/app/

RUN chmod +x /usr/src/app/import-data.sh

USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh

