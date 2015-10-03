using System;

namespace ReCrypto
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			String[] garbages = {
				"Where were you when the last bus to dehradun left",
				"In computer science, functional programming is a programming paradigm, a style of building the structure and elements of computer programs, that treats computation as the evaluation of mathematical functions and avoids changing-state and mutable data. It is a declarative programming paradigm, which means programming is done with expressions. In functional code, the output value of a function depends only on the arguments that are input to the function, so calling a function f twice with the same value for an argument x will produce the same result f(x) each time. Eliminating side effects, i.e. changes in state that do not depend on the function inputs, can make it much easier to understand and predict the behavior of a program, which is one of the key motivations for the development of functional programming.\n\nFunctional programming has its roots in lambda calculus, a formal system developed in the 1930s to investigate computability, the Entscheidungsproblem, function definition, function application, and recursion. Many functional programming languages can be viewed as elaborations on the lambda calculus. In the other well-known declarative programming paradigm, logic programming, relations are at the base of respective languages.\n\nIn contrast, imperative programming changes state with commands in the source language, the most simple example being assignment. Imperative programming does have functions, not in the mathematical sense, but in the sense of subroutines. They can have side effects that may change the value of program state. Functions without return values therefore make sense. Because of this, they lack referential transparency, i.e. the same language expression can result in different values at different times depending on the state of the executing program.\n\nFunctional programming languages, especially purely functional ones such as Hope and Rex, have largely been emphasized in academia rather than in commercial software development. However, prominent functional programming languages such as Common Lisp, Scheme, Clojure, Racket, Erlang, OCaml, Haskell, and F# have been used in industrial and commercial applications by a wide variety of organizations. Functional programming is also supported in some domain-specific programming languages like R (statistics), Wolfram Language (also known as M or Mathematica, for symbolic and numeric math), J, K and Q from Kx Systems (financial analysis), XQuery/XSLT (XML), and Opal. Widespread domain-specific declarative languages like SQL and Lex/Yacc use some elements of functional programming, especially in eschewing mutable values.\n\nProgramming in a functional style can also be accomplished in languages that aren’t specifically designed for functional programming. For example, the imperative Perl programming language has been the subject of a book describing how to apply functional programming concepts. This is also true of the PHP programming language. C# 3.0 and Java 8 added constructs to facilitate the functional style. An interesting case is that of Scala – it is frequently written in a functional style, but the presence of side effects and mutable state place it in a grey area between imperative and functional languages."
			};

			int steps = 2;
			if (steps > garbages.Length) {
				Console.WriteLine ("Number of steps cannot be more than the number of garbage text");
				return;
			}
			int[][] cryptoIndices = new int[steps][];
			Encrypt.Initialize ();

			String message = "rahul";
			for (int i = 0; i < steps; ++i) {
				int[] indices = new int[message.Length];
				if (!Encrypt.EncryptMessage (message, garbages [i], indices)) {
					Console.WriteLine ("Not Enough characters in the garbage text");
					return;
				}
				cryptoIndices [i] = indices;
				message = garbages [i];
			}

			for (int i = 0; i < cryptoIndices.Length; ++i) {
				Console.Write (">");
				for (int j = 0; j < cryptoIndices [i].Length; ++j) {
					Console.Write (cryptoIndices [i] [j] + "  ");
				}
				Console.WriteLine ();
			}
				
			for (int i = steps-1; i >= 0; --i) {
				message = Decrypt.DecryptMessage(message, cryptoIndices[i]);
			}
			Console.WriteLine ("\n\n\nThe original message is " + message);

		}

	}
}
