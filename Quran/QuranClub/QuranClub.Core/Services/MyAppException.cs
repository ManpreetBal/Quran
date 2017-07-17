using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuranClub.Core.Services
{
    public class MyAppException : Exception
    {
        public string Title { get; set; }
        public MyAppException()
        { }

        public MyAppException(string message)
            : base(message)
        { }

        public MyAppException(string message, Exception innerException)
            : base(message, innerException)
        { }
        public class ReturnJson
        {
            public IEnumerable<MyAppException> error { get; set; }
        }

       
    }
}
