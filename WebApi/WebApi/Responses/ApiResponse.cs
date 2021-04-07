namespace WebApi.Controllers
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Result = data;
        }

        public T Result { get; set; }
    }
}