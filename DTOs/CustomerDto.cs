using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    
    public class CustomerDto
    {
        public string ID { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string NameAR { set; get; }
        public string NameEN { set; get; }
      
        public DateTime DateEntered { get; set; }

       
    }
}
