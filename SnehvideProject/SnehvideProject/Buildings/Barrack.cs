using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnehvideProject
{
    class Barrack : Building, IPlayerUnit
    {

		static readonly object lockObject = new object();

		public void TrainDwarf()
		{
			lock(lockObject)
			{
				Thread.Sleep(3000);
				
			}
		}

    }
}
