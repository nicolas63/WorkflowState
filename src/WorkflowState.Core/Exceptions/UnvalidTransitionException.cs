using System;
using System.Runtime.Serialization;

namespace WorkflowState.Core.Exceptions
{        
    public class UnvalidTransitionException : Exception
    {
        public UnvalidTransitionException()
        {
        }

        protected UnvalidTransitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UnvalidTransitionException(string message) : base(message)
        {
        }

        public UnvalidTransitionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}