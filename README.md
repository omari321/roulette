# Alta Software Ufc Notification Installation Guide

1. ## Make sure you have IIS 10 installed
2. ## Make Sure you have ASP.NET Core Module/Hosting Bundle Installed

1. ## Download the solution
1. ## Extract the B7.UfcNotification.API  in IIS folders
    
    1. Extract B7.UfcNotification.API to ```C:\Inetpub\B7.UfcNotification\B7.UfcNotification.Api``` folder

    1. Go to folder find ```appsettings.json``` file, open it and:
        1.  Fill ```Database:ConnectionString``` section with "CARDS2011" database connection string. Database user ***must*** have read rights on database. 

            '''json
	            "Database": {
	                "ConnectionString": "Server=sql22-n;Database=CARDS2011;Application Name=B7.UfcNotification.Api;TrustServerCertificate=true;Integrated Security=true;"
	            }
            '''

         2.  Create RabbitMq Virtual host named UfcNotification, give the user which will be used in the connection string rights to use it,
		
Fill ```EventPublisherBus:ConnectionString``` section with rabbit mq connection string. 
            ```json
            "EventPublisherBus": {
                "ConnectionString": "HostName=docker2;VirtualHost=UfcNotification;UserName=test;Password=######;ClientProvidedName=B7.UfcNotification.EventPublisher;"
 "TopicName": "B7.UfcNotification.Notifications"
            }
            ```
	3.  Fill ```Settings:CacheDuration``` with the amount you want to cache and check previous requests for duplicates.(the default is 60)
          
	   '''json
	            "Settings": {
	                "CacheDuration": 60
	            }
            '''

   
        4. configure logging to your needs
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

    ]  }```
	
            
        5. Fill ```AppEnvironment:Type``` with the environment you want it to run in 
            ```json
            "AppEnvironment": {
                "Type": "Development"
            }
            ```
	 
  6. ServiceDiscovery ??????????????
1. ## Install B7.UfcNotification.API in IIS

    1. Go to Internet Information Services (IIS) Manager
    1. Create Application Pools
        

        #### B7.UfcNotification.API
        1. Select ```Application Pools```, right click it and select ```Add Application Pool...```
        1. Enter ```B7.UfcNotification.API``` into ```name``` field
        1. Select ```No Managed Code``` in ```.NET CLR version``` field
        1. Select ```Integrated``` in ```Managed pipeline mode``` field
        1. Press ```OK```
        1. Select newly created application pool, right click it and select ```Advanced Settings...```
        1. Set ```General\Start mode``` to ```AlwaysRunning```
        1. Set ```Process Model\Identity``` to ```LocalSystem```
        1. Set ```Process Model\Idle Time-out (minutes)``` to ```0```
        1. Set ```Recycling\Disable Overlapped Recycle``` to ```False```


   ####  B7.UfcNotification.API. **This must be Public**
        1. Select ```Sites```, right click it and select ```Add Website...```
        1. Enter ```B7.UfcNotification.API``` into ```Site name``` field
        1. Select ```B7.UfcNotification.API_AppPool``` in ```Application pool``` field
        1. Enter ```C:\Inetpub\B7.UfcNotification\B7.UfcNotification.Api``` into ```Physical path``` field
        1. Select ```https``` in ```Binding: Type``` field
        1. Enter ```somedomain.ge```  in ```Binding: Host name``` field and select ```Require Server Name Indication``` 
        1. Add Loow Restriction Rule  to only allow specific ip address
        1. Right click the site it and select ```Manage website\Advanced Settings...```

1.  That's it. 
    * Check that everything is working as expected

  
