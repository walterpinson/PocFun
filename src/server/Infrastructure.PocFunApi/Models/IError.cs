using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.PocFunApi.Models
{
    public interface IError
    {
        string Name { get; set; }
        string InternalCode { get; set; }
        string Description { get; set; }
        string ItemRef { get; set; }
    }
}