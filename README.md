# Support Wheel of Fate - API
A REST API that receives a request and should select two engineers at random to both complete a half day of support each.

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



