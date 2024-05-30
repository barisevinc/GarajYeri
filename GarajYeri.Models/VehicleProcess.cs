using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeri.Models
{
    public class VehicleProcess:BaseModel
    {
        public  double Odemeter {  get; set; }
        public double? Price { get; set; }
    }
}
