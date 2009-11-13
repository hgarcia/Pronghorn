using System.Text;

namespace Pronghorn.ViewEngine.Visitors.CSharp
{
	public class ForEachNodeVisitor : INodeVisitor
	{
		public int Order
		{
			get { return 3; }
		}
		private const string _startForEach = "<!--#{foreach";

		private static string _endforeach = "<!--#{endforeach}-->";

		private static bool isForEach(string line)
		{
			return line.Contains(_startForEach);
		}

		private static bool isForEachEnd(string line)
		{
			return line.Contains(_endforeach);
		}

		private static string parseEnd(string line)
		{
			if (!isForEachEnd(line)) return line;
			return "}\r\n }\r\n";
		}

		private static string parseStart(string line)
		{
			if (!isForEach(line)) return line;

			const string end = "}-->";
			var feArray = line.Replace(_startForEach, "").Replace(end, "").Trim().Split(' ');

			var builder = new StringBuilder();
			builder.AppendLine(string.Format("var {0} = Model.Data.GetIEnumerable(\"{0}\");", feArray[2]));
			builder.AppendFormat(" if ({0} != null)",feArray[2]);
			builder.AppendLine("{");
			builder.AppendFormat(" foreach(var {0} {1} {2})",feArray[0],feArray[1], feArray[2]);
			builder.AppendLine("{");

			return builder.ToString();
		}

		public void Visit(INodeParser nodeParser)
		{
			nodeParser.Line = parseStart(nodeParser.Line);
			nodeParser.Line = parseEnd(nodeParser.Line);
		}
	}
}