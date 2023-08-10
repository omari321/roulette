# Alta Software Ufc Notification Installation Guide

## Pre-requisites
1. **Make sure you have IIS 10 installed**
2. **Make Sure you have ASP.NET Core Module/Hosting Bundle Installed**

## Installation Steps
1. **Download the solution**
2. **Extract the B7.UfcNotification.API in IIS folders**
   - Extract B7.UfcNotification.API to `C:\Inetpub\B7.UfcNotification\B7.UfcNotification.Api` folder
   - Go to the folder, find `appsettings.json` file, and open it to:
      1. Fill `Database:ConnectionString` section with "CARDS2011" database connection string. Database user ***must*** have read rights on the database.

         ```json
         "Database": {
             "ConnectionString": "Server=sql22-n;Database=CARDS2011;Application Name=B7.UfcNotification.Api;TrustServerCertificate=true;Integrated Security=true;"
         }
         ```
      2. Create RabbitMq Virtual host named UfcNotification, give the user which will be used in the connection string rights to use it, and fill `EventPublisherBus:ConnectionString` section with rabbit mq connection string.
         
         ```json
         "EventPublisherBus": {
             "ConnectionString": "HostName=docker2;VirtualHost=UfcNotification;UserName=test;Password=######;ClientProvidedName=B7.UfcNotification.EventPublisher;",
             "TopicName": "B7.UfcNotification.Notifications"
         }
         ```
      3. Fill `Settings:CacheDuration` with the amount you want to cache and check previous requests for duplicates. (the default is 60)
      4. Configure logging to your needs.
         
         ```json
         "Serilog": {
             "UseDefaultConfiguration": true,
             "MinimumLevel": {
                 "Default": "Verbose",
                 "Override": {
                     "Microsoft": "Information",
                     "System": "Information"
                 }
             },
             "WriteTo": [
                 {
                     "Name": "File",
                     "Args": {
                         "path": "logs/.txt",
                         "rollingInterval": "Day",
                         "retainedFileCountLimit": 30
                     }
                 }
             ]
         }
         ```
      5. Fill `AppEnvironment:Type` with the environment you want it to run in.
         
         ```json
         "AppEnvironment": {
             "Type": "Development"
         }
         ```
      6. ServiceDiscovery (Additional information required here)
3. **Install B7.UfcNotification.API in IIS**
   - Go to Internet Information Services (IIS) Manager
   - Create Application Pools
      #### B7.UfcNotification.API
      - (Follow instructions for setting up B7.UfcNotification.API)
      #### B7.UfcNotification.API. **This must be Public**
      - (Follow instructions for setting up the public API)
4. **That's it.**
   - Check that everything is working as expected.
