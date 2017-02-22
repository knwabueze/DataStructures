using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Exceptions
{
    public class KeyAlreadyExistsException : Exception
    {
        public KeyAlreadyExistsException()
        {
        }

        public KeyAlreadyExistsException(string message) : base(message)
        {
        }

        public KeyAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KeyAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
