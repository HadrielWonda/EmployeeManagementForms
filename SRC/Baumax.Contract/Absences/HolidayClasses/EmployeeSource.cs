using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.Contract.Interfaces;

namespace Baumax.Contract.HolydayClasses
{
    //[Serializable]
    //public class EmployeeSource : BaseEntity
    //{
    //    protected EmployeeHolidaysInfo _entity;
    //    protected string _fullname;
    //    protected decimal _planned = 0;
    //    protected decimal _recorded = 0;
    //    protected Action _action = Action.None;

    //    public EmployeeSource()  { }
    //    public bool IsAustria = false;
    //    private decimal _availableholiday = 0;
    //    public EmployeeSource(Employee parent, EmployeeHolidaysInfo entity, decimal planned, decimal recorded)
    //    {
    //        _availableholiday = parent.AvailableHolidays;
    //        _fullname = parent.FullName;
    //        _entity = entity;
    //        _planned = planned;
    //        _recorded = recorded;
    //        _ID = parent.ID;
    //    }

    //    public EmployeeSource(Employee parent, IEmployeeHolidaysInfoService service, decimal planned, decimal recorded, int year)
    //    {
    //        EmployeeHolidaysInfo info = service.CreateEntity();
    //        _action = Action.Save;
    //        info.EmployeeID = parent.ID;
    //        _availableholiday = parent.AvailableHolidays;
    //        info.Year = (short)year;

    //        _entity = info;
    //        _fullname = parent.FullName;
    //        _planned = planned;
    //        _recorded = recorded;
    //        _ID = parent.ID;
    //    }


    //    public virtual EmployeeHolidaysInfo Entity
    //    {
    //        get { return _entity; }
    //        set { _entity = value; }
    //    }
    //    public virtual Action Action
    //    {
    //        get { return _action;  }
    //        set { _action = value; }
    //    }

    //    public virtual string FullName
    //    {
    //        get { return _fullname; }
    //        set { _fullname = value; }
    //    }

    //    public virtual decimal OldHolidays
    //    {
    //        get  { return _entity.OldHolidays; }

    //        set
    //        {
    //            if (_entity.OldHolidays != value)
    //            {
    //                ActionSave();
    //                _entity.OldHolidays = value;
    //            }
    //        }
    //    }

    //    public virtual decimal NewHolidays
    //    {
    //        get
    //        {
    //            return _entity.NewHolidays;
    //        }
    //        set
    //        {
    //            if (_entity.NewHolidays != value)
    //            {
    //                ActionSave();
    //                _entity.NewHolidays = value;
    //            }
    //        }
    //    }
    //    public virtual decimal UsedHolidays 
    //    {
    //        get 
    //        {
    //            return _recorded + _planned;
    //        }
    //    }
    //    public virtual decimal AvailableHolidays
    //    {
    //        get
    //        {
    //            if (IsAustria )
    //                return _availableholiday ;
    //            return OldHolidays + NewHolidays;
    //        }
    //    }
    //    public virtual decimal SpareHolidaysExc
    //    {
    //        get
    //        {
    //            return AvailableHolidays - _recorded;
    //        }
    //    }
    //    public virtual decimal SpareHolidaysInc
    //    {
    //        get
    //        {
    //            return AvailableHolidays - _planned - _recorded;
    //        }
    //    }
    //    public virtual decimal Planned
    //    {
    //        get { return _planned; }
    //        set 
    //        {
    //            if (_entity.UsedHolidays != _recorded + value)
    //            {
    //                _planned = value;
    //                RecalcUsed();
    //            }
    //        }
    //    }
    //    public virtual decimal Recorded
    //    {
    //        get { return _recorded; }
    //        set
    //        {
    //            if (_entity.UsedHolidays != _planned + value)
    //            {
    //                _recorded = value;
    //                RecalcUsed();
    //            }
    //        }
    //    }


    //    protected virtual void RecalcUsed()
    //    {
    //        _entity.UsedHolidays = _recorded + _planned;
    //        ActionSave();
    //    }

    //    public virtual void PlusPlanningDays(decimal value)
    //    {
    //        _planned += value;
    //        ActionSave();
    //    }

    //    protected virtual void ActionSave()
    //    {
    //        _action = _entity.ID > 0 ? Action.Update : Action.Save;
    //    }
    //}
}
