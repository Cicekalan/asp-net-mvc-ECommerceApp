namespace ECommerceApp.Core
{
    public class Result<TEntity>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TEntity? Data { get; set; }

        public Result(bool success, string message, TEntity? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}