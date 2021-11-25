## Adding migrations (Visual Studio):

#### Add-Migration [MigrationName] -Context [DbContextName] -OutputDir [OutputFolder]

[MigrationName] - CammelCase\
[OutputFolder] - “EF/Migrations”

Example:  
Add-Migration AddMenuModel -Context MenusDbContext -OutputDir “EF/Migrations”

## Adding migrations (Rider):

Go to src\Bootstrapper\ModularRestaurant.Bootstrapper
#### dotnet ef migrations add [MigrationName] --project ..\\..\Modules\\[ModuleName]\ModularRestaurant.[ModuleName].Infrastructure\ --context [ModuleName]DbContext --output-dir [OutputFolder]

[MigrationName] - CammelCase\
[OutputFolder] - “EF/Migrations”

Example:  
dotnet ef migrations add AddMenuModel --project ..\..\Modules\Menus\ModularRestaurant.Menus.Infrastructure\ --context MenusDbContext --output-dir "EF/Migrations"
