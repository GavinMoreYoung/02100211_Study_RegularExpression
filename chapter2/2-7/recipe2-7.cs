using System;
using System.IO;
using System.Text.RegularExpressions;

public class Recipe
{
	private static Regex _Regex = new Regex(@"^(?<drive>[a-z]):\\?", RegexOptions.IgnoreCase);
	
	public void Run(string fileName)
	{
		String line;
		using (StreamReader sr = new StreamReader(fileName))
		{
			while(null != (line = sr.ReadLine()))
			{
				if (_Regex.IsMatch(line))
				{
					Console.WriteLine("Found drive:  '{0}'", _Regex.Match(line).Result("${drive}"));
				}
			}
		}
	}	

	public static void Main( string[] args )
	{
		Recipe r = new Recipe();
		r.Run(args[0]);
	}
}

