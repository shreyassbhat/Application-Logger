# Application-Logger
Application Logger

 Log4net is an open source .net library to log output to a variety of sources like console, SMTP, Plain text, Database etc. Log4net is a port of the popular log4J library used in Java. Log4net developed by Apache Foundation. Full details of log4net can be found at its project homepage. Its powerful tool to logging application output to different targets. Log4net provide different types of provider to save logging into plain text, database etc.  Log4net enable logging at runtime without modifying the application binary. It provide high speed of logging.
1.0 Logging to File using Log4Net:
Dll Required : Log4net2.0.8 (apache)  http://logging.apache.org/log4net/index.html
Using Nuget Package Manager Add Required Dll.
PM> Install-Package log4net
Add Log4Net.config to root of application
Sample code for Log4Net.config file is given below
         
Firstly we need to implement the ILogger interface with Log4Net library. 

public class Log4NetLogger : ILogger



This logger needs to be provided to the logger factory extension using I Logger Provider implementation. 
The configuration parsing is implemented inside this class.
public class Log4NetProvider : ILoggerProvider

Finally we need ILoggerFactory extension methods, which helps to add Log4Net to the logger factory
public static class Log4netExtensions

And you can use this inside Configure() method.
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddLog4Net();
}

Using Logger Instances we can Log from any section of the Program

2.0 Logging to SQL database:
This demonstrates how to implement logging to sql database 

Create a database with sql scripts below:
CREATE DATABASE CustomLoggerDB  
GO  
USE CustomLoggerDB 
GO  
CREATE TABLE EventLog(  
    [ID] int identity primary key,  
    [EventID] int,  
    [LogLevel] nvarchar(50), 
    [Message] nvarchar(4000), 
    [CreatedTime] datetime2 
) 

Add the connection string in the appsettings.json first.

"ConnectionStrings": { "LoggerDatabase": "Server=.;Database=CustomLoggerDB;Trusted_Connection=True;"}
Add logger provider in the configure method:

loggerFactory.AddContext(LogLevel.Information);


Add DBContext in the services:

CustomLoggerDBContext.ConnectionString = Configuration.GetConnectionString("LoggerDatabase"); 

Using Code Provided in LoggerProvider:

public class DBLoggerProvider : ILoggerProvider 

DBLogger:

public class DBLogger : ILogger 

Using the Instance of ILogger in Some Controller to Log into DataBase:
private CustomLoggerDBContext _context; 

 public SomeController( ILogger<StudentController> logger) 
{ 
    _context = context; 
    
} 
 
public method() 
{ 
   
    _logger.LogInformation((int)LoggingEvents.GENERATE_ITEMS, "Hello World."); 
    
} 

