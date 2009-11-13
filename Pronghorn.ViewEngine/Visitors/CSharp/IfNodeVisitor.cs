namespace Pronghorn.ViewEngine.Visitors.CSharp
{
	public class IfNodeVisitor : INodeVisitor
	{
		public int Order
		{
			get { return 3; }
		}
		private static string _ifStart = "<!--#{if";

		private static bool isIf(string line)
		{
			return line.Contains(_ifStart);
		}

		private bool isIfEnd(string line)
		{
			return line.Contains("<!--#{endif}-->");
		}

		private string parseEnd(string line)
		{
			if (!isIfEnd(line)) return line; 
			return "}\r\n";
		}

		private string parseStart(string line)
		{
			if (!isIf(line)) return line;
			var item = line.Replace(_ifStart, "").Replace("}-->", "").Trim();
			return string.Format("if (Model.Data.IsTrue(\"{0}\"))",item) + "{\r\n";
		}

		public void Visit(INodeParser nodeParser)
		{
			nodeParser.Line = parseStart(nodeParser.Line);
			nodeParser.Line = parseEnd(nodeParser.Line);
		}
	}
}