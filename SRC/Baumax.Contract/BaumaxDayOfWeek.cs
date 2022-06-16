using System;

namespace Baumax.Contract
{
    [Serializable]
    public enum BaumaxDayOfWeek : byte
    { 
       Empty = 0,
       Monday,      // =1
       Tuesday,
       Wednesday,
       Thursday,
       Friday,
       Saturday,
       Sunday       // =7 
    }
    
   
}
