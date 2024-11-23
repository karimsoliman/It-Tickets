namespace TicketsHandler.Data.Common
{
    public class UnexpectedCommandResult<T> : CommandResult<T>
    {
        #region Fields

        private readonly string _error;

        #endregion

        #region Constructors

        public UnexpectedCommandResult()
        {
            _error = "There was an unexpected problem.";
        }

        public UnexpectedCommandResult(string error)
        {
            _error = error;
        }

        public UnexpectedCommandResult(Exception exception)
        {
            Exception = exception;
        }

        #endregion

        #region Properties

        public override ResultType ResultType => ResultType.Unexpected;

        public override List<string> Errors => new List<string> { Exception?.Message ?? _error };

        public override T Data => default;

        public Exception Exception { get; }

        #endregion
    }
}
