#region using
using System;
using System.Threading.Tasks;
#endregion

/// <summary>
/// Quick demonstration on async operations from lambdas, delegates and anonymous function
/// <see href="https://vscode.readthedocs.io/en/latest/other/dotnet/"> Example VS code console app </see>
/// </summary>
class HelloWorldAsync {
   #region constants
   private static readonly int MAX_ITER = 10;
   private static readonly int MAX_DELAY = 10;
   #endregion
   /// <summary>
   /// <see cref="foo"/>
   /// </summary>
   public static async Task<int> foo (int delay) {
      await Task.Delay (delay);
      return delay;
   }

   /// <summary>
   /// <see cref="bar"/>
   /// </summary>
   public static async void bar () {
      /// Lambda
      Func<int, Task<int>> l = async (delay) => {
         await Task.Delay (delay);
         return delay;
      };

      /// Use lambda
      for (var i = 0; i < MAX_ITER; i++) {
         int val = await l (i * new Random ().Next (MAX_DELAY));
         Console.WriteLine ($"From lambda #{i} with delay {val} [ms].");
      }
   }

   /// <summary>
   /// <see cref="baz2"/>
   /// </summary>
   public static async void baz2 () {
      Func<int, Task<int>> del = async delegate (int delay) {
         await Task.Delay (delay);
         return delay;
      };

      for (var i = 0; i < MAX_ITER; i++) {
         int val = await del (i * new Random ().Next (MAX_DELAY));
         Console.WriteLine ($"From delegate #{i} with delay {val} [ms].");
      }
   }

   /// <summary>
   /// <see cref="baz"/>
   /// </summary>
   public static async void baz () {
      for (var i = 0; i < MAX_ITER; i++) {
         int val = await foo (i * new Random ().Next (MAX_DELAY));
         System.Console.WriteLine ($"From anonymous function #{i} with delay {val} [ms].");
      }
   }

   /// <summary>
   /// <see cref="Main"/>
   /// </summary>
   public static void Main () {
      /// Two sweeps of async operations, one with lambdas and one with anonymous functions
      System.Console.WriteLine ("Lambdas...");
      bar ();
      System.Console.WriteLine ("Anonymous functions...");
      baz ();
      System.Console.WriteLine ("Delegates...");
      baz2 ();

      /// Identify ourselves
      System.Console.WriteLine ("Hello async world!");

      /// Keep main thread alive
      Console.ReadLine ();
   }
}