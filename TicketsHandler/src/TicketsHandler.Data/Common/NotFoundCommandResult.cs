namespace TicketsHandler.Data.Common
{
    public class NotFoundCommandResult<T> : CommandResult<T>
    {
        #region Propeties

        public override ResultType ResultType => ResultType.NotFound;

        public override List<string> Errors => new List<string> { "The requested resource was not found." };

        public override T Data => default;

        #endregion
    }
}
