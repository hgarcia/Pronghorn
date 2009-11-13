using System.IO;

namespace Pronghorn.ViewEngine
{
	public interface INodeParser
	{
		string Line
		{
			get; set;
		}

		void Parse(TextWriter writer);
	}
}