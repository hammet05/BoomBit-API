namespace TestBoomBit.Common
{
    public class ResponseGeneric<T> 
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
