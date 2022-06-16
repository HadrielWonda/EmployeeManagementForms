using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Environment;

namespace Baumax.TestClient
{
    public class FullTest
    {
        private List<ITest> _Tests = new List<ITest>();
        private Random _Rnd = new Random();
        
        public FullTest()
        {
            _Tests.Add(new SaveTest<Country>(ClientEnvironment.CountryService));
            // client cannot delete the countries according to the specification
            //_Tests.Add(new CreateDeleteTest<Country>(ClientEnvironment.CountryService));
            
            _Tests.Add(new SaveTest<Region>(ClientEnvironment.RegionService));
            _Tests.Add(new CreateDeleteTest<Region>(ClientEnvironment.RegionService));
            
            _Tests.Add(new SaveTest<Store>(ClientEnvironment.StoreService));
            _Tests.Add(new CreateDeleteTest<Store>(ClientEnvironment.StoreService));
            
            _Tests.Add(new SaveTest<World>(ClientEnvironment.WorldService));
            _Tests.Add(new CreateDeleteTest<World>(ClientEnvironment.WorldService));
            
            _Tests.Add(new SaveTest<HWGR>(ClientEnvironment.HWGRService));
            _Tests.Add(new CreateDeleteTest<HWGR>(ClientEnvironment.HWGRService));
            
            _Tests.Add(new SaveTest<WGR>(ClientEnvironment.WGRService));
            _Tests.Add(new CreateDeleteTest<WGR>(ClientEnvironment.WGRService));

            _Tests.Add(new SaveTest<Absence>(ClientEnvironment.AbsenceService));
            _Tests.Add(new CreateDeleteTest<Absence>(ClientEnvironment.AbsenceService));

            _Tests.Add(new SaveTest<User>(ClientEnvironment.UserService));
            _Tests.Add(new CreateDeleteTest<User>(ClientEnvironment.UserService));

            _Tests.Add(new SaveTest<Colouring>(ClientEnvironment.ColouringService));
            _Tests.Add(new CreateDeleteTest<Colouring>(ClientEnvironment.ColouringService));

            _Tests.Add(new SaveTest<Colouring>(ClientEnvironment.ColouringService));
            _Tests.Add(new CreateDeleteTest<Colouring>(ClientEnvironment.ColouringService));

            _Tests.Add(new SaveTest<Feast>(ClientEnvironment.FeastService));
            _Tests.Add(new CreateDeleteTest<Feast>(ClientEnvironment.FeastService));

            _Tests.Add(new SaveTest<Employee>(ClientEnvironment.EmployeeService));
            _Tests.Add(new CreateDeleteTest<Employee>(ClientEnvironment.EmployeeService));

            _Tests.Add(new SaveTest<EmployeeContract>(ClientEnvironment.EmployeeContractService));
            _Tests.Add(new CreateDeleteTest<EmployeeContract>(ClientEnvironment.EmployeeContractService));

            _Tests.Add(new SaveTest<EmployeeContract>(ClientEnvironment.EmployeeContractService));
            _Tests.Add(new CreateDeleteTest<EmployeeContract>(ClientEnvironment.EmployeeContractService));

            _Tests.Add(new SaveTest<AbsenceTimePlanning>(ClientEnvironment.AbsenceTimePlanningService));
            _Tests.Add(new CreateDeleteTest<AbsenceTimePlanning>(ClientEnvironment.AbsenceTimePlanningService));

            _Tests.Add(new SaveTest<AbsenceTimeRecording>(ClientEnvironment.AbsenceTimeRecordingService));
            _Tests.Add(new CreateDeleteTest<AbsenceTimeRecording>(ClientEnvironment.AbsenceTimeRecordingService));

            _Tests.Add(new SaveTest<WorkingTimePlanning>(ClientEnvironment.WorkingTimePlanningService));
            _Tests.Add(new CreateDeleteTest<WorkingTimePlanning>(ClientEnvironment.WorkingTimePlanningService));

            _Tests.Add(new SaveTest<WorkingTimeRecording>(ClientEnvironment.WorkingTimeRecordingService));
            _Tests.Add(new CreateDeleteTest<WorkingTimeRecording>(ClientEnvironment.WorkingTimeRecordingService));
            
        }
        
        public void Run()
        {
            int ind = _Rnd.Next(0, _Tests.Count - 1);
            _Tests[ind].Run();
        }
    }
}
