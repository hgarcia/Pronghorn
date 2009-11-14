using System.Text;
using System.Text.RegularExpressions;

namespace Pronghorn.ViewEngine.Visitors.CSharp
{
	public class TextNodeVisitor : INodeVisitor
	{
		public int Order
		{
			get { return 3; }
		}
		private const string RegexPattern = "#{.*?}";

		private static MatchCollection getMatchCollection(string line)
		{
			return Regex.Matches(line, RegexPattern, RegexOptions.None);
		}

		private static bool isArea(string line)
		{
			return line.Contains("#{area");
		}

		private static bool isStatement(string line)
		{
			return line.Contains("<!--#{");
		}

		private static bool isTitle(string line)
		{
			return line.Contains("#{title}");
		}

		private static string parse(string line)
		{
			if (isStatement(line)) return line;
			if (isArea(line)) return line;
			if (isTitle(line)) return parseTitle(line);
			var matches = getMatchCollection(line);
			if (matches.Count == 0) return parseString(line);
			return parseMatches(line, matches);
		}

		private static string parseMatches(string line, MatchCollection matches)
		{
			var sbLine = new StringBuilder(line);
			var sbVars = new StringBuilder();
			var i = 0;
			foreach (var match in matches)
			{
				if (sbLine.ToString().Contains(match.ToString()))
				{
					parseObjectWithProperty(i,sbLine,match, sbVars);
					parseObjectWithoutProperty(i,sbLine, match, sbVars);
					i++;
				}
			}

			return string.Format("writer.Write( string.Format(\"{0}\"{1}) );\r\n", sbLine.Replace("\"","\\\""), sbVars);
		}

		private static void parseObjectWithProperty(int varPosition, StringBuilder sbLine, object match, StringBuilder sbVars)
		{
			if (match.ToString().Contains("."))
			{
				sbLine.Replace(match.ToString(), "{" + varPosition + "}");
				var symbolName = match.ToString().Split('.')[0].Replace("#{","");
				//WARNING: Ugly line ahead
				sbVars.Append("," + match.ToString().Replace("#{", "Model.Data.GetString(" + symbolName +",\"").Replace("}", "\")"));
			}
		}

		private static void parseObjectWithoutProperty(int varPosition, StringBuilder sbLine, object match, StringBuilder sbVars)
		{
			if(match.ToString().Contains(".")) return;
			sbLine.Replace(match.ToString(), "{" + varPosition + "}");
			sbVars.Append("," + match.ToString().Replace("#{", "Model.Data.GetString(\"").Replace("}", "\")"));
		}

		private static string parseString(string line)
		{
			return string.Format("writer.Write(\"{0}\");\r\n", line.Replace("\"", "\\\""));
		}

		private static string parseTitle(string line)
		{
			return string.Format("writer.Write( string.Format(\"{0}\",Model.PageTitle) );\r\n", line.Replace("#{title}","{0}"));
		}

		public void Visit(INodeParser nodeParser)
		{
			nodeParser.Line = parse(nodeParser.Line);
		}
	}
}