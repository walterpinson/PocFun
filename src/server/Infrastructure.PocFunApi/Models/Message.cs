using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.PocFunApi.Models
{
    public class Message<T> : IMessage<T> where T : class
    {
        private IList<Metadata<T>> _metadata = new List<Metadata<T>>();
        private IList<T> _items = new List<T>();
        private IList<string> _actions = new List<string>();
        private IList<string> _queries = new List<string>();
        private IList<Error> _errors = new List<Error>();
        
        public IList<Metadata<T>> Metadata
        {
            get
            {
                if (!_metadata.Any() || _metadata.Count() > 1)
                {
                    // Create new collection instance ... for now, likely only one instance in collection ever returned
                    _metadata = new List<Metadata<T>>();

                    var metadataItem = new Metadata<T>
                    {
                        DateTimeFormat = "yyyy-mm-dd hh:mm+/-hh:mm",
                        MsgFormatVer = "v1",
                    };

                    _metadata.Add(metadataItem);
                }

                return _metadata;
            }

            set { _metadata = value; }
        }

        public IList<T> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public IList<string> Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public IList<string> Queries
        {
            get { return _queries; }
            set { _queries = value; }
        }

        public IList<Error> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }
    }
}