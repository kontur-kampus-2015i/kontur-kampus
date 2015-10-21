using System;
using System.IO;
using NUnit.Framework;

namespace CleanCode
{
	[TestFixture]
	public class Chess_Test
	{
		[Test]
		public void Test()
		{
            int testsCount = 0;
			foreach (var file in Directory.GetFiles("ChessTests"))
			{
				if (Path.GetExtension(file) != string.Empty) continue;
				using (var f = File.OpenText(file))
				{
				    Chess.Load_from(f);
				    Console.WriteLine("Loaded " + file);
				    var expectedAnswer = File.ReadAllText(file + ".ans").Trim();
                    Chess.solveTask();
                    Assert.AreEqual(expectedAnswer, Chess.Result, "error in file " + file);
				}
				testsCount++;
			}
			Console.WriteLine("Tests count: " + testsCount);
		}
	}
}