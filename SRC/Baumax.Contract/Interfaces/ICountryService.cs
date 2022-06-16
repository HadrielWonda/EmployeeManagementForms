using System.Collections;
using System.Collections.Generic;
using Baumax.Contract.ZLib;
using Baumax.Domain;

namespace Baumax.Contract.Interfaces
{
    public interface ICountryService : IBaseService<Country>
    {
        IFeastService FeastService { get; }
        IAbsenceService AbsenceService { get; }
        IAvgAmountService AvgAmountService { get; }
        IWorkingModelService WorkingModelService { get; }
        IColouringService ColouringService { get; }
        IYearlyWorkingDayService YearlyWorkingDayService { get; }
        IAvgWorkingDaysInWeekService AvgWorkingDaysInWeekService { get; }
        ICountryAdditionalHourService CountryAdditionalHourService { get; }
        long AustriaCountryID { get; }

        bool IsCountryExist(long c_id, string c_name);
        IList<Country> GetUserCountries(long userId);
        long[] GetCountryNoWorkingFeastDaysIDList();
        long[] GetInUseIDList(InUseEntity inUseEntity, long countryID);
        void TestImportServerSide();
    }
}