using Pipelines.Tests.Commands;
using Pipelines.Tests.Helpers;
using Shouldly;

namespace Pipelines.Tests;

[TestClass]
public class PipelineTests
{
    [TestMethod]
    public async Task GivenNewUser_WhenValid_ThenReturnUser()
    {
        var mediatr = MediatorHelpers.BuildMediator();
        var response = await mediatr.Send(new AddUserCommand("Jimmy", "Starbucks"));

        response.ShouldSatisfyAllConditions
            (
                t => t.FirstName.ShouldBe("Jimmy"),
                t => t.LastName.ShouldBe("Starbucks")
            );
    }


}