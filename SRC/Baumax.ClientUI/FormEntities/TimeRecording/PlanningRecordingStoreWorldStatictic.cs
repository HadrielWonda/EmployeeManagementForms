using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    //public class PlanningRecordingStoreWorldStatictic
    //{

    //    int[] _sums = new int[11];

    //    int[] _plannedsums = null;
    //    int[] _actualsums = null;



    //    public void SetWorldsInfo(StoreWorldWeekState planned, StoreWorldWeekState actual)
    //    {
    //        _plannedsums = planned.GetSums();
    //        _actualsums = actual.GetSums();
    //        Calculate();
    //    }

    //    private void Calculate()
    //    {
    //        for (int i = 0; i < 11; i++)
    //        {
    //            _sums[i] = 0;
    //        }

    //        for (int i = 0; i < 7; i++)
    //        {
    //            _sums[i] = _plannedsums[i] - _actualsums[i];
    //            _sums[7] += _sums[i];
    //            _sums[8] += Math.Abs(_sums[i]);

    //            if (_sums[i] > 0) 
    //                _sums[9] += _sums[i];
    //            else
    //                _sums[10] += _sums[i];
    //        }


    //    }

    //    public int this[DayOfWeek dayofweek]
    //    {
    //        get { return _sums[(int)dayofweek]; }
    //    }

    //    public int TotalSum
    //    {
    //        get { return _sums[7]; }
    //    }

    //    public int AbsTotalSum
    //    {
    //        get { return _sums[8]; }
    //    }

    //    public int AbsTotalSumPos
    //    {
    //        get { return _sums[9]; }
    //    }

    //    public int AbsTotalSumNeg
    //    {
    //        get { return _sums[10]; }
    //    }


    //}
}
