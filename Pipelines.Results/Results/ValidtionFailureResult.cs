namespace Pipelines.Results.Results;
public class ValidtionFailureResult : IPipelineResult
{
    public ValidtionFailureResult(List<string> errors)
    {
        Data = errors;
        Errors = errors;
        IsValidationFailure = true;
    }
    public bool IsSuccess { get; }

    public bool IsError { get; }

    public bool IsValidationFailure { get; }

    public object Data { get; }

    public List<string> Errors { get; }
}
