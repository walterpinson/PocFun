using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Messages
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public bool IsFilled { get; set; }
        public Guid? PersonHiredId { get; set; }
    }
}
