using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class ProhibitedTypeAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "ProhibitedMethod";
    private static readonly string Title = "Prohibited method usage";
    private const string Category = "Usage";

    private const string ProhibitedActivatorMessage = "Direct calls to {0} are prohibited. Please use TypeValidation.SafeActivator";

    private static Dictionary<string, DiagnosticDescriptor> rules = new Dictionary<string, DiagnosticDescriptor>
    {
        { "System.Activator.CreateInstance", CreateError(ProhibitedActivatorMessage) },
    };

    private static DiagnosticDescriptor CreateError(string description)
    {
        return new DiagnosticDescriptor(DiagnosticId, Title, description, Category, DiagnosticSeverity.Error, isEnabledByDefault: true);
    }

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.CreateRange(rules.Values);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.InvocationExpression);
    }

    private void AnalyzeNode(SyntaxNodeAnalysisContext context)
    {
        var invocationExpr = (InvocationExpressionSyntax)context.Node;

        var symbol = context.SemanticModel.GetSymbolInfo(invocationExpr).Symbol as IMethodSymbol;
        if (symbol == null)
            return;

        if (rules.TryGetValue($"{symbol.ContainingType}.{symbol.Name}", out var rule))
        {
            context.ReportDiagnostic(Diagnostic.Create(rule, invocationExpr.GetLocation(), $"{symbol.ContainingType}.{symbol.Name}"));
        }
    }
}
