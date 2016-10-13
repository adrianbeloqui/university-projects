using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Administration
    {
        private ArrayList clients;
        private ArrayList employees;
        private ArrayList vehicles;
        private ArrayList drivingClasses;
        private ArrayList historyOfDrivingClasses;
        private ArrayList historyVehicles;

        #region Properties

        public ArrayList Clients
        {
            get { return clients; }
            set { clients = value; }
        }
        public ArrayList Employees
        {
            get { return employees; }
            set { employees = value; }
        }
        
        public ArrayList Vehicles
        {
            get { return vehicles; }
            set { vehicles = value; }
        }

        public ArrayList DrivingClasses
        {
            get { return drivingClasses; }
            set { drivingClasses = value; }
        }

        public ArrayList HistoryOfDrivingClasses
        {
            get { return historyOfDrivingClasses; }
            set { historyOfDrivingClasses = value; }
        }

        public ArrayList HistoryVehicles
        {
            get { return historyVehicles; }
            set { historyVehicles = value; }
        }
#endregion

        #region Methods
        public void AddClient(People.Person cliente)
        {
            Clients.Add(cliente); 
        }

        public void AddEmployee(People.Employee empleado)
        {
            Employees.Add(empleado);
        }

        public void AddVehicle(Vehicles.Vehicle vehiculo)
        {
            Vehicles.Add(vehiculo);
        }

        public void AddClass(DrivingClass clase)
        {
            DrivingClasses.Add(clase);
        }

        public void AddClassToHistory(DrivingClass clase)
        {
            HistoryOfDrivingClasses.Add(clase);
        }

        public void AddVehicleToHistory(Vehicles.Vehicle vehi)
        {
            HistoryVehicles.Add(vehi);
        }
#endregion

        public Administration()
        {
            Clients = new ArrayList();
            Employees = new ArrayList();
            Vehicles = new ArrayList();
            DrivingClasses = new ArrayList();
            HistoryOfDrivingClasses = new ArrayList();
            HistoryVehicles = new ArrayList();
        }
    }
}
