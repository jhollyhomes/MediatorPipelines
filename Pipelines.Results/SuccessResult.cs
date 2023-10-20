namespace Pipelines.Results;
public class SuccessResult : IPipelineResult
{
    public SuccessResult()
    {
        Data = "";
        Errors = new List<string>();
        IsSuccess = true;
    }
    public SuccessResult(object data)
    {
        Data = data;
        Errors = new List<string>();
        IsSuccess = true;
    }
    public bool IsSuccess { get; }
    public bool IsError { get; }
    public bool IsAuthorisationFailure { get; }
    public bool IsValidationFailure { get; }
    public object Data { get; }
    public List<string> Errors { get; }
}
