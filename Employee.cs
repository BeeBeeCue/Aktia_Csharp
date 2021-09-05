using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace Task01
{

    public class Employee
    {

        public static void DoWork ()
        {
            string _path = "employees.json";

            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var customerFromJson = JsonConvert.DeserializeObject<Root>(jsonFromFile);



                foreach (var employeeList in customerFromJson.EmployeeList)
                {

                    Console.WriteLine("I did work in role: " + employeeList.Role + ", ");
                    Console.WriteLine("My information: ");
                    Console.WriteLine(employeeList.Name);
                    Console.WriteLine(employeeList.SSN);
                    if (employeeList.Tool != null)
                    {
                        Console.WriteLine(employeeList.Tool);
                    }
                    if (employeeList.GeneralAccessCard != null)
                    {
                        Console.WriteLine("General access card: " + employeeList.GeneralAccessCard);
                    }
                    if (employeeList.HasForemanCalendarView != null)
                    {
                        Console.WriteLine("Has Forman Calendar View: " + employeeList.HasForemanCalendarView);
                    }
                    if (employeeList.YearlyBonus != null)
                    {
                        Console.WriteLine("Yearly Bonus: " + employeeList.YearlyBonus);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }

    }

    public class Showel : Employee
    {
        string Tool { get; set; }
    }

    public class Bosses : Employee
    {
        float YearlyBonus { get; set; }
    }

    public class Secretaries : Employee
    {
        bool CanSeeBossCalender { get; set; }

        bool HasGeneralAccessCard { get; set; }
    }

    public class EmployeeList
    {
        public string Name { get; set; }
        public string SSN { get; set; }
        public string Role { get; set; }
        public string Tool { get; set; }
        public bool? GeneralAccessCard { get; set; }
        public bool? HasForemanCalendarView { get; set; }
        public int? YearlyBonus { get; set; }

    }

    public class Root
    {
        public List<EmployeeList> EmployeeList { get; set; }
    }
}
