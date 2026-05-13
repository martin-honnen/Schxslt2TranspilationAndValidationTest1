
using PhoenixmlDb.Xslt;

var transpileLocation = @"C:\Users\marti\OneDrive\Documents\schematron\schxslt2-1.10.3\transpile-indent-report.xsl"; // @"C:\Users\marti\source\repos\PhoenixmlWorkbench\PhoenixmlWorkbench\wwwroot\examples\xslt\schematron\schxslt2\transpile.xsl";

var schematronFile = args[0];

var instanceFile = args[1];

//Console.WriteLine(schematronFile);

//Console.WriteLine(instanceFile);

var transformer = new XsltTransformer();
//transformer.PreloadedResources
await transformer.LoadStylesheetAsync(await File.ReadAllTextAsync(transpileLocation), new Uri(transpileLocation));

transformer.SetSourceDocumentUri(new Uri(schematronFile));

var transpiledSchematron = await transformer.TransformAsync(await File.ReadAllTextAsync(schematronFile));


transformer = new XsltTransformer();
//transformer.PreloadedResources
await transformer.LoadStylesheetAsync(transpiledSchematron, new Uri(transpileLocation));

transformer.SetSourceDocumentUri(new Uri(instanceFile));

var svrlReport = await transformer.TransformAsync(await File.ReadAllTextAsync(instanceFile));

Console.WriteLine(svrlReport);