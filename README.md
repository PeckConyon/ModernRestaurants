# ModernRestaurants
This is a C#  Windows from application developed along with AIML (Artificial Intelligence Markup Language)

# DesignPartens-

Asp .net Core 2.0
### Create Database using Sql Server 

```Database name - "YourDatabaseName"```

### Change Coonection String According Your Sql Server

### change Statup.cs file'

```var connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True";```
```services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connectionString));```

### Add migreation cmd using package manager console (go UnitOfWorkWithRepositoryPartens.Data using package manager console)

```Add-Migration InitialCreate```
```Update-Database```

### Run Application 
