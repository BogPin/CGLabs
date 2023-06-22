public static class CommandLineParser
{
  public static Dictionary<string, string> ParseOptions(string[] arguments)
  {
    var results = new Dictionary<string, string>();
    var lastArg = "";

    foreach (var argument in arguments)
    {
      if (string.IsNullOrWhiteSpace(argument))
        continue;

      if (argument.StartsWith("--", StringComparison.Ordinal))
        lastArg = argument.Substring(2);
      else if (argument.StartsWith("-", StringComparison.Ordinal))
        lastArg = argument.Substring(1);
      else
      {
        results.Add(lastArg, argument);
        lastArg = "";
      }
    }

    return results;
  }
}
