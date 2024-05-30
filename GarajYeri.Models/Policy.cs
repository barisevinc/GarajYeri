using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeri.Models
{
    public class Policy:BaseModel
    {
        public string Name {  get; set; }
        public string CompanyName {  get; set; }
        public string Validity {  get; set; }
    }
}
