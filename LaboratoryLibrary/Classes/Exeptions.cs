namespace LaboratoryLibrary.Exceptions
{
    public class ReagentUnavailableException : Exception
    {
        public ReagentUnavailableException() { }
        public ReagentUnavailableException(string message) : base(message) { }
        public ReagentUnavailableException(string message, Exception inner) : base(message, inner) { }
    }
}
