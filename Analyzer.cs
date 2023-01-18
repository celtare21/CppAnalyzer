using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Analyzer;

public static class LexicalAnalyzer
{
    public static void Analyze()
    {
        {
            //Read C++ code from file
            string code = File.ReadAllText("code.cpp");

            // Create a SyntaxTree from the code
            var tree = CSharpSyntaxTree.ParseText(code);

            // Get the root node of the syntax tree
            var root = (CompilationUnitSyntax)tree.GetRoot();

            // Extract variable and function declarations
            var variableDeclarations = root.DescendantNodes().OfType<VariableDeclarationSyntax>();
            var functionDeclarations = root.DescendantNodes().OfType<MethodDeclarationSyntax>();

            // Extract all the tokens including signs like "+","-","=", etc
            var tokens = root.DescendantTokens();

            var signs = (from token in tokens
                where token.IsKind(SyntaxKind.PlusToken) || token.IsKind(SyntaxKind.MinusToken) || token.IsKind(SyntaxKind.EqualsToken) ||
                      token.IsKind(SyntaxKind.AsteriskToken) || token.IsKind(SyntaxKind.SlashToken) || token.IsKind(SyntaxKind.PercentToken) ||
                      token.IsKind(SyntaxKind.AmpersandToken) || token.IsKind(SyntaxKind.BarToken) || token.IsKind(SyntaxKind.CaretToken) ||
                      token.IsKind(SyntaxKind.TildeToken) || token.IsKind(SyntaxKind.ExclamationToken) || token.IsKind(SyntaxKind.LessThanToken) ||
                      token.IsKind(SyntaxKind.GreaterThanToken) || token.IsKind(SyntaxKind.AmpersandAmpersandToken) || token.IsKind(SyntaxKind.BarBarToken) ||
                      token.IsKind(SyntaxKind.QuestionToken) || token.IsKind(SyntaxKind.ColonToken) || token.IsKind(SyntaxKind.SemicolonToken) ||
                      token.IsKind(SyntaxKind.CommaToken) || token.IsKind(SyntaxKind.DotToken) || token.IsKind(SyntaxKind.DotDotToken) ||
                      token.IsKind(SyntaxKind.PlusPlusToken) || token.IsKind(SyntaxKind.MinusMinusToken) || token.IsKind(SyntaxKind.PercentEqualsToken) ||
                      token.IsKind(SyntaxKind.LessThanLessThanToken) || token.IsKind(SyntaxKind.GreaterThanGreaterThanToken) ||
                      token.IsKind(SyntaxKind.LessThanEqualsToken) || token.IsKind(SyntaxKind.GreaterThanEqualsToken) || token.IsKind(SyntaxKind.EqualsEqualsToken) ||
                      token.IsKind(SyntaxKind.ExclamationEqualsToken) || token.IsKind(SyntaxKind.AmpersandEqualsToken) || token.IsKind(SyntaxKind.BarEqualsToken) ||
                      token.IsKind(SyntaxKind.CaretEqualsToken) || token.IsKind(SyntaxKind.LessThanLessThanEqualsToken) ||
                      token.IsKind(SyntaxKind.GreaterThanGreaterThanEqualsToken) || token.IsKind(SyntaxKind.SlashEqualsToken) ||
                      token.IsKind(SyntaxKind.AsteriskEqualsToken) || token.IsKind(SyntaxKind.PlusEqualsToken) || token.IsKind(SyntaxKind.MinusEqualsToken)
                select token.ValueText).ToList();

            Console.WriteLine("Signs:");
            foreach (var sign in signs)
            {
                Console.Write($"{sign}   ");
            }

            // Output variable names, data types, and values
            Console.WriteLine("\n\nVariable Declarations:\n");
            foreach (var variableDeclaration in variableDeclarations)
            {
                var type = variableDeclaration.Type;
                var variables = variableDeclaration.Variables;
                foreach (var variable in variables)
                {
                    Console.WriteLine("Name: " + variable.Identifier.ValueText);
                    Console.WriteLine("Data Type: " + type);
                    if (variable.Initializer != null)
                        Console.WriteLine("Value: " + variable.Initializer.Value);
                }

                Console.WriteLine();
            }

            // Output function names, return data types, parameter names, and data types
            Console.WriteLine("\nFunction Declarations:\n");
            foreach (var functionDeclaration in functionDeclarations)
            {
                var returnType = functionDeclaration.ReturnType;
                var name = functionDeclaration.Identifier.ValueText;
                var parameters = functionDeclaration.ParameterList.Parameters;
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Return Type: " + returnType);
                foreach (var parameter in parameters)
                {
                    Console.WriteLine("Parameter Name: " + parameter.Identifier.ValueText);
                    Console.WriteLine("Data Type: " + parameter.Type);
                }

                Console.WriteLine();
            }
        }
    }
}