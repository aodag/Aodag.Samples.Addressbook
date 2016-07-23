var target = Argument("target", "Default");

Task("Restore")
  .Does(() =>
{
  DotNetCoreRestore("src/Aodag.Samples.Addressbook");
  DotNetCoreRestore("tests/Aodag.Samples.Addressbook.Test");
});

Task("Build")
  .IsDependentOn("Restore")
  .Does(() =>
{
  DotNetCoreBuild("src/Aodag.Samples.Addressbook");
  DotNetCoreBuild("tests/Aodag.Samples.Addressbook.Test");
});

Task("Test")
  .IsDependentOn("Build")
  .Does(() =>
{
  DotNetCoreTest("tests/Aodag.Samples.Addressbook.Test");
});

Task("Default")
  .IsDependentOn("Build");

RunTarget(target);