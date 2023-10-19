namespace Pipelines.Results.Results;
public class ErrorResult : IPipelineResult
{
    public ErrorResult(Exception exception)
    {
        Data = exception;
        Errors = new List<string>
        {
            exception.Message
        };

        IsError = true;
    }
    
    public bool IsSuccess { get; }
    public bool IsError { get; }
    public bool IsAuthorisationFailure { get; }
    public bool IsValidationFailure { get; }
    public object Data { get; }
    public List<string> Errors { get; }
}
