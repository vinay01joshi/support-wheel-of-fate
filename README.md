# Support Wheel of Fate - API
A REST API that receives a request and should select two engineers at random to both complete a half day of support each.

## Approtch


## Descision Document
#### Openshift 
- Open shift is docker containersed based hosting environment in which you can deploy any type of code based on container you want .
- Free Open and Startr version which include 1GB space and 2 CPU's
- Free MySqL Database instance.

### Github pages
- Github pages are very easy to deploy and make you repository url you fornt end code deployment end point.

### .Net Core
- Any Operating system and Light weight framework which support C# with ever efficient depency injection support.

- Any databaese support with Entity framework core such as i am using mySql

### Angular 4
- Easy Signle page application development with agnular . Componenet driven framework that make you code more readable and structured. and two way binding is an advantage of angular 4.

### Bootstrap 4
- Early release of bootstrap new version is very easy to integrate with any frontend framework which provides more mooth designs.

### App Veyor
- Easty to integrate contineous build and deployment with .net core .


##   Deployed Endpoints
-   ( Api ) - http://support-wheel-of-fate-swof.7e14.starter-us-west-2.openshiftapps.com/api/Engineer

- ( Front End ) - https://vinay01joshi.github.io/support-wheel-of-fate/
##   Project Structure
- SWOF 
    
    Backend code in asp.net core web api and Entity framework code first with My SQL database.
- SWOF.UI
    
    Front end code with Angular 5
- SWOF.Test

    C# .net core ms test implementation

##   Controllers
### ShiftController
- Create and list engineer turns

### EngineerController
- Manupulates engineer in database.

### ValuesController
- dummy Controller
## Settings
```json
   "Schedule": {
    "ShiftsPerPeriod": 20,
    "ShiftDays": 10,
    "ShiftsPerEngineerPerPeriod": 2
  }
```
## Packages
- Microsoft.EntityFrameworkCore
- MySql.Data
- AutoMapper
## Continuous integrations & Continuous Delivery

- AppVeyor Build Status

    [![Build status](https://ci.appveyor.com/api/projects/status/p2nguxv1kg5r596e/branch/master?svg=true)](https://ci.appveyor.com/project/vinay01joshi18498/support-wheel-of-fate/branch/master)

- Deployment
    Openshift containerised build and deployment with asp.net core 2.0 sdk in https://www.openshift.com/



