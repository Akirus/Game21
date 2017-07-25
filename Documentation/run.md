#Running Application

Please refer to Install directory to see how to install all dependencies
Please refer to Build directory to see complete run scripts

Notes:

to run mssql we use
```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Test123$' -p 1433:1433 -d microsoft/mssql-server-linux
```