OpenIdSample

This sample project shows an attempt to create a site based on the standard .net angular template, together with an STS site which issues login tokens for use on the main site.

1) You need to grab a spare SQL Server instance (in my case I used a local one called SQL2016DEV) and run the InitData.sql file. The relevant databases will be referred to in the appsettings.json files for each project. The 2 projects we should run both have their own databases

2) Open the OpenIdSample.sln. You can ignore the AngularStsWebApp project (remove it if you prefer) - I left it in just for reference to my attempts to bring the MVC logic over to angular.

3) Set the startup projects to multiple, with AspNetMvcClient and SecuringAngularApps.STS being run from the program (rather than IISExpress)

4) Click login and observe