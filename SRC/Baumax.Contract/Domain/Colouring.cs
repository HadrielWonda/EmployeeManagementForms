using System;
using System.Collections;

namespace Baumax.Domain
{

    #region Colouring

    /// <summary>
    /// Colouring object for NHibernate mapped table 'Colouring'.
    /// </summary>
    [Serializable]
    public class Colouring : BaseEntity
    {
        #region Member Variables

        protected long? _countryID;
        protected byte _colourType;
        protected int _lCColour;
        protected int _l;
        protected int _lColour;
        protected int _y;
        protected int _nColour;
        protected int _x;
        protected int _hColour;
        protected int _h;
        protected int _hCColour;

        #endregion

        #region Constructors

        public Colouring()
        {
        }

        public Colouring(long? countryID, byte colourType, int lCColour, int l, int lColour, int y, int nColour, int x, int hColour,
                         int h, int hCColour)
        {
            this._countryID = countryID;
            this._colourType = colourType;
            this._lCColour = lCColour;
            this._l = l;
            this._lColour = lColour;
            this._y = y;
            this._nColour = nColour;
            this._x = x;
            this._hColour = hColour;
            this._h = h;
            this._hCColour = hCColour;
        }

        #endregion

        #region Public Properties

        public virtual long? CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }

        public virtual byte ColourType
        {
            get { return _colourType; }
            set { _colourType = value; }
        }

        public virtual int LCColour
        {
            get { return _lCColour; }
            set { _lCColour = value; }
        }

        public virtual int L
        {
            get { return _l; }
            set { _l = value; }
        }

        public virtual int LColour
        {
            get { return _lColour; }
            set { _lColour = value; }
        }

        public virtual int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public virtual int NColour
        {
            get { return _nColour; }
            set { _nColour = value; }
        }

        public virtual int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public virtual int HColour
        {
            get { return _hColour; }
            set { _hColour = value; }
        }

        public virtual int H
        {
            get { return _h; }
            set { _h = value; }
        }

        public virtual int HCColour
        {
            get { return _hCColour; }
            set { _hCColour = value; }
        }
        #endregion


        #region Properties view
        [NonSerialized ]
        private string _colorname;

        public virtual string ColorName
        {
            get { return _colorname; }
            set { _colorname = value; }
        }
        #endregion

        public virtual int GetColor(int value)
        {
            int minute = 60;
            if (_colourType == 7 || _colourType == 8) // value is percent, so no need *60, compare directly  
                minute = 1;
            if (value < L * minute) return LCColour;
            if (L * minute <= value && value < Y * minute) return LColour;
            if (Y * minute <= value && value <= X * minute) return NColour;
            if (X * minute < value && value <= H * minute) return HColour;
            //if (L > H) 
            return HCColour;
        }
        public virtual int GetColor(double value)
        {
            int minute = 60;
            if (_colourType == 7 || _colourType == 8) // value is percent, so no need *60, compare directly  
                minute = 1;
            if (value < L * minute) return LCColour;
            if (L * minute <= value && value < Y * minute) return LColour;
            if (Y * minute <= value && value <= X * minute) return NColour;
            if (X * minute < value && value <= H * minute) return HColour;
            //if (L > H) 
            return HCColour;
        }
    }

    #endregion
}