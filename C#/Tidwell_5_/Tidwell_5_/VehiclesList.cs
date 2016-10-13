using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tidwell_5_
{
    public class VehiclesList
    {
        List<Vehicle> dataList;

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public VehiclesList()
        {
            dataList = new List<Vehicle>();
            count = 0;

        }

        public void add(Vehicle e)
        {
            dataList.Add(e);
            count++;
        }

        public void remove(Vehicle e)
        {
            dataList.Remove(e);
            count--;
        }

        public Vehicle get(int i)
        {
            return dataList[i];
        }

        public void sortAsc()
        {
            dataList.Sort( (a, b) => a.PlateNumber.CompareTo(b.PlateNumber) );
        }

        public void sortDesc()
        {
            this.sortAsc();
            dataList.Reverse();
        }
    }
}
