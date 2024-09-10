

# A quick start to your projects.

## Features
- CQRS (Command Query Responsibility Segregation) structure using MediatR
- Crud transactions with GenericRepository
- Performance database queries using IQueryable
- Unit of work and Repository dessing patten  
- DTO management with AutoMapper


## Technologies
- .NET 8: The main development language of the project.
- Entity Framework Core: Used for database operations.
- MediatR: Management of the CQRS structure.
- AutoMapper: DTO and entity conversions.
- SQL Server: Used as database.

## Installation
### Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Git
- Visual Studio or Visual Studio Code

### Steps

1. Edit the database connection settings in the **appsettings.json** file:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
    }
    ```

2. Add migration:
    ```bash
    add-migration YOURMIGRATIONNAME
    ```
    
3. Update database:
    ```bash
    update-database
    ```




### Contribute

If you would like to contribute to the project, please create a **pull request** or open an **issue**. Any feedback and contribution is valuable.
