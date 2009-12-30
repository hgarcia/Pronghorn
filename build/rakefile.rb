require 'fileutils' 

DOT_NET_PATH = "C:/Windows/Microsoft.NET/Framework/v3.5/"
NUNIT_PATH = "../libs/NUnit/nunit-console.exe"
SOLUTION = "../src/Pronghorn.sln"
PROJECTS = ["Core","Migrations","ViewEngine","Web","Widgets"]
MIGRATION_PROJECT = "Migrations"
TEST_PROJECTS = ["ViewEngine.Tests","Core.Tests"]
CONFIG = "Release"
PACKAGE_PATH = "Package"
MIGRATOR_PATH = "../libs/Migrator.Net/Migrator.Console.exe "
MIGRATOR_DB = "SqlServer \"Data Source=.\\SQLEXPRESS;AttachDbFilename=..\\src\\Pronghorn.Web\\App_Data\\PRONGHORN.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True\""

desc "Clear build folder"
task :clear => [:prepare] do
    if File.exists?(PACKAGE_PATH)
      FileUtils.rm_r PACKAGE_PATH
    end
end

desc "Create folders"
task :prepare => [:compile] do
    if not File.exists?(PACKAGE_PATH)
      Dir.mkdir(PACKAGE_PATH)
    end

    for project in PROJECTS | TEST_PROJECTS
      Dir.mkdir("#{PACKAGE_PATH}/#{project}")
    end
end

desc "Build solution"
task :compile => [:move] do
  sh "#{DOT_NET_PATH}msbuild.exe /p:Configuration=#{CONFIG} #{SOLUTION} /t:rebuild"
end

desc "Move dll's to package"
task :move => [:test]  do
  for project in PROJECTS | TEST_PROJECTS
     files = Dir.glob("../src/Pronghorn.#{project}/bin/#{CONFIG}")
        files.each do |item|
        cp_r item, "#{PACKAGE_PATH}/#{project}"
        end
  end
end

desc "Run the tests"
task :test do
  xml_file = File.join(PACKAGE_PATH, "nunit-test-report.xml")
   
  for test in TEST_PROJECTS
    testsToRun = "#{testsToRun} #{PACKAGE_PATH}/#{test}/#{CONFIG}/Pronghorn.#{test}.dll "
  end  
  sh "#{NUNIT_PATH} #{testsToRun} /nologo /xml=#{xml_file}"
end

desc "Create the db objects"
task :migrate => [:test] do
  sh "#{MIGRATOR_PATH} #{MIGRATOR_DB} #{PACKAGE_PATH}/#{MIGRATION_PROJECT}/#{CONFIG}/Pronghorn.#{MIGRATION_PROJECT}.dll"
end

desc "Complete build"
task :complete => [:migrate] do
  puts "Starting complete build"
end

desc "Compilation and test without db migratiion"
task :codeOnly => [:clear] do
  puts "Compile code and run tests."
end

