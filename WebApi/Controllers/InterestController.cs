using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        static List<Interest> interestData =new List<Interest>();
        static List<LoanClass> LoanData = new List<LoanClass>();
        public InterestController()
        {
            if(interestData.Count == 0)
            {
                interestData.Add(new Interest { minAmt = 5000, I_rate = 12, maxAmt = 25000 });
                interestData.Add(new Interest { minAmt = 50000, I_rate = 10, maxAmt = 100000 });
                interestData.Add(new Interest { minAmt = 25000, I_rate = 15, maxAmt = 75000 });
            }
        }
        // GET: api/<InterestController>
        [HttpGet]
        public IEnumerable<LoanClass> Get()
        {
            return LoanData.ToList();
        }

        // GET api/<InterestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InterestController>
        [HttpPost]
        public void Post([FromBody] LoanClass loan_user_data)
        {
            //List<LoanClass> loan_data;
            int id = LoanData.Count;
            double I_Rate_data = 0;
            
            double I_Rate_data_linq = (from i in interestData
                                      where i.minAmt < loan_user_data.P_Amt && i.maxAmt >                       loan_user_data.P_Amt
                                      select i.I_rate).FirstOrDefault();
            //if(loan_user_data.Age>=50 && loan_user_data.Gender == "female")
            //{
            //    if(loan_user_data.Age >= 50 || loan_user_data.Gender == "female")
            //    {
            //        I_Amt_data = (loan_user_data.P_Amt * I_Rate_data_linq - 1 * loan_user_data.N_year) / 100;
            //    }
            //}
            
            if (loan_user_data.Gender == "female")
            {
                I_Rate_data_linq = I_Rate_data - 1;
            }
            if (loan_user_data.Age >= 50)
            {
                I_Rate_data_linq = I_Rate_data - 1;
            }
            double I_Amt_data = (loan_user_data.P_Amt * I_Rate_data_linq * loan_user_data.N_year) / 100;


            //foreach (var i in interestData)
            //{
            //    if (i.minAmt < loan_user_data.P_Amt && i.maxAmt > loan_user_data.P_Amt)
            //    {
            //        I_Rate_data = i.I_rate;
            //    }
            //    else if (i.minAmt < loan_user_data.P_Amt && i.maxAmt > loan_user_data.P_Amt)
            //    {
            //        I_Rate_data = i.I_rate;
            //    }
            //    else if (i.minAmt < loan_user_data.P_Amt && i.maxAmt > loan_user_data.P_Amt)
            //    {
            //        I_Rate_data = i.I_rate;
            //    }

            //    if (loan_user_data.Gender == "female")
            //    {
            //        I_Amt_data = (loan_user_data.P_Amt * I_Rate_data - 1 * loan_user_data.N_year) / 100;
            //    }
            //    if (loan_user_data.Age >= 50)
            //    {
            //        I_Amt_data = (loan_user_data.P_Amt * I_Rate_data - 1 * loan_user_data.N_year) / 100;
            //    }
            //    I_Amt_data = (loan_user_data.P_Amt * I_Rate_data * loan_user_data.N_year) / 100;
            //}
            LoanData.Add(new LoanClass { Loan_ID = id + 1, Name = loan_user_data.Name, Gender = loan_user_data.Gender, Age = loan_user_data.Age, P_Amt = loan_user_data.P_Amt, N_year = loan_user_data.N_year,I_rate= I_Rate_data_linq, I_Amt= I_Amt_data });
        }

        // PUT api/<InterestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
