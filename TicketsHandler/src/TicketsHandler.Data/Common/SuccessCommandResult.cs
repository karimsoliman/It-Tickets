namespace TicketsHandler.Data.Common
{
    public class SuccessCommandResult<T> : CommandResult<T>
    {
        #region Constructor

        public SuccessCommandResult(T data)
        {
            Data = data;
        }

        #endregion

        #region Properties

        public override ResultType ResultType => ResultType.Ok;

        public override List<string> Errors => new List<string>();

        public override T Data { get; }

        #endregion
    }
}
