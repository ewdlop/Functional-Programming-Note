using Functional_Programming_Note_Net;
using System.Collections.Frozen;
using System.Linq;


FrozenDictionary<int, StudentName> frozenDictionary = Enumerable.Range(1, 10)
    .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
    .ToFrozenDictionary(x => x.ID, x => x);


//copy to a frozenset 

//copy keys to a frozenset 
FrozenSet<int> frozenSet = frozenDictionary.Keys.ToFrozenSet();

//
Lazy<FrozenDictionary<int, StudentName>> lazyFrozenSet = new(static () => 
    Enumerable.Range(1, 10)
        .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
        .ToFrozenDictionary(x => x.ID, x => x));