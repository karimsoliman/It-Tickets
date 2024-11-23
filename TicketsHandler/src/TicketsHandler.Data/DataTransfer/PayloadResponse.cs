namespace TicketsHandler.Data.DataTransfer
{
    public class PayloadResponse<T>
    {
        public ICollection<T> Payload { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int Count { get; set; }
    }
}
