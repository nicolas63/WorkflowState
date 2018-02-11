using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public class SpecificWorkflowConfiguration<TState,TTrigger,TWorkflowItem> : GenericWorkflowConfiguration<TState,TTrigger> , ISpecificWorkflowConfiguration<TState, TTrigger, TWorkflowItem>
    {
        //internal new IList<SpecificTransition<TState, TTrigger, TWorkflowItem>> Transitions { get; } = new List<SpecificTransition<TState, TTrigger, TWorkflowItem>>();

        public SpecificTransition<TState, TTrigger, TWorkflowItem> CreateTransition(TState fromState, TState toState, TTrigger when, Expression<Func<TWorkflowItem, bool>> verify)
        {
            var transition = new SpecificTransition<TState, TTrigger, TWorkflowItem>(fromState, toState, when, verify);
            Transitions.Add(transition);
            return transition;
        }

    }
}