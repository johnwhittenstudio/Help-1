# **HELP**

#### _a C# MVC User-reviewed restaurant app to keep track of students and courses._

#### by **Erin McCulley & John Whitten**

#### March 20, 2022

## Technologies Used

- C#
- .NET 5.0
- REPL
- MySQL
- Razor
- ASP.NET Core

## Description

An app for a user to review restaurants in various cities.

### Schema

![Schema](./Help/wwwroot/img/schema1.png)

## Project Setup/Installation Instructions

### Install C#, .NET, MySQL Community Server and MySQL Workbench

- Open the terminal on your local machine
- If [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) and [.NET](https://docs.microsoft.com/en-us/dotnet/) are not installed on your local device, follow the instructions here [here](https://www.learnhowtoprogram.com/c-and-net-part-time/getting-started-with-c/installing-c-and-net).
- If [MySQL Community Server](https://dev.mysql.com/downloads/mysql/) and [MySQL Workbench](https://www.mysql.com/products/workbench/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time/getting-started-with-c/installing-and-configuring-mysql).

### Clone the project

- Open the terminal on your local computer.
- Navigate to the parent directory of your preference.
- Clone this project using `$ git clone https://github.com/johnwhittenstudio/Help.Solution`
- Navigate to the directory: `$ cd Help.Solution`
- Open in Vs code: `$ code .`

### Import and connect the database

- Launch the MySQL server with the command `mysql -uroot -p[YOUR-PASSWORD-HERE]`
- After the server starts running, open MySQL Workbench.
- Select the MySQL instance in the _MySQLConnections_ section.
- Select the **Navigator>Administration** tab.
- In the Navigator>Administration window, select **Data Import/Restore**; the Data Import window will open.
- In the **Import Options** section of the Data Import window, select **Import from Self-Contained File**.
- Click the dots at the end of the **Import from Self-Contained** file field (three dots for windows, two dots for Mac) and a pop up box will open. In the pop up box, navigate to the `help.sql` file in the root directory of the project (BestRest.Solution/). Once correct file is selected, click open. The pop up box will close itself.
- In the **Default Schema to be Imported To**, select the **New** button.
- In the pop up box, name the schema `help`. Click **Ok**.
- Navigate to the tab called **Import Progress** and click **Start Import** at the bottom right corner of the window.
- After you are finished with the above steps, reopen the **Navigator > Schemas** tab. Right click and select **Refresh All**. Your new test database will appear.
- Navigate to BestRest: `$ cd Help` and type the following command in the terminal `$ touch appsettings.json`
- In the appsettings.json file enter the following code:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=help;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
}
```

### Run the project

- Navigate to BestRest: `$ cd Help` and type the following command in the terminal `$ dotnet restore`
- Build the program with the command `$ dotnet build`
- Run the program with the command `$ dotnet run`

## Known Bugs

- _Would like to get the restaurant name to display in the Reviews/Details View._

## License

[MIT License](https://opensource.org/licenses/MIT) © 2022 _Erin McCulley & John Whitten_

## Contact

Erin McCulley: [ejmcculley@gmail.com](mailto:ejmcculley@gmail.com)<br>
John Whitten: [johnwhitten.studio@gmail.com](mailto:johnwhitten.studio@gmail.com)
