# BloggingGrapeCity
Blogging backend

-BlogTables.sql contains the database structure for the blogging application.
-A database needs to be created with name Test20 and run the sql script.
-The connection string needs to be updated in the solution appsettings too.
-Username = GrapeCity Password = GrapecityRocks123 has been used in code for test purposes to get auth token. Simple bearer authentication.
-A Blog table, a user table with userId, then a user_x_blog table where we keep track which blogid corresponds to which userid
