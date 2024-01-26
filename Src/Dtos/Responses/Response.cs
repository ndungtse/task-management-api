namespace task_management_api.Dtos.Responses;

public class Response<T>
{
    public T Data { set; get; } = default!;
    public string Message { set; get; } = "";
    public bool Success { set; get; }
    public dynamic Error { set; get; } = default!;
    
    public Response(T data, string message, bool success)
    {
        Data = data;
        Message = message;
        Success = success;
    }
    
    public Response(string message, bool success, dynamic error)
    {
        Message = message;
        Success = success;
        Error = error;
    }
    
    public Response(T data, bool success)
    {
        Data = data;
        Success = success;
    }
    
    public Response(string message, bool success)
    {
        Message = message;
        Success = success;
    }
    
    public Response(bool success)
    {
        Success = success;
    }
    
    public Response(T data)
    {
        Data = data;
    }
    
    public Response()
    {
    }
}