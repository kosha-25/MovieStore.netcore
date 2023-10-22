=>Code is in branch my-new-branch.

# MovieStore.netcore
We implemented this project using asp.net core 6.

- Open appsetting.json
- configure connection string according to your database connection.
- then download packages from Tools/Nuget package manager/Manage NuGet packages for solution...
  ->Browse and install these packages:
  Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.Design
  Microsoft.EntityFrameworkCore.SqlServer
  Microsoft.EntityFrameworkCore.Tools
  Microsoft.AspNetCore.Identity.EntityFrameworkCore

- open package manager console then run this commands:
  ->add-migration "my_new_setup"
  ->update-database

- then start debugging (F5).
