﻿
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace FindInterfaces.Classes;
internal class Helpers
{
    public static async Task<List<string?>> FindInterfacesInSolution()
    {
        List<string?> list = new();

        var folder = DirectoryOperations.GetSolutionInfo().FullName;

        var files = await Task.Run(() => GetFiles(folder));
        foreach (var file in files)
        {
            var fileContents = await File.ReadAllTextAsync(file);
            var syntaxTree = CSharpSyntaxTree.ParseText(fileContents);
            SyntaxNode root = await syntaxTree.GetRootAsync();

            IEnumerable<InterfaceDeclarationSyntax> interfaceNodes = 
                root.DescendantNodes().OfType<InterfaceDeclarationSyntax>();

            foreach (var interfaceNode in interfaceNodes)
            {
                list.Add(file.Replace(folder + "\\", ""));
                foreach (MemberDeclarationSyntax member in interfaceNode.Members)
                {
                    if (member is not PropertyDeclarationSyntax property) continue;
                    var propertyName = property.Identifier.Text;
                    var propertyType = property.Type.ToString();
                }
            }
        }

        return list;
    }

    public static string[] GetFiles(string folder) 
        => Directory.GetFiles(folder, "*.cs", SearchOption.AllDirectories);
}


