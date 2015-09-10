# Web-Api-Sample

## Initial setup

* create an asp.net 5 Web Api project
* Install-Package EntityFramework.SqlServer –Pre
* Install-Package EntityFramework.Commands –Pre
* Install-Package EntityFramework.Core –Pre
* Update project.json
```
"commands": {
    "web": "Microsoft.AspNet.Hosting --config hosting.ini",
    "ef": "EntityFramework.Commands"
}
```
* use migrations (from command prompt inside project folder src/Web-Api-Sample)
```
dnvm use 1.0.0-beta7
dnx ef migrations add MyFirstMigration
dnx ef database update
```

## Start the api (from command prompt inside project folder src/Web-Api-Sample):
```
dnx web
```



