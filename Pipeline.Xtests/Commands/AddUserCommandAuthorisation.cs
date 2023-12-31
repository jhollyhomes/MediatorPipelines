﻿using Pipelines;
using Pipelines.Results;

namespace Pipeline.Xtests.Commands;
public class AddUserCommandAuthorisation<TRequest, TResponse> : IAuthorisationHandler<AddUserCommand, IPipelineResult>
{
    public async Task<IPipelineResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        if (request.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            return await Task.FromResult(new SuccessResult());
        }        

        return await Task.FromResult(new AuthorisationFailureResult("invalid user name"));
    }
}
