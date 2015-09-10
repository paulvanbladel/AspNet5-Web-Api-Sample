# Web-Api-Sample

## Initial setup

* create an asp.net 5 Web Api project
* Install-Package EntityFramework.SqlServer –Pre
* Install-Package EntityFramework.Sqlite –Pre
* Install-Package EntityFramework.InMemory –Pre
* Install-Package EntityFramework.Commands –Pre
* Install-Package EntityFramework.Core –Pre
* Update project.json
```
"commands": {
    "web": "Microsoft.AspNet.Hosting --config hosting.ini",
    "ef": "EntityFramework.Commands",
    "Kestrel": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.Kestrel --server.urls http://localhost:5000"
}
```
* use migrations (from command prompt inside project folder src/Web-Api-Sample)
```
dnvm use 1.0.0-beta7
dnx ef migrations add MyFirstMigration
dnx ef database update
```

## Start the api (from command prompt inside project folder src/Web-Api-Sample):
* when running on windows
```
dnx web
```
* when running on linux
```
dnx Kestrel
```



