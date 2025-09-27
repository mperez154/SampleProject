# Sample Casa SGP Site

This is a sample application using Angular front end, .Net Core backend.

## Description

The front end uses Angular. 

The backend uses .Net Core for the API, with Entity Framework to connect to a MS SQL Server database. The scripts for creating the sample database are included in this repo. 

## Getting Started

### Dependencies

* DotNet Core SDK
* Docker Desktop
* Angular 19 

### Installing

* Clone the Repo
* Build the Application by clicking F5

### Running program

* Use docker-compose to start up the application locally including the database, sonarqube and other services

```
docker-compose up
```

## Database Setup
Once you have executed the docker-compose up command, grab a copy of database backup located in the docs folder and save to the SQL Server instance so you can restore a database. Sample command displayed below

```
docker cp "C:\Users\you\docs\Stocks.bak" sqlserver:/var/opt/mssql/data/
```

Once the file is there, you can restore the database following normal restore steps. 

## SonarQube Scan
Once you run docker-compose up command, you can login to SonarQube using localhost:9000 in the browser. Once logged in, you can generate a token used to connect and scan an app. For local development, set the token to never expire. 

After that, create a project and follow the prompts for .Net Core, and execute the commands in Visual Studio's command prompt. Once commands are completed,  you should have a full SonarQube scan with results showing up in the SonarQube website. 

## Authors

Contributors names and contact info

Name: [@MarcoPerez](https://www.linkedin.com/in/marco-perez-888a6325/)

## Version History

* 0.2
    * Added Footer and Header
    * See [commit change]() or See [release history]()
* 0.1
    * Initial Release