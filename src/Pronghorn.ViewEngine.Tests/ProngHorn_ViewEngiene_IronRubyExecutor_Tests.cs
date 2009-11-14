using NUnit.Framework;
using Pronghorn.ViewEngine;

namespace UnitTesting.Unit
{
	[TestFixture]
	public class ProngHorn_ViewEngiene_IronRubyExecutor_Tests
	{
		private string _templatePath = "Widgets/WalletFtu/Default";

		private const string RubyCode =
			@"self.output += ""		<div class=\""SureSidebarSectionTitle SureWalletLabel\"">\r\n""
self.output += ""			"" + localization.GetPhrase(""new users"",lang) + ""\r\n""
self.output += ""		</div>\r\n""
self.output += ""		<table class=\""SureSidebarSectionFrame\"" cellspacing=\""0\"" cellpadding=\""0\"">\r\n""
self.output += ""			<tr>\r\n""
self.output += ""				<td class=\""SureSidebarSectionInnerFrame\"" style=\""cursor:pointer\"" onclick=\""javascript:self.location='#{ftuUrl}'\"">\r\n""
self.output += ""					<p class=\""WalletFTUPromtionDisplay1\"">#{ftuValue} "" + localization.GetPhrase(""FREE"",lang) + ""*</p>\r\n""
self.output += ""					<p class=\""WalletFTUPromtionDisplay2\"">"" + localization.GetPhrase(""Viewing Credit"",lang) + ""</p>\r\n""
self.output += ""					<p class=\""WalletFTUPromtionDisplay3\"">*"" + localization.GetPhrase(""no purchase required"",lang) + ""</p>\r\n""
self.output += ""				</td>\r\n""
self.output += ""			</tr>\r\n""
self.output += ""			<tr>\r\n""
self.output += ""				<td class=\""SureSidebarSectionInnerFrame\"">\r\n""
self.output += ""					<a id=\""SureWalletBulletStartHere#{idModifier}\"" class=\""SureWalletBullet\"" href=\""javascript:WalletLink('#{ftuUrl}')\"">"" + localization.GetPhrase(""start here"",lang) + ""</a>\r\n""
self.output += ""				</td>\r\n""
self.output += ""			</tr>\r\n""
self.output += ""		</table>\r\n""
";

		private const string HtmlCode =
			@"		<div class=""SureSidebarSectionTitle SureWalletLabel"">
			new users
		</div>
		<table class=""SureSidebarSectionFrame"" cellspacing=""0"" cellpadding=""0"">
			<tr>
				<td class=""SureSidebarSectionInnerFrame"" style=""cursor:pointer"" onclick=""javascript:self.location='LaunchPage'"">
					<p class=""WalletFTUPromtionDisplay1"">100 USD FREE*</p>
					<p class=""WalletFTUPromtionDisplay2"">Viewing Credit</p>
					<p class=""WalletFTUPromtionDisplay3"">*no purchase required</p>
				</td>
			</tr>
			<tr>
				<td class=""SureSidebarSectionInnerFrame"">
					<a id=""SureWalletBulletStartHeremodifier"" class=""SureWalletBullet"" href=""javascript:WalletLink('LaunchPage')"">start here</a>
				</td>
			</tr>
		</table>
";

		[Test]
		public void When_passing_code_Should_Execute_It_and_return_text()
		{
			//var localizationService = IocContainer.GetClassInstance<ILocalizationService>();
			IViewExecutor ironRubyViewExecutor = new IronRubyViewExecutor();
			var parser = new IronRubyViewParser();
			var code = parser.Parse(_templatePath);
			var model = new {ftuValue = "100 USD",ftuUrl="LaunchPage",idModifier = "modifier"};
			//ironRubyViewExecutor.SetGlobalVariables("localization",localizationService);
			//ironRubyViewExecutor.SetGlobalVariables("lang",localizationService.GetLanguages().English);
			var html = ironRubyViewExecutor.Execute(RubyCode, model);
			Assert.That(html, Is.EqualTo(HtmlCode));
		}

	}
}