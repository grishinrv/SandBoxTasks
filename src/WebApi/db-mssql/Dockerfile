FROM mcr.microsoft.com/azure-sql-edge:latest
#ENV mssql_sa=
USER root

# install gettext peckeage for envsubst support
RUN \
  apt-get update \
  && apt-get install gettext-base

# install gnupg2 which is required which is needed for curl 
RUN apt-get install -y gnupg2

# adding custom MS repository
RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
RUN curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list

# install SQL Server drivers and tools
RUN apt-get update && ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools18
RUN echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> ~/.bashrc
RUN /bin/bash -c "source ~/.bashrc"

# clean cashes
RUN apt-get clean && rm -rf /var/lib/apt/lists*

RUN mkdir -p /usr/src/app/import
WORKDIR /usr/src/app
COPY . /usr/src/app
RUN chmod +x /usr/src/app/import-data.sh

# copy scripts from local machine
# WORKDIR /usr/src/app/import
# COPY . /usr/src/app/import

# create a file where we will store setup.sql content after parsing
RUN touch temp.sql
RUN chown mssql temp.sql


USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh

