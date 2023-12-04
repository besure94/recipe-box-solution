# Recipe Box

#### A web application that allows a user to manage their favorite recipes.

#### By Brian Scherner

## Technologies Used

* C#
* .NET
* ASP.NET MVC
* MySQL
* EF Core
* EF Migrations

## Description

This application allows presents users with a splash page containing their favorite recipes, and tags that they can use to categorize them. In order to access features other than simply viewing the app, users must create an account by navigating to a link to a form, where they can create an account.

Once an account is created, the user can login. They can then create recipes and tags. Users can also edit recipes/tags, delete recipes/tags, rate recipes, and search for recipes by ingredients when they are logged in. They can also delete individual recipes and/or tags by viewing a recipe or tags details. If the user logs out, they cannot use any of these features.

## Setup Instructions

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-01-welcome-to-c).

### Set Up and Run Project

1. Clone this repository to your desktop.
2. Open the terminal and navigate to this project's production directory called `RecipeBox`.
3. Within the `RecipeBox` directory, create a new file called `appsettings.json`.
4. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. For the LearnHowToProgram.com lessons, always assume the `uid` is `root` and the `pwd` is `epicodus`. You can use the database name below, or name it whatever you like.

```json
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=recipe_box_with_auth;uid=root;pwd=epicodus;"
    }
}
```

5. Open your terminal to the production directory called `RecipeBox`, and run `dotnet ef database update`. This will create the database using the migrations located inside this project's `Migrations` folder. You should now see the database in your MySQL workbench.
    * If you need to create your own migration, run the command `dotnet ef migrations add MigrationName`. The migration name should be specific and in UpperCamelCaseFormat.
6. Within the production directory called `RecipeBox`, run `dotnet watch run` in the command line to start the project in development mode with a watcher.
7. Open the browser to [https://localhost:5001](https://localhost:5001). If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this LearnHowToProgram.com lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-2-basic-web-applications/3-2-0-17-redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

Application is fully functional.

## License

MIT

Copyright(c) 2023 Brian Scherner
