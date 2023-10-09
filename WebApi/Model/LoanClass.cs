using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class LoanClass
    {
        public int Loan_ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double P_Amt { get; set; }
        public int N_year { get; set; }
        public double I_rate { get; set; }
        public double I_Amt { get; set; }
    }
}
