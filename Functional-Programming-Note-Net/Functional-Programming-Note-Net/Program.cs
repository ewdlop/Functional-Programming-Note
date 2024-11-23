using ClassLibrary1;
using System.Collections.Frozen;
using System.Linq;


//immutable dictionary
FrozenDictionary<int, StudentName> frozenDictionary = Enumerable.Range(1, 10)
    .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
    .ToFrozenDictionary(x => x.ID, x => x);

//immutable dictionary
FrozenDictionary<int, StudentName> frozenDictionary2 = Enumerable.Range(1, 10)
    .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
    .ToFrozenDictionary(x => x.ID, x => x);


Console.WriteLine(frozenDictionary.Equals(frozenDictionary2)); //false
Console.WriteLine(frozenDictionary.SequenceEqual(frozenDictionary2));//true

//copy to a frozenset 

//copy keys to a frozenset 
FrozenSet<int> frozenSet = frozenDictionary.Keys.ToFrozenSet();


//Lazy evaluation
Lazy<FrozenDictionary<int, StudentName>> lazyFrozenDictonary = new(static () =>
    Enumerable.Range(1, 10)
        .Select(static i => new StudentName($"First-{i}", LastName: $"Last-{i}", ID: i))
        .ToFrozenDictionary(x => x.ID, x => x));