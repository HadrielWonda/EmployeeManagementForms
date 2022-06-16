using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.Import
{
	public class Progress
	{
		float _Percent;
		float _CurrPercent;
		int _IntPercent;

		public event ProgressEventHandler OnProgressChanged;

		public void Init(int count)
		{
			_Percent = ((float)count) / 100;
			_CurrPercent = 0;
			_IntPercent= 0;
		}
		
		public Progress(int count)
		{
			Init(count);
		}

		public void Next(int value)
		{
			_CurrPercent = value / _Percent;
			if ((int)_CurrPercent > _IntPercent)
			{
				_IntPercent = Convert.ToInt32(_CurrPercent);
				if (OnProgressChanged != null)
					OnProgressChanged(this, new ProgressEventArgs(_IntPercent, 100));
			}
		}

	}
}
