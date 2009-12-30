using System.IO;
using NUnit.Framework;
using Pronghorn.ViewEngine;

namespace UnitTesting.Unit
{
	[TestFixture]
	public class ProngHorn_ViewEngiene_IronRubyViewParser_Tests
	{
        private string _templatePath = "Widgets/WalletFtu/Default";
		
		const string RubyCode = @"self.output += ""		<div class=\""SureSidebarSectionTitle SureWalletLabel\"">\r\n""
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


		[TearDown]
		public void TearDown()
		{
			File.Delete(_templatePath + ".rhtml");
			File.Delete(_templatePath + "changed.rhtml");
			File.Delete(_templatePath + "changed.htm");
		}

		[Test]
		public void When_passing_a_template_location_Should_parse_it_and_save_it_to_disk()
		{
			IViewParser rubyViewParser =  new IronRubyViewParser();
			rubyViewParser.Parse(_templatePath);
			Assert.That(File.Exists(_templatePath + ".rhtml"));
		}

		[Test]
		public void When_passing_a_template_location_that_was_pre_compile_Should_not_parse_it_again()
		{
			IViewParser rubyViewParser = new IronRubyViewParser();
			rubyViewParser.Parse(_templatePath);

			var oldDate = File.GetLastWriteTimeUtc(_templatePath + ".rhtml");
			rubyViewParser.Parse(_templatePath);
			var newDate = File.GetLastWriteTimeUtc(_templatePath + ".rhtml");

			Assert.That(newDate, Is.EqualTo(oldDate));
		}
       
		public void When_the_template_is_newer_that_the_precompile_file_Should_precompile_it_again()
		{
			var lines = File.ReadAllLines(_templatePath + ".htm");
			using (var file = File.CreateText(_templatePath + "changed.htm"))
			{
				foreach (var line in lines)
				{
					file.WriteLine(line);
				}
				file.Close();
			}
			IViewParser rubyViewParser = new IronRubyViewParser();
			rubyViewParser.Parse(_templatePath + "changed");
			var oldDate = File.GetLastWriteTimeUtc(_templatePath + "changed.rhtml");

			lines = File.ReadAllLines(_templatePath + "changed.htm");
			using (var file = File.CreateText(_templatePath + "changed.htm"))
			{
				foreach (var line in lines)
				{
					file.WriteLine(line);
				}
				file.Close();
			}


			rubyViewParser.Parse(_templatePath + "changed");
			var newDate = File.GetLastWriteTimeUtc(_templatePath + "changed.rhtml");

			Assert.That(newDate, Is.GreaterThan(oldDate));
		}
        
		public void When_given_a_template_Should_return_valid_Ruby_Code()
		{
			IViewParser rubyViewParser = new IronRubyViewParser();
			var result = rubyViewParser.Parse(_templatePath);
			
			Assert.That(result,Is.EqualTo(RubyCode));
		}
        
    }
}