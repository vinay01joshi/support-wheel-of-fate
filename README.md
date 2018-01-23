# Support Wheel of Fate - API
A REST API that receives a request and should select two engineers at random to both complete a half day of support each.

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

## Continuous integrations & Continuous Delivery

- AppVeyor Build Status

    [![Build status](https://ci.appveyor.com/api/projects/status/p2nguxv1kg5r596e/branch/master?svg=true)](https://ci.appveyor.com/project/vinay01joshi18498/support-wheel-of-fate/branch/master)

- Deployment
    Openshift containerised deployement 

