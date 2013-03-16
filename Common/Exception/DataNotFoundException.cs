using System;

namespace Common.Exception
{
    public class DataNotFoundException : ApplicationException
    {
        public DataNotFoundException() { }

        public DataNotFoundException(string message) : base(message) { }
    }
}