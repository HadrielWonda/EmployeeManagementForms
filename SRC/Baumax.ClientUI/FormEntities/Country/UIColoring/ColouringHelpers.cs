using System;
using System.Collections.Generic;
using System.Drawing;
using Baumax.Contract;
using Baumax.Environment;
using Baumax.Templates;
using Baumax.Localization;
namespace Baumax.ClientUI.FormEntities.Country
{
    /*
     * public enum CountryColorValueType:byte
    {
        SumOfAdditionalCharges = 1,
        SumOfStillAvailableWorkingHours = 2,
        SumOfCurrentEmployeeBalanceHours = 3,
        SumOfAdditionalChargesOverAllEmployee = 4,
        SumOfStillAvailableWorkingHoursOverAllEmployee = 5,
        SumOfCurrentEmployeeBalanceHoursOverAllEmployee = 6,
        DifferenceInPercentBetweenActualPalnnedHoursAndEstimatedHours = 7,
        BenchmarkDifference = 8,
        AbsInPercentForEstimatedWorkingAmount = 9,
        TotalInPercentForEstimatedWorkingAmount = 10,
        ActualAbsInPercentForEstimatedWorkingAmount = 11,
        ActualTotalInPercentForEstimatedWorkingAmount = 12,
        ActualAbsInPercentForPlannedWorkingAmount = 13,
        ActualTotalInPercentForPlannedWorkingAmount = 14
    }
     */
    public class CountryColourList:BindingTemplate <Domain.Colouring >
    {
        private Domain.Country _country = null;

        public CountryColourList(Domain.Country aCountry)
        {
            if (aCountry == null)
                throw new NullReferenceException();
            _country = aCountry;
        }


        public Domain.Country Country
        {
            get { return _country; }
        }

        Domain.Colouring GetColorByType(byte type)
        {
            foreach (Domain.Colouring c in this)
            {
                if (c.ColourType == type) return c;
            }
            return null;
        }

        public static  string GetColorName(Domain.CountryColorValueType type)
        {
            switch (type)
            {
                case Domain.CountryColorValueType.SumOfAdditionalCharges :
                    return Localizer.GetLocalized(type.ToString().ToLower());

                case Domain.CountryColorValueType.SumOfAdditionalChargesOverAllEmployee :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.SumOfCurrentEmployeeBalanceHours :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.SumOfCurrentEmployeeBalanceHoursOverAllEmployee :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.SumOfStillAvailableWorkingHours :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.SumOfStillAvailableWorkingHoursOverAllEmployee :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.TotalInPercentForEstimatedWorkingAmount :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.BenchmarkDifference :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.DifferenceInPercentBetweenActualPlannedHoursAndEstimatedHours :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.ActualTotalInPercentForPlannedWorkingAmount :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.ActualTotalInPercentForEstimatedWorkingAmount :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.ActualAbsInPercentForPlannedWorkingAmount :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.ActualAbsInPercentForEstimatedWorkingAmount :
                    return Localizer.GetLocalized(type.ToString().ToLower());
                case Domain.CountryColorValueType.AbsInPercentForEstimatedWorkingAmount:
                    return Localizer.GetLocalized(type.ToString().ToLower());

            }
            return String.Empty;
        }
        void InitColor(Domain.Colouring c)
        {
            c.L = 0;
            c.Y = 10;
            c.X = 20;
            c.H = 30;

            c.LCColour = Color.Black.ToArgb ();
            c.LColour = c.NColour = c.HColour = c.HCColour = Color.Black.ToArgb();

        }

