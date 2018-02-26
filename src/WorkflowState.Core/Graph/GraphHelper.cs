using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkflowState.Core.Graph
{
    public static class GraphHelper
    {
        public static string ExportWorkflow<TState, TTrigger>(GenericWorkflow<TState, TTrigger> workflow)
        {
            var stringBuilder = new StringBuilder();
            StartGraph(ref stringBuilder);
            foreach (var workflowTransition in workflow.Transitions)
            {
                FormatGenericTransition(ref stringBuilder, workflowTransition);
            }
            EndGraph(ref stringBuilder, workflow.Transitions);
            return stringBuilder.ToString();
        }

        public static string ExportWorkflow<TState, TTrigger, TObjectToVerify>(SpecificWorkflow<TState, TTrigger, TObjectToVerify> workflow)
        {
            var stringBuilder = new StringBuilder();
            StartGraph(ref stringBuilder);
            foreach (var workflowTransition in workflow.Transitions)
            {
                if (workflowTransition is SpecificTransition<TState, TTrigger, TObjectToVerify> specificTransition)
                {
                    stringBuilder.AppendLine(
                        $"{workflowTransition.FromState} -> {workflowTransition.ToState} [label=\"{workflowTransition.When} ({specificTransition.ExpressionToVerify})\"];");
                }
                else
                {
                    FormatGenericTransition(ref stringBuilder, workflowTransition);
                }
            }

            EndGraph(ref stringBuilder, workflow.Transitions);
            return stringBuilder.ToString();
        }

        private static void FormatGenericTransition<TState, TTrigger>(ref StringBuilder stringBuilder, GenericTransition<TState, TTrigger> transition)
        {
            stringBuilder.AppendLine($"{transition.FromState} -> {transition.ToState} [label=\"{transition.When}\"];");
        }

        private static void StartGraph(ref StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("digraph G {");
        }


        private static void EndGraph<TState, TTrigger>(ref StringBuilder stringBuilder,IList<GenericTransition<TState, TTrigger>> transitions)
        {
            var firstTransition = transitions.FirstOrDefault(transiton => transiton.IsFirstTransition);
            if (firstTransition != null)
            {
                stringBuilder.AppendLine($"{firstTransition.FromState} [shape=Msquare]");
            }
            var lastTransition = transitions.FirstOrDefault(transiton => transiton.IsLastTransition);
            if (lastTransition != null)
            {
                stringBuilder.AppendLine($"{lastTransition.ToState} [shape=Msquare]");
            }
            stringBuilder.AppendLine("}");
        }
    }
}
