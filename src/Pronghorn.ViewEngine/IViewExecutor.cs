namespace Pronghorn.ViewEngine
{
	public interface IViewExecutor
	{
		/// <summary>
		/// This method runs the code and returns a string with the result
		/// </summary>
		/// <param name="code">The code to run</param>
		/// <param name="model">An object containing the data for the template</param>
		/// <returns>An string with the result (similar to do a Console.Write or print on the script).</returns>
		string Execute(string code, object model);

		void SetGlobalVariables(string variableName, object value);
	}
}