using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Contract
{
    static public class SharedConsts
    {
        public const long NeutralLangId = 1;
        public const int CalculateAll = -1;
        public const decimal NoData = -1.0m;
    
            /*
             * SET @GlobalAdminRole = 50
SET @ControllingRole = 51
SET @CountryAdminRole = 52
SET @RegionAdminRole = 53
SET @StoreAdminRole  =54 
             */

        //public const int DayMinutes = 24 * 60; 
    }

    public enum UserRoleId:long
    {
        GlobalAdmin = 50,
        Controlling = 51,
        CountryAdmin = 52,
        RegionAdmin = 53,
        StoreAdmin  = 54 
    }
}
