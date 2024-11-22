using System.Collections.Frozen;
using System.Linq;
using Test;


FrozenDictionary<int, StudentName>? frozenDictionary = Enumerable.Range(1, 10)
    .Select(i => new StudentName { FirstName = $"First-{i}", LastName = $"Last-{i}", ID = i })
    .ToFrozenDictionary(x => x.ID, x => x);

FrozenSet<int> frozenSet = frozenDictionary.Keys.ToFrozenSet();
namespace Test
{

    public record StudentName(string FirstName, string LastName, int ID);
}

//copy to a frozenset 
