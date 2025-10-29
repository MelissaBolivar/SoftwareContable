namespace Contable.Domain.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException() { }

        public AppException(
            string message
        ) : base(message) { }

        public AppException(
            string message,
            Exception inner
        ) : base(message, inner) { }

        protected AppException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
#pragma warning disable SYSLIB0051 // El tipo o el miembro están obsoletos
        ) : base(info, context) { }
#pragma warning restore SYSLIB0051 // El tipo o el miembro están obsoletos
    }
}
