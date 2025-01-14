var reader = new EnvReader();

Console.WriteLine("---- EXAMPLE (1):");
new EnvLoader()
    .EnableFileNotFoundException()
    .Load();
Console.WriteLine($"MYSQL_HOST={reader["MYSQL_HOST"]}");
Console.WriteLine($"MYSQL_DB={reader["MYSQL_DB"]}");
Console.WriteLine($"PRIVATE_KEY={reader["PRIVATE_KEY"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- SPECIAL EXAMPLE:");
var settings = new EnvBinder().Bind<AppSettings>();
Console.WriteLine($"MYSQL_HOST={settings.MysqlHost}");
Console.WriteLine($"MYSQL_DB={settings.MysqlDb}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (2):");
new EnvLoader()
    .SetBasePath("files")
    .Load();
Console.WriteLine($"MARIADB_HOST={reader["MARIADB_HOST"]}");
Console.WriteLine($"MARIADB_DB={reader["MARIADB_DB"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (3):");
new EnvLoader()
    .AddEnvFile("./files/.env.example")
    .Load();
Console.WriteLine($"MONGODB_HOST={reader["MONGODB_HOST"]}");
Console.WriteLine($"MONGODB_DB={reader["MONGODB_DB"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (4):");
new EnvLoader()
    .AddEnvFiles("files/sqlite")
    .EnableFileNotFoundException()
    .Load();
Console.WriteLine($"SQLITE_HOST={reader["SQLITE_HOST"]}");
Console.WriteLine($"SQLITE_DB={reader["SQLITE_DB"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (5):");
new EnvLoader()
    .SetDefaultEnvFileName(".env.local")
    .SetBasePath("./files/pgsql")
    .Load();
Console.WriteLine($"PGSQL_HOST={reader["PGSQL_HOST"]}");
Console.WriteLine($"PGSQL_DB={reader["PGSQL_DB"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (6):");
EnvValidationResult resultExample6;
new EnvLoader()
    .IgnoreParserException()
    .SetDefaultEnvFileName("./files/.env.local")
    .Load(out resultExample6);

Console.WriteLine($"API_KEY LENGTH={reader["API_KEY"].Length}");
Console.WriteLine(resultExample6.ErrorMessages);
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (7):");
var keyValuePairs = new EnvLoader()
                        .AvoidModifyEnvironment()
                        .AddEnvFiles(
                            "./", 
                            "./files/", 
                            "files/sqlite", 
                            "./files/pgsql/.env.local"
                          )
                        .Load();
Console.WriteLine("-> Dictionary<string, string>:");
foreach (var keyValuePair in keyValuePairs.ToDictionary())
    Console.WriteLine($"{keyValuePair.Key}, {keyValuePair.Value}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (8):");
EnvValidationResult resultExample8;
new EnvLoader()
    .SetBasePath("./files/environment")
    .AllowConcatDuplicateKeys()
    .LoadEnv(out resultExample8);
if (resultExample8.HasError())
    Console.WriteLine(resultExample8.ErrorMessages);
else
    Console.WriteLine($"CONNECTION_STRING_MSSQL={reader["CONNECTION_STRING_MSSQL"]}");
Console.WriteLine("\n\n\n");

Console.WriteLine("---- EXAMPLE (9):");
EnvValidationResult resultExample9;
var envVars = new EnvLoader()
                  .AllowConcatDuplicateKeys()
                  .SetBasePath("./files/environment")
                  .AvoidModifyEnvironment()
                  .LoadEnv(out resultExample9);

if (resultExample9.HasError())
    Console.WriteLine(resultExample9.ErrorMessages);
else
{
    foreach (var keyValuePair in envVars)
        Console.WriteLine($"{keyValuePair.Key}, {keyValuePair.Value}");
}
Console.WriteLine("\n\n\n");

Console.Write("---- EXAMPLE (10):");
EnvValidationResult resultExample10;
new EnvValidator()
    .SetRequiredKeys("SERVICE_ID", "TOKEN_ID")
    .IgnoreException()
    .Validate(out resultExample10);

Console.Write(resultExample10.ErrorMessages);
Console.WriteLine("\n\n\n");
