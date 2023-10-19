using Pipeline.Xtests.Commands;
using Pipeline.Xtests.Dtos;
using Pipeline.Xtests.Helpers;
using Shouldly;

namespace Pipeline.Xtests;

public class PipelineTests
{
    [Fact]
    public async Task GivenNewUser_WhenValid_ThenReturnSuccessResultWithUser()
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand("Jimmy", "Starbucks"));

        response.IsSuccess.ShouldBeTrue();

        var result = (User)response.Data;

        result.ShouldSatisfyAllConditions
            (
                t => t.FirstName.ShouldBe("Jimmy"),
                t => t.LastName.ShouldBe("Starbucks")
            );
    }

    [Fact]
    public async Task GivenNewUser_WhenNotValid_ThenReturnValidationFailureResult()
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand("", "Starbucks"));

        response.IsValidationFailure.ShouldBeTrue();
        response.Errors.Count.ShouldBe(1);
    }
}