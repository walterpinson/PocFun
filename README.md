---
published: false
---

PocFun
======

## About
Proving out a few different concepts...

## Configuration Instructions
There are a number of steps that must be taken in order to completely configure a local development environment. The server API application will run on the local IIS server using different host headers that must be configured.

### DNS Configuration
1. Navigate to `%WINDOWS%/system32/drivers/etc`
2. Using the Administrator context, launch an editor like vi or notepad
3. Open the hosts file for editing
4. Add the line:  127.0.0.1 api.pocfun.wp.dev
5. Add the line:  127.0.0.1 security.pocfun.wp.dev
6. Save and close the file

### IIS Configuration
1. Open the Computer Management Console
2. Under Services and Applications, select Internet Information Services
3. Under Connections, expand the tree with your local machine name
4. Right click on Sites and select Add Web Site...
5. Under Site name:, type api.pocfun.wp.dev
6. Under Host name:, type api.pocfun.wp.dev
7. Under Physical path:, navigate to `<REPOSITORY-ROOT>/src/server/Infrastructure.PocFunApi`
8. Select OK
9. Repeat steps 4 through 8 using

	9.1 Site/Host Name: security.pocfun.wp.dev as the site/host name

	9.2 Physical paht: `<REPOSITORY-ROOT>/src/security/Infrastructure.SecurityApi`
10. Under the server name, select Application Pools
11. In the Application Pools window, select api.pocfun.wp.dev.
12. Under Edit Application Pool, select Basic Settings...
13. Under .NET Framework Version, select .NET Framework v4.0.30319
14. Select OK
15. Repeat steps 11 through 14 for security.pocfun.wp.dev
16. Recycle the application pools
17. Restart the web sites

### File System Security
1. Open the Windows File Explorer
2. Navigate to `<REPOSITORY-ROOT>/src/server/`
3. Right click the `Infrastructure.PocFunApi` folder.
4. Select Properties and then select the Security tab.
5. Add the local user IIS_IUSR (`<MACHINE-NAME>\IIS_IUSRS`)
6. Give this user the following permissions

	6.1. Read & execute
    
	6.2. List folder contents
    
	6.3. Read
7. Click OK and make sure that the permissions cascade to all child objects
8. Navigate to `<REPOSITORY-ROOT>/src/security/`
9. Right click the `Infrastructure.SecurityApi` folder.
10. Repeat steps 4 through 7.

### MongoDb
1. Navigate to the following web site: http://www.mongodb.org/
2. Download MongoDB 2.4
3. Follow the installation instructions.

	3.1. Windows:  http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/

	3.2. NOTE:  It is not necessary to install as a Windows Service although you are free to do so if you wish.

### SQL Server
1. Instructions assume that SQL Server 2008 or higher is already installed.