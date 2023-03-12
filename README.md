# Company.API

## Setup guide

- Install .NET 6 SDK: Before starting with the setup, you need to ensure that .NET 6 SDK is installed on your machine. You can download the latest version from the .NET downloads page: https://dotnet.microsoft.com/download/dotnet/6.0

- Clone the Repository: Clone the repository from: https://github.com/abrankovan/CompanyAPI.git

- Build the Application: Once you have cloned the repository, navigate to the project directory and build the application using the following command(from directory where CompanyAPI.sln file is located ):

    ```
    dotnet build
    ```

- Configure the Database: Application is using sqlite db and db file is already in the repository.

- Run the Application: After completing the above steps, you can start the application using the following command:

    ```
	cd CompanyAPI
    dotnet run
    ```

- Test the API: Once the application is up and running, you can test the API using any Swagger on this URL: https://localhost:7155/swagger/index.html

## Folder structure:
- Controllers: This directory contains all controller classes where all endpoints are stored. There is a controller class for each  entity. 
- DbContext: Here is CompanyContext class where is located context to the database. A DbContext instance represents a session with the database.
- Dtos: All dtos which are used in controller classes are stored here. They are grouped in separate directories based on their entity class.
- Entities: here are placed Employee and Task entities, also Department entity which I introduced
- Enums: all enums which are created are located in this directory
- Migrations: migrations which are created during the implementation of this project are stored in this directory.
- Models: all custom models which are used for internal application logic are stored here
- Profiles: In this project I was working with AutoMapper which is a library which helps to map objects between layers. All mappings are stored here.
- Services: All repository classes and services including their interfaces are stored here. I created a repository class for every entity and StatisticsService where I located methods for getting statistics.

## Additional functionalities
- Department entity - idea of this entity is to group employees with the department where they work. There is also some more information about the department itself. Also, the idea was to represent the real structure of some company.

- Statistics for each department - these statistics include number of total employees in department, number of total tasks created inside department, also number of done, failed and in progress tasks. This statistics can be used for comparison between departments and in the future can be extended with new data. Also, in the future this functionality can be parametrized so it can return data for the target time period.
