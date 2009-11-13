namespace Pronghorn.ViewEngine.Visitors
{
	public interface INodeVisitor
	{
		void Visit(INodeParser nodeParser);
		int Order { get; }
	}
}