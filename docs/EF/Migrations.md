## Adding migrations:

#### Add-Migration [MigrationName] -Context [DbContextName] -OutputDir [OutputFolder]

[MigrationName] - CammelCase\
[OutputFolder] - “EF/Migrations”

Example:  
Add-Migration AddMenuModel -Context MenusDbContext -OutputDir “EF/Migrations”
