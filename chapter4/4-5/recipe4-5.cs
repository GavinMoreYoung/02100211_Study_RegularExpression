using System;
using System.IO;
using System.Text.RegularExpressions;

public class Recipe
{
	private static Regex _Regex = new Regex( @"^-(\d{1,3}(,\d{3})*(\.\d+)?)$" );
	public void Run(string fileName)
	{
		String line;
		String newLine;
		using (StreamReader sr = new StreamReader(fileName))
		{
			while(null != (line = sr.ReadLine()))
			{
				newLine = _Regex.Replace(line, @"($1)");
				Console.WriteLine("New string is: '{0}', original was: '{1}'",
					newLine,
					line);
			}
		}
	}
	
	public static void Main( string[] args )
	{
		Recipe r = new Recipe();
		r.Run(args[0]);
	}
}

