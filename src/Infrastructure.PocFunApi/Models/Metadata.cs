﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Domain.Models;

namespace Infrastructure.PocFunApi.Models
{
    public class Metadata<T> : IMetadata
    {
        public string ItemsType
        {
            get { return typeof(T).ToString(); }
            set { }
        }
        public string DateTimeFormat { get; set; }
        public string MsgFormatVer { get; set; }
        public string Token { get; set; }
    }
}