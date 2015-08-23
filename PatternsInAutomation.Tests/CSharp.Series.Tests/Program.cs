using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Series.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1.1. Curry Invoke Function Example

            ////Func<int, int, int, int> addNumbers = (x, y, z) => x + y + z;
            ////var f1 = addNumbers.Curry();
            ////Func<int, Func<int, int>> f2 = f1(3);
            ////Func<int, int> f3 = f2(4);
            ////Console.WriteLine(f3(5));

            // 1.2. Partial Invoke Function Example

            ////Func<int, int, int, int> sumNumbers = (x, y, z) => x + y + z;
            ////Func<int, int> f4 = sumNumbers.Partial(3, 4);
            ////Console.WriteLine(f4(5));

            // 2. Obsolete Attribute Test

            ////Console.WriteLine(ObsoleteExample.OrderDetailTotal);
            ////Console.WriteLine();
            ////Console.WriteLine(ObsoleteExample.CalculateOrderDetailTotal());

            // 3. Default Value Attribute Example

            ////DefaultValueAttributeTest defaultValueAtt = new DefaultValueAttributeTest();
            ////Console.WriteLine(defaultValueAtt);

            // 4. DebuggerBrowsable attribute example

            ////DebuggerBrowsableTest.SquirrelFirstNameName = "Hammy";
            ////DebuggerBrowsableTest.SquirrelLastNameName = "Ammy";

            // 5. Default Value Operator ?? example

            ////int? x = null;
            ////int y = x ?? -1;
            ////Console.WriteLine("y now equals -1 because x was null => {0}", y);
            ////int i = DefaultValueOperatorExample.GetNullableInt() ?? default(int);
            ////Console.WriteLine("i equals now 0 because GetNullableInt() returned null => {0}", i);
            ////string s = DefaultValueOperatorExample.GetStringValue();
            ////Console.WriteLine("Returns 'Unspecified' because s is null => {0}", s ?? "Unspecified");

            // 6. WeakReference example
            ////WeakReferenceTest hugeObject = new WeakReferenceTest();
            ////hugeObject.SharkFirstName = "Sharky";
            ////WeakReference w = new WeakReference(hugeObject);
            ////hugeObject = null;
            ////GC.Collect();
            ////Console.WriteLine((w.Target as WeakReferenceTest).SharkFirstName);

            // 8. BigInteger example

            ////string positiveString = "91389681247993671255432112000000";
            ////string negativeString = "-90315837410896312071002088037140000";
            ////BigInteger posBigInt = 0;
            ////BigInteger negBigInt = 0;

            ////posBigInt = BigInteger.Parse(positiveString);
            ////Console.WriteLine(posBigInt);
            ////negBigInt = BigInteger.Parse(negativeString);
            ////Console.WriteLine(negBigInt);

            // 9. Undocumented C# Types and Keywords __arglist __reftype __makeref __refvalue example

            ////int i = 21;
            ////TypedReference tr = __makeref(i);
            ////Type t = __reftype(tr);
            ////Console.WriteLine(t.ToString());
            ////int rv = __refvalue( tr,int);
            ////Console.WriteLine(rv);
            ////ArglistTest.DisplayNumbersOnConsole(__arglist(1, 2, 3, 5, 6));

            // 10. Environment.NewLine example

            ////Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line", Environment.NewLine);

            // 11. ExceptionDispatcher example

            ////ExceptionDispatchInfo possibleException = null;

            ////try
            ////{
            ////    int.Parse("a");
            ////}
            ////catch (FormatException ex)
            ////{
            ////    possibleException = ExceptionDispatchInfo.Capture(ex);
            ////}

            ////if (possibleException != null)
            ////{
            ////    possibleException.Throw();
            ////}

            // 12. Environment.FailFast() example

            ////string s = Console.ReadLine(); 
            ////try 
            ////{ 
            ////    int i = int.Parse(s); 
            ////    if (i == 42) Environment.FailFast("Special number entered"); 
            ////} 
            ////finally 
            ////{ 
            ////    Console.WriteLine("Program complete."); 
            ////} 

            // 13. Debug.Assert and Debug.WriteIf example

            ////Debug.Assert(1 == 0, "The numbers are not equal! Oh my god!");

            ////Debug.WriteLineIf(1 == 1, "This message is going to be displayed in the Debug output! =)");

            ////Debug.WriteLine("What are ingredients to bake a cake?");
            ////Debug.Indent();
            ////Debug.WriteLine("1. 1 cup (2 sticks) butter, at room temperature.");
            ////Debug.WriteLine("2 cups sugar");
            ////Debug.WriteLine("3 cups sifted self-rising flour");
            ////Debug.WriteLine("4 eggs");
            ////Debug.WriteLine("1 cup milk");
            ////Debug.WriteLine("1 teaspoon pure vanilla extract");
            ////Debug.Unindent();
            ////Debug.WriteLine("End of list");

            // 14.1. Parallel For example

            ////int[] nums = Enumerable.Range(0, 1000000).ToArray();
            ////long total = 0;

            ////// Use type parameter to make subtotal a long, not an int
            ////Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            ////{
            ////    subtotal += nums[j];
            ////    return subtotal;
            ////},
            ////    (x) => Interlocked.Add(ref total, x)
            ////);

            ////Console.WriteLine("The total is {0:N0}", total);

            // 14.2 Parallel Foeach example

            ////int[] nums = Enumerable.Range(0, 1000000).ToArray();
            ////long total = 0;
         
            ////Parallel.ForEach<int, long>(nums, // source collection
            ////                            () => 0, // method to initialize the local variable
            ////    (j, loop, subtotal) => // method invoked by the loop on each iteration
            ////    {
            ////        subtotal += j; //modify local variable 
            ////        return subtotal; // value to be passed to next iteration
            ////    },
            ////    // Method to be executed when each partition has completed. 
            ////    // finalResult is the final value of subtotal for a particular partition.
            ////(finalResult) => Interlocked.Add(ref total, finalResult));

            ////Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);

            // 15. IsInfinity example
            ////Console.WriteLine("IsInfinity(3.0 / 0) == {0}.", Double.IsInfinity(3.0 / 0) ? "true" : "false");
        }
    }    
}