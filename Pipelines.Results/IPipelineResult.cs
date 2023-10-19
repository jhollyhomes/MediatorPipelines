namespace Pipelines.Results;

public interface IPipelineResult
{
    bool IsSuccess { get; }
    bool IsError { get; }
    bool IsValidationFailure { get; }
    object Data { get; }
    List<string> Errors { get; }
}
