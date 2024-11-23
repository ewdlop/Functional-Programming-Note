using ClassLibrary1;
using System.Collections.Frozen;

namespace TestProject1;

public class UnitTest1
{
    protected readonly FrozenDictionary<int, StudentName> frozenDictionary = Enumerable.Range(1, 10)
           .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
           .ToFrozenDictionary(x => x.ID, x => x);

    //immutable dictionary
    protected readonly FrozenDictionary<int, StudentName> frozenDictionary2 = Enumerable.Range(1, 10)
        .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
        .ToFrozenDictionary(x => x.ID, x => x);

    public UnitTest1()
    {

    }

    [Fact]
    public void TestEquals()
    {

        Assert.True(frozenDictionary.SequenceEqual(frozenDictionary2));
        Assert.False(frozenDictionary.Equals(frozenDictionary2));
    }
}
