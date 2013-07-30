using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.PocFunApi.Models
{
    public class Error : IError
    {
        public string Name { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public string ItemRef { get; set; }
    }
}