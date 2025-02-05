# Functional-Programming-Note

## im·mu·ta·ble 

## referential transparency

## Idempotence

## lazy evaluation 

### **Fix-Point Combinator in C#**
A **Fix-Point Combinator** (or **Y-Combinator**) is a higher-order function that allows **recursive functions** to be written **without explicit self-reference**. This is useful in **functional programming** and **lambda calculus**.

---

## **1. Why Use a Fix-Point Combinator?**
✅ **Enables recursion without named functions**.  
✅ **Useful for functional programming paradigms**.  
✅ **Applies recursion in anonymous functions (lambdas)**.  
✅ **Can be applied to lazy evaluation and memoization**.  

---

## **2. Mathematical Definition of the Y-Combinator**
A **Fix-Point Combinator** satisfies:

\[
Y(f) = f(Y(f))
\]

where:
- \( Y \) is the fix-point combinator.
- \( f \) is a recursive function.
- \( Y(f) \) continuously applies \( f \) to itself.

This is used to define **anonymous recursive functions**.

---

## **3. Implementation of Fix-Point Combinator in C#**
In C#, functions cannot reference themselves directly in a lambda expression. However, we can use **delegates and higher-order functions** to define a fix-point combinator.

### **Recursive Lambda Using Fix-Point Combinator**
```csharp
using System;

class Program
{
    // Fix-Point Combinator for Recursion
    static Func<T, R> Fix<T, R>(Func<Func<T, R>, Func<T, R>> f)
    {
        return x => f(Fix(f))(x);
    }

    static void Main()
    {
        // Factorial function using Y-Combinator
        var factorial = Fix<int, int>(fact => x => x == 0 ? 1 : x * fact(x - 1));

        // Fibonacci function using Y-Combinator
        var fibonacci = Fix<int, int>(fib => x => x <= 1 ? x : fib(x - 1) + fib(x - 2));

        Console.WriteLine("Factorial of 5: " + factorial(5)); // Output: 120
        Console.WriteLine("Fibonacci(10): " + fibonacci(10)); // Output: 55
    }
}
```

---

## **4. Explanation**
1. **Fix Function**  
   - `Fix<T, R>` takes a **higher-order function** \( f \) and **returns a recursive function**.
   - It applies \( f \) **to itself** to enable recursion.

2. **Factorial Example**
   - \( n! = n \times (n-1)! \)
   - Instead of explicit recursion, `fact(x - 1)` gets the function recursively.

3. **Fibonacci Example**
   - \( F(n) = F(n-1) + F(n-2) \)
   - Uses `Fix` to define Fibonacci recursively.

---

## **5. Alternative: Using Closures**
C# also allows **closures** for recursion:
```csharp
using System;

class Program
{
    static void Main()
    {
        Func<Func<int, int>, Func<int, int>> factorialGen = fact => x => x == 0 ? 1 : x * fact(x - 1);
        var factorial = Fix(factorialGen);
        
        Console.WriteLine("Factorial of 6: " + factorial(6)); // Output: 720
    }

    static Func<T, R> Fix<T, R>(Func<Func<T, R>, Func<T, R>> f)
    {
        return x => f(Fix(f))(x);
    }
}
```
This **avoids named recursion** while keeping function purity.

---

## **6. Key Takeaways**
✅ **Fix-Point Combinators enable recursion without named functions**.  
✅ **Useful in functional programming and lambda calculus**.  
✅ **C# can implement Y-Combinators using delegates and higher-order functions**.  
✅ **Can be applied to memoization and lazy evaluation**.  

Would you like an **optimized version with memoization** for performance? 🚀
