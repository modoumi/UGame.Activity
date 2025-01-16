using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UGame.Activity.Signin.Model
{
    public class SigninDto
    {

        public bool Status { get; set; } = false;

        public decimal RewardAmount { get; set; }

        public string StatusDesc { get; set; }
        
        public string ServerTime { get; set; }
        
        public string UtcTime { get; set; }
        
        public string LocalTime { get; set; }
        
        public string SigninCycleStartDate { get; set; }
        
        public string SigninCycleEndDate { get; set; }
    }
}
