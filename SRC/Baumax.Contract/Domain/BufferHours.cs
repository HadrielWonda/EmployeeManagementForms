using System;
using System.Collections;
using Baumax.Contract;

namespace Baumax.Domain
{

    #region BufferHours

    /// <summary>
    /// BufferHour object for NHibernate mapped table 'BufferHours'.
    /// </summary>
    [Serializable]
    public class BufferHours : BaseEntity
    {
        #region Member Variables

        [NonSerialized]
        string _worldName;

        protected short _year;
        protected double _value;
        protected long _storeWorld;
        protected double _valueWeek;

        #endregion

        #region Constructors

        public BufferHours()
        {
        }

        public BufferHours(short year, double value, double valueWeek, long storeWorldID)
        {
            this._year = year;
            this._value = value;
            this._valueWeek = valueWeek;
            this._storeWorld = storeWorldID;
        }

        #endregion

        #region Public Properties

        public virtual string WorldName
        {
            get { return _worldName; }
            set { _worldName = value; }
        }

        public virtual short Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public virtual double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual double ValueWeek
        {
            get { return _valueWeek; }
            set { _valueWeek = value; }
        }

        public virtual long StoreWorldID
        {
            get { return _storeWorld; }
            set { _storeWorld = value; }
        }
        #endregion


        public static int GetWeekStepValue(BufferHours entity)
        {
            return (int)Math.Round(entity.Value * 60 / DateTimeHelper.GetCountWeekInYear(entity.Year));
        }
    }

    #endregion
}