using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

    public  class CustomerDto
    {
       [Required]
        public string customerName { get; set; }
        public string phoneNumber { get; set; }
    }
