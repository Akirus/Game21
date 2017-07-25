docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' \
    -p 1433:1433 -d \
    --volumes-from linuxsqldata \
    microsoft/mssql-server-linux
