# Preparing environment for developers

To build and run application you need to install environment first. 

* Install docker.
* Install dotnet-core.
* Pull [microsoft/mssql-server-linux](https://hub.docker.com/r/microsoft/mssql-server-linux/) docker image.
* Pull [microsoft/aspnetcore](https://hub.docker.com/r/microsoft/aspnetcore/) docker image
* from build directory run ./create-network.sh
* run dotnet restore
* Create sql server distributed cache using command 
```
dotnet sql-cache create "Data Source=tcp:localhost,1433;Initial Catalog=game21;Integrated Security=False;User Id=sa;Password=Test123$;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True" "dbo" "Sessions"
```
* [Please refer run documentation](../Documentation/build&run.md)

