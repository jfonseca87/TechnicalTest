using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace TTApp
{
	public class Program
	{
		/*
			There is a string "sdfgabcwetrrytruyrtuabcpotre!@#abcprtort" - see above.
			The task is to implement the following method:

			public Dictionary<string,string> processString(String inputStr, String separator);

			The result need to contain the following keys:
			Count : count all substrings (itemstrings)  infront of which there is a separator string (if xxx is the string and A is the separator here: xxxAxxxAxxxAxxx, you need to return 3);
			prefix : if any string exists before the first separator, please provide the text
			sortedItems : a string with all itemstrings concatenated in alphabetical order
			evenChars : a string with concatenated all even indexed chars (2,4,6,8,10th)

			notes: 
				1. if there is no separator found in input string then the whole inputString is counted as 1 itemString 
				2. zero length strings should not be includded in count
				3. prefix should not be includded in itemstrings 
				4. prefix schould not be includded in count
				5. itemstrings schould be displayed with space (" ") between each of them in the output

			implement all results display inside Main method in following format:
			Count: some number
			Prefix: some string
			sortedItems: some string
			evenChars: some string

			Example output when executed with inputString = "abcdefSEPgabcwetSEPsdsSEPdsfgSEPfro",separator = "SEP"));

			Count: 4
			Prefix: abcdef
			sortedItems: dsfg fro gabcwet sds
			evenChars: aceSPaceSPdSPsgEfo

			*/

		public static void Main()
		{
			string inputString = "sdfgabcwetrrytruyrtuabcpotre!@#abcprtort";
			var resultList = new List<Dictionary<string, string>>();
			resultList.Add(processString(inputString, "abc"));
			resultList.Add(processString(inputString, "s"));
			resultList.Add(processString(inputString, "r"));
			resultList.Add(processString(inputString, "zi"));
			resultList.Add(processString("abcdefSEPgabcwetSEPsdsSEPdsfgSEPfro", "SEP"));
			/*
			implement all results display here 
			*/
			Console.WriteLine("===========================================================");
			Console.WriteLine("=========================Results===========================");
			foreach (var result in resultList)
			{
				Console.WriteLine(string.Empty);
				foreach (KeyValuePair<string, string> record in result)
				{
					Console.WriteLine($"{record.Key}:{record.Value}");
				}
				Console.WriteLine(string.Empty);
			}
			Console.WriteLine("===========================End=============================");
			Console.WriteLine("===========================================================");
			Console.ReadKey();
		}

		public static Dictionary<string, string> processString(String inputStr, String separator)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			List<string> stringParts = Regex.Split(inputStr, separator).ToList();
			int firstItemStringIndex = inputStr.IndexOf(separator);
			string firstItemString = firstItemStringIndex > 0 ? stringParts[0] : string.Empty;
			if (firstItemStringIndex > 0)
			{
				stringParts.RemoveAt(0);
			}

			// Get even char from string
			var asd = inputStr.Select((x, i) =>
			{
				if (i % 2 == 0) return x.ToString();
				return string.Empty;
			}).Where(x => !string.IsNullOrEmpty(x)).ToList();

			result.Add("count", (stringParts.Count).ToString());
			result.Add("prefix", firstItemString);
			result.Add("sortedItems", string.Join(' ', stringParts.OrderBy(x => x)));
			result.Add("evenChars", string.Join(string.Empty, asd));

			return result;
		}
	}
}






