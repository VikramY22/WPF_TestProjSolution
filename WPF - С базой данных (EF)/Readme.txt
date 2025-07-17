Для подключения к базе данных и создания первой миграции:
1) Создать свою строку подключения к mySQL, заменить ей мою в AppDbContext и соответствущей фабрике.

2)Установить Entity Framework
Для удобства:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

3)В консоли:
dotnet ef migrations add Start
dotnet ef database update

При необходимости можно расскоментировать код в AppDbContext, тогда таблицы при первой миграции будут не пустыми