        public void CheckAndCreateColorList()
        {
            AccessType access = ClientEnvironment.AuthorizationService.GetAccess(ClientEnvironment.ColouringService);

            if ((access & AccessType.Write) != 0)
            {
                Domain.Colouring c = null;
                bool bModified = false;
                for (byte i = 1; i <= 14; i++)
                {
                    c = GetColorByType(i);
                    if (c == null)
                    {
                        c = new Domain.Colouring();
                        c.CountryID = Country.ID;
                        c.ColourType = i;
                        InitColor(c);
                        this.Add(c);
                        bModified = true;
                    }
                    else c.ColorName = GetColorName((Domain.CountryColorValueType) c.ColourType);
                }
                if (bModified)
                {
                    Update();
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            Clear();
            List<Domain.Colouring> lst = ClientEnvironment.ColouringService.GetCountryColouring(Country.ID);
            CopyList(lst);
            CheckAndCreateColorList();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            List<Domain.Colouring> lst = new List<Domain.Colouring>(this);
            ClientEnvironment.ColouringService.SaveOrUpdateList(lst);
        }

    }

    //public class CountryColorView
    //{
    //    private bool _modified = false;
    //    private Domain.Colouring _countryColor = null;

    //    public Domain.Colouring CountryColor
    //    {
    //        get { return _countryColor; }
    //    }

    //    public bool Modified
    //    {
    //        get { return _modified; }
    //        set { _modified = value; }
    //    }

    //    public string ColorTypeName
    //    {
    //        get { return GetValueName(); }
    //    }

    //    private string GetValueName()
    //    {

    //        return _countryColor.ColourType.ToString();

    //        #region comment
    //        /*switch (_ColorType) 
    //        {
    //            case CountryColorValueType.SumOfAdditionalCharges :
    //                return ;
    //                break;
    //            case CountryColorValueType.SumOfAdditionalChargesOverAllEmployee :

    //                break;
    //            case CountryColorValueType.SumOfCurrentEmployeeBalanceHours:

    //                break;
    //            case CountryColorValueType.SumOfCurrentEmployeeBalanceHoursOverAllEmployee:

    //                break;
    //            case CountryColorValueType.SumOfStillAvailableWorkingHours:

    //                break;
    //            case CountryColorValueType.SumOfStillAvailableWorkingHoursOverAllEmployee:

    //                break;
    //            case CountryColorValueType.TotalInPercentForEstimatedWorkingAmount:

    //                break;
    //            case CountryColorValueType.BenchmarkDifference:

    //                break;
    //            case CountryColorValueType.DifferenceInPercentBetweenActualPalnnedHoursAndEstimatedHours:

    //                break;
    //            case CountryColorValueType.ActualTotalInPercentForPlannedWorkingAmount:

    //                break;
    //            case CountryColorValueType.ActualTotalInPercentForEstimatedWorkingAmount:

    //                break;
    //            case CountryColorValueType.ActualAbsInPercentForPlannedWorkingAmount:

    //                break;
    //            case CountryColorValueType.ActualAbsInPercentForEstimatedWorkingAmount:

    //                break;
    //            case CountryColorValueType.AbsInPercentForEstimatedWorkingAmount:

    //                break;
                    
    //        }*/
    //        #endregion
    //    }

    //    #region CountryColor Properties 

    //    public Color CriticalHigherColor
    //    {
    //        get { return Color.FromArgb (_countryColor.HCColour); }
    //        set 
    //        { 
    //            Color oldColor = Color.FromArgb (_countryColor.HCColour);
    //            if (oldColor != value)
    //            {
    //                _countryColor.HCColour = value.ToArgb (); 
    //                Modified = true;
    //            }
    //        }
    //    }

    //    public Color HigherColor
    //    {
    //       get { return Color.FromArgb (_countryColor.HColour ); }
    //        set 
    //        { 
    //            Color oldColor = Color.FromArgb (_countryColor.HColour);
    //            if (oldColor != value)
    //            {
    //                _countryColor.HColour = value.ToArgb (); 
    //                Modified = true;
    //            }
    //        }
    //    }

    //    public Color NormalColor
    //    {
    //        get { return Color.FromArgb (_countryColor.NColour); }
    //        set 
    //        { 
    //            Color oldColor = Color.FromArgb (_countryColor.NColour);
    //            if (oldColor != value)
    //            {
    //                _countryColor.NColour = value.ToArgb (); 
    //                Modified = true;
    //            }
    //        }
    //    }

    //    public Color LowerColor
    //    {
    //        get { return Color.FromArgb (_countryColor.LColour); }
    //        set 
    //        { 
    //            Color oldColor = Color.FromArgb (_countryColor.LColour);
    //            if (oldColor != value)
    //            {
    //                _countryColor.LColour = value.ToArgb (); 
    //                Modified = true;
    //            }
    //        }
    //    }

    //    public Color CriticalLowerColor
    //    {
    //        get { return Color.FromArgb (_countryColor.LCColour); }
    //        set 
    //        { 
    //            Color oldColor = Color.FromArgb (_countryColor.LCColour);
    //            if (oldColor != value)
    //            {
    //                _countryColor.LCColour = value.ToArgb (); 
    //                Modified = true;
    //            }
    //        }
    //    }


    //    public int ValueH
    //    {
    //        get { return _countryColor.H ; }
    //        set 
    //        { 
    //            if (_countryColor.H != value)
    //            {
    //                _countryColor.H = value; 
    //                Modified = true; 
    //            }
    //        }
    //    }

    //    public int ValueX
    //    {
    //        get { return _countryColor.X ; }
    //        set 
    //        { 
    //            if (_countryColor.X != value)
    //            {
    //                _countryColor.X = value; 
    //                Modified = true; 
    //            }
    //        }
    //    }

    //    public int ValueY
    //    {
    //        get { return _countryColor.Y ; }
    //        set 
    //        { 
    //            if (_countryColor.Y != value)
    //            {
    //                _countryColor.Y = value; 
    //                Modified = true; 
    //            }
    //        }
    //    }

    //    public int ValueL
    //    {
    //        get { return _countryColor.L ; }
    //        set 
    //        { 
    //            if (_countryColor.L != value)
    //            {
    //                _countryColor.L = value; 
    //                Modified = true; 
    //            }
    //        }
    //    }
    //    #endregion

    //    #region Ctor

    //    public CountryColorView(Domain.Colouring aColor)
    //    {
    //        System.Diagnostics.Debug.Assert(aColor != null);
    //        _countryColor = aColor;
    //    }

    //    #endregion
    //}


    //public class ColorListView:List<CountryColorView>
    //{

    //    public void AssignColorList(List<Domain.Colouring> lst)
    //    {
    //        this.Clear();

    //        foreach (Domain.Colouring c in lst)
    //            this.Add(new CountryColorView(c));
    //    }

    //    #region Service methods

    //    CountryColorView GetColorByColorType(CountryColorValueType value)
    //    {
    //        foreach (CountryColorView ccv in this)
    //            if (ccv.CountryColor.ColourType == (byte)value) return ccv;
    //    }

    //    void BuildDefaultColors()
    //    {
    //        for (byte i = 1; i <= 14; i++)
    //        {
                
    //        }

    //    }
    //    #endregion
    //}

}
