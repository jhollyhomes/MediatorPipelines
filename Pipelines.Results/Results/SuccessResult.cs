﻿namespace Pipelines.Results.Results;
public class SuccessResult : IPipelineResult
{
    public SuccessResult(object data)
    {
        Data = data;
        Errors = new List<string>();
        IsSuccess = true;
    }
    public bool IsSuccess { get; }

    public bool IsError { get; }

    public bool IsValidationFailure { get; }

    public object Data { get; }

    public List<string> Errors { get; }
}