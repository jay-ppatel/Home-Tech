using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTechServices
{
    public class Technician
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        internal static Technician ParseFromFile(string line)
        {//separates the string into a different indice every time a ',' is reached
            var columns = line.Split(',');//instantiation of the Car object
            return new Technician
            {
                Name = columns[0],
                PhoneNumber = columns[1],
                Email = columns[2],
                StartTime = columns[3],
                EndTime = columns[4]

                /*Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined  =int.Parse(columns[7])*/
            };
        }

         /*
         public Technician() { }

         public Technician(string name)
         {
             this.Name = name;
         }

         public Technician(string name, string num, string email)
         {
             this.Name = name;
             this.PhoneNumber = num;
             this.Email = email;
         }

         public override bool Equals(object obj)
         {
             return base.Equals(obj);
         }

         public override int GetHashCode()
         {
             return base.GetHashCode();
         }

         public override string ToString()
         {
             return base.ToString();
         }*/
        }
}
