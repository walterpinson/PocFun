using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infrastructure.PocFunApi.Models
{
    public interface IMetadata
    {
        string ItemsType { get; set; }
        string DateTimeFormat { get; set; }
        string MsgFormatVer { get; set; }
    }
}
