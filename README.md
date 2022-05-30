# _Travel.Solution_

#### By _Daniel Lindsey and Sarah Espinet_

#### API application for a travel website

## Technologies Used

- _C#_
- _.NET Framework_
- _HTML_
- _CSS_
- _Javascript_
- _jQuery_
- _MySQL_
- _Entity_
- _Linq_
- _Swagger_

## Description

This is a C# API application for a website for viewing travel destinations and destination reviews. This was build during the week with Sarah Espinet while both enrolled in the coding bootcamp program at Epicodus. This repository serves as the API portion of the application, serving data only via API requests. A separate application has been built for the front end, and can be found [here](https://github.com/dlinds/TravelClient.Solution).

<br>

You can view the Swagger documentation and endpoints for this API here: [http://travelapi.dlinds.com:6001/swagger/index.html](http://travelapi.dlinds.com:6001/swagger/index.html). If you would like to view the front end application that calls the API animals endpoint, please navigate to [http://travelclient.dlinds.com:6001](http://travelclient.dlinds.com:6001).

# Setup/Installation Requirements

## Cloning the repository

To view this application, you must clone it to your computer. To do so,

1. Locate and click the green Code button at the top of this [Repository Page](https://github.com/dlinds/Travel.Solution), and choose the option to _Download ZIP_.
2. Once downloaded, navigate to your Downloads folder and extract the contents to a location of your choosing.

## Installing C# and .NET

Once the project is downloaded to your computer, you will need to download and install C# and the .NET SDK.

1. First, download and install the .NET 5 SDK

- [Mac](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-macos-x64-installer)
- [Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.401-windows-x64-installer)

2. Once installed, open a new terminal either via Command Prompt (Windows) or Terminal (OSX).
3. Type the following command:
   - **_dotnet tool install -g dotnet-script_**
4. Next, configure your terminal environment with the following command

   - Mac: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.zshrc_**
   - Windows: **_echo 'export PATH=$PATH:~/.dotnet/tools' >> ~/.bash_profile_**
     <br>
     <br>

## Setting up the database

Prior to running the application, you will need to install MySQL and MySQL Workbench.

- During install, take note of the password you set for MySQL.
  <br>

[Mac and Windows Download Link](https://dev.mysql.com/downloads/workbench/)

## Set up appsettings.json

Next, you will need to tell the application how to create, write to, and access a database.

1. In the AnimalShelter.Solution directory, locate a file called appsettings.json
2. Add the following into the file, editing both the database name with a name of your choosing, and the password you set when installing MySql.
~~~
    {
      "Logging": {
        "LogLevel": {
          "Default": "Warning",
          "System": "Information",
          "Microsoft": "Information"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=(my_database_name);uid=root;pwd=(my password);"
      }
    }
~~~
<br>

# Run the project
  Now that everything is installed and set up, you may run the project.

1. Open up a new terminal and navigate to the AnimalShelter.Solution Folder
2. Type in the following command: **_dotnet ef database update_**
  * this will create a database with the structure needed for the application to run
3. Type in the following command: **_dotnet run_**
4. Open a web browser and navigate to http://localhost:5000

<br>

# API Documentation
  This application is a API that does not have any authentication integrated. Should you just wish to view information in the database, refer to the documentation below on any GET endpoints (just retrieving information).

  If you would like to add, edit, or delete information in the database, you will need to install Postman or another API interface application of your choosing. Alternatively, download and run the repo listed [here](https://github.com/dlinds/TravelClient.Solution), which will offer you full CRUD capabilities.

## Swagger
<hr>

This application is equipped with [Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0), which per Microsoft is

 "_a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code._"

Swagger is utilized in this application via documentation of each endpoint, parameters for end points when applicable, and viewing example requests of each route. To view the documentation created with Swagger, please navigate to http://localhost:5000/swagger/index.html once you've completed the section **_Run the project_**. Once you are viewing the Swagger page, click on any of the Animals routes to view information on the route and even test out the route as well if you'd like.


# Known Bugs

- _There is no authentication present at this time._

<br>

# License

_MIT_

Copyright (c) _3-29--2022_ _Daniel Lindsey and Daniel Lindsey_
