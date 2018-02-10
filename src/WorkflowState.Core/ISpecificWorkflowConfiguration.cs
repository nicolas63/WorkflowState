using System;
using System.Collections.Generic;

namespace WorkflowState.Core
{
    public interface ISpecificWorkflowConfiguration<TState,TTrigger,TWorkflowItem> : IWorkflowConfiguration<TState, TTrigger>
    {
        new IList<SpecificTransition<TState, TTrigger, TWorkflowItem>> Transitions { get; set; }

        void CreateTransition(TState fromState, TState toState, TTrigger when, Func<TWorkflowItem, bool> verify);
    }
}
