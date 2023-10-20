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
        var response = await mediatr.Send(new AddUserCommand("Jimmy", "Starbucks", "admin"));

        response.IsSuccess.ShouldBeTrue();
        response.IsError.ShouldBeFalse();
        response.IsValidationFailure.ShouldBeFalse();
        response.IsAuthorisationFailure.ShouldBeFalse();

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
        var response = await mediatr.Send(new AddUserCommand(firstName, lastName, "admin"));

        response.IsValidationFailure.ShouldBeTrue();
        response.IsError.ShouldBeFalse();
        response.IsSuccess.ShouldBeFalse();
        response.IsAuthorisationFailure.ShouldBeFalse();

        response.Errors.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task GivenNewUser_WhenNotAuthorisedAndValid_ThenReturnAuthorisationFailureResult()
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand("Jimmy", "Starbucks", "badusername"));

        response.IsAuthorisationFailure.ShouldBeTrue();
        response.IsSuccess.ShouldBeFalse();
        response.IsError.ShouldBeFalse();
        response.IsValidationFailure.ShouldBeFalse();

        response.Errors.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task GivenNewUser_WhenNotAuthorisedAndNotValid_ThenReturnAuthorisationFailureResult()
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand("", "Starbucks", "badusername"));

        response.IsAuthorisationFailure.ShouldBeTrue();
        response.IsSuccess.ShouldBeFalse();
        response.IsError.ShouldBeFalse();
        response.IsValidationFailure.ShouldBeFalse();

        response.Errors.Count.ShouldBeGreaterThan(0);
    }
}