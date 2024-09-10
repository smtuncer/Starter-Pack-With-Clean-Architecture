using System.Text.Json.Serialization;

namespace Project.Domain.Model;
public class ResultModel<TEntity>
{
    public ResultModel(TEntity data)
    {
        Data = data;
    }
    public ResultModel(int statusCode, List<string> errorMessages)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = errorMessages;
    }
    public ResultModel(int statusCode, string errorMessage)
    {
        IsSuccessful = false;
        StatusCode = statusCode;
        ErrorMessages = new List<string> { errorMessage };
    }
    public TEntity? Data { get; set; }

    public List<string>? ErrorMessages { get; set; }

    public bool IsSuccessful { get; set; } = true;

    [JsonIgnore]
    public int StatusCode { get; set; } = 200;


    public static implicit operator ResultModel<TEntity>(TEntity data)
    {
        return new ResultModel<TEntity>(data);
    }

    public static implicit operator ResultModel<TEntity>((int statusCode, List<string> errorMessages) parameters)
    {
        return new ResultModel<TEntity>(parameters.statusCode, parameters.errorMessages);
    }

    public static implicit operator ResultModel<TEntity>((int statusCode, string errorMessage) parameters)
    {
        return new ResultModel<TEntity>(parameters.statusCode, parameters.errorMessage);
    }

    public static ResultModel<TEntity> Succeed(TEntity data)
    {
        return new ResultModel<TEntity>(data);
    }

    public static ResultModel<TEntity> Failure(int statusCode, List<string> errorMessages)
    {
        return new ResultModel<TEntity>(statusCode, errorMessages);
    }

    public static ResultModel<TEntity> Failure(int statusCode, string errorMessage)
    {
        return new ResultModel<TEntity>(statusCode, errorMessage);
    }

    public static ResultModel<TEntity> Failure(string errorMessage)
    {
        return new ResultModel<TEntity>(500, errorMessage);
    }

    public static ResultModel<TEntity> Failure(List<string> errorMessages)
    {
        return new ResultModel<TEntity>(500, errorMessages);
    }
}