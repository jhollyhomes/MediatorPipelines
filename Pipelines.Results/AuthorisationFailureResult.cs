namespace Pipelines.Results;
public class AuthorisationFailureResult : IPipelineResult
{
    public AuthorisationFailureResult(string failureMessage)
    {
        Data = "";
        Errors = new List<string>
        {
            failureMessage
        };
        IsAuthorisationFailure = true;
    }
    public bool IsSuccess { get; }
    public bool IsError { get; }
    public bool IsAuthorisationFailure { get; }
    public bool IsValidationFailure { get; }
    public object Data { get; }
    public List<string> Errors { get; }
}