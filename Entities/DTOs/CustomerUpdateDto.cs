using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerUpdateDto : IDto
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
    }
}
