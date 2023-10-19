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
        response.IsError.ShouldBeFalse();
        response.IsValidationFailure.ShouldBeFalse();

        var result = (User)response.Data;

        result.ShouldSatisfyAllConditions
            (
                t => t.FirstName.ShouldBe("Jimmy"),
                t => t.LastName.ShouldBe("Starbucks")
            );
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Jimmy", "")]
    [InlineData("", "Starbucks")]
    public async Task GivenNewUser_WhenNotValid_ThenReturnValidationFailureResult(string firstName, string lastName)
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand(firstName, lastName));

        response.IsValidationFailure.ShouldBeTrue();
        response.IsError.ShouldBeFalse();
        response.IsSuccess.ShouldBeFalse();
        response.Errors.Count.ShouldBeGreaterThan(0);
    }
}