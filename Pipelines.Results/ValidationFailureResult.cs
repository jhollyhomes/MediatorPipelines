namespace Pipelines.Results;
public class ValidationFailureResult : IPipelineResult
{
    public ValidationFailureResult(List<string> errors)
    {
        Data = errors;
        Errors = errors;
        IsValidationFailure = true;
    }
    public bool IsSuccess { get; }
    public bool IsError { get; }
    public bool IsAuthorisationFailure { get; }
    public bool IsValidationFailure { get; }
    public object Data { get; }
    public List<string> Errors { get; }
}
