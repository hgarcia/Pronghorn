using System.Text;

namespace Pronghorn.ViewEngine.Visitors.CSharp
{
	public class MetaNodeVisitor : INodeVisitor
	{
		public int Order
		{
			get { return 3; }
		}
		private static bool isMeta(string line)
		{
			return line.Contains("<!--#{metatags}-->");
		}

		private static string parse(string line)
		{
			if (!isMeta(line)) return line;
			var sb = new StringBuilder();
			sb.AppendLine("RenderCollection((IList<IRenderable>)Model.MetaTags, writer);");
			return sb.ToString();
		}

		public void Visit(INodeParser nodeParser)
		{
			nodeParser.Line = parse(nodeParser.Line);
		}
	}
}