using System;
using System.Collections.Generic;

namespace WorkflowState.Core
{
    public class SpecificWorkflowConfiguration<TState,TTrigger,TWorkflowItem> : GenericWorkflowConfiguration<TState,TTrigger> , ISpecificWorkflowConfiguration<TState, TTrigger, TWorkflowItem>
    {
        public new IList<SpecificTransition<TState, TTrigger, TWorkflowItem>> Transitions { get; set; } = new List<SpecificTransition<TState, TTrigger, TWorkflowItem>>();

        public void CreateTransition(TState fromState, TState toState, TTrigger when, Func<TWorkflowItem, bool> verify)
        {
            Transitions.Add(new SpecificTransition<TState, TTrigger, TWorkflowItem>(fromState, toState, when, verify));
        }
    }
}