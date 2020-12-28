# CompanyWebAPI

CompanyWebAPI is a dockerized project having tinywebapi containg multiple methods to use . This contains two projects WebAPI project and Docker Compose project.Docker Compose project can be used to run the Web API and Sql Server in a containerized format together.

Following are the methods available in CompanyWebAPI.Project contains Swagger File which would list down the following methods

 1. Create new Company
 
 2. Get a list of all companies
 
 3. Get details about a company
 
 4. Update a company
 
 5. Add a owner of the company
 
 6. Check of Social Security Number

Currently this project doesn't uses Authentication or Authorization. But we can extend this project to Use Claims based Authentication.

## Installation

This project is built on dotnet core 3.1 framework.Inorder to run this project in local ,one has to install dotnetcore 3.1 SDK from Microsoft Website


## Usage

```companyWebAPI
  For running Company Web API alone : dotnet run CompanyWebAPI

Since It is a dockerized project one has to run the following command so that both sql server and webapi project.

docker-compose up

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)