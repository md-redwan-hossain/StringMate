using DotCheck.StringValidation;
using DotCheck.StringValidation.CoreValidators.Enums;
using DotCheck.StringValidation.StringExtensions;

namespace DotCheck.Test.StringExtensions;

public class UuidTest
{
    private const string V1 = "ac90b418-a169-11ee-8c90-0242ac120002";
    private const string V2 = "000003e8-a16a-21ee-bd00-325096b39f47";
    private const string V3 = "80523c1b-349d-3c2a-a92a-2baf44b2d240";
    private const string V4 = "b207482e-e29d-42f2-9469-883e4fca8d76";
    private const string V5 = "6a500c3b-2e93-59da-8d7f-1a48fe1f1a7e";


    [Fact]
    public void V1Check() =>
        Assert.True(V1.IsUuid(UuidVersion.V1));

    [Fact]
    public void V2Check() =>
        Assert.True(V2.IsUuid(UuidVersion.V2));

    [Fact]
    public void V3Check() =>
        Assert.True(V3.IsUuid(UuidVersion.V3));

    [Fact]
    public void V4Check() =>
        Assert.True(V4.IsUuid(UuidVersion.V4));

    [Fact]
    public void V5Check() =>
        Assert.True(V5.IsUuid(UuidVersion.V5));


    [Fact]
    public void AllCheck() =>
        Assert.True(CheckAll());

    private static bool CheckAll()
    {
        var storage = new[] { V1, V2, V3, V4, V5 };
        return storage.All(x => x.IsUuid(UuidVersion.All));
    }
}