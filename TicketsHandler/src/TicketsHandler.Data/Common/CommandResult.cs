namespace TicketsHandler.Data.Common
{
    public abstract class CommandResult<T>
    {
        #region Properties

        public abstract ResultType ResultType { get; }
        public abstract List<string> Errors { get; }
        public abstract T Data { get; }

        #endregion
    }
}
