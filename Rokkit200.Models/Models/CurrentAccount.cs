using Rokkit200.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokkit200.Models.Models
{
    public class CurrentAccount : Account
    {
        [Range(0, 100000)]
        private new long Overdraft {get;set;}
    }
}
