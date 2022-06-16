namespace Baumax.Contract
{
    public enum LoginResult
    {
        Successful,
        WrongLogin,
        WrongPassword,
        UserIsInactive
    }

    public enum EmployeeTimeSaldoType { Recording = 1, Planning = 2 }

    /*
    1	Flat-file for business volume of last three years before the estimation year must exist
    2	Flat-file for targeted business volume for the to be-estimated year must exist
    3	At least one employee must be assigned to each world in the to-be-estimated year
    4	Country properties for imports and calculation of targeted amounts must exist for the to-be-estimated year.
    5	Buffer hours for the worlds must exist.
    6	Closed days (Yearly work-time definition must exist for the to-be-estimated year.)
    7   ActualBV Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
    8   Unavoidable Additional Hours Calculation exists 
    9   Minimum people for the world must exist
    10  Opening times must exist for the to-be-estimated year
    11  Average working days in week
    12  TargetBV Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
    */
    public enum EstimateWorkingHoursCondition: int
    {
        ActualBVExists = 1,
        TargetBVExists = 2,
        EmployeeAssigned = 3,
        CountryPropExists = 4,
        BufferHoursExists = 5,
        ClosedDaysExists = 6,
        EveryWGRAssignedToWorldActualBV = 7,
        AddHoursCalcExists = 8,
        MinPeopleExists = 9,
        OpeningTimesExists = 10,
        AvgWorkingDaysExists = 11,
        EveryWGRAssignedToWorldTargetBV = 12
    }

    /*
    1	Flat-file for cash register receipts (“Bon”) of last three years before the estimation year must exist
    2	At least one employee must be assigned to each cash-desk-world in the to be-estimated year
    3	Country properties for imports and calculation of targeted amounts must exist for the to be-estimated year.
    4	Yearly work-time definition and from open closed times definition must exist for the to be-estimated year.
    5   Opening times must exist for the to-be-estimated year
    6   Minimum and maximum people for the cash desk must exist
    */
    public enum EstimateCashDeskPeopleCondition : int
    {
        ActualBVExists = 1,
        EmployeeAssigned = 2,
        CountryPropExists = 3,
        YearlyWorkTimeExists = 4,
        OpeningTimesExists = 5,
        MinMaxPeopleExists = 6
    }

    public enum EmployeeImportError : int
    {
        NotAssignToStore = 0,
        ContractBeginChange = -1,
        ContractEndChangeAndLessImportDate = -2
    }

    public enum BVcopyFromStoreResult : int
    {
        Success = 0, 
        DataExistsInSelectedTimeRange = -1,
        NoDataCopy = -2
    }
}