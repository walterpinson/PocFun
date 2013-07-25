using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infrastructure.PocFunApi.Models
{
    public interface IMessage<T> where T : class
    {
        IList<Metadata<T>> Metadata { get; set; }
        IList<T> Items { get; set; }
        IList<string> Actions { get; set; }
        IList<string> Queries { get; set; }
        IList<Error> Errors { get; set; }
    }
}
