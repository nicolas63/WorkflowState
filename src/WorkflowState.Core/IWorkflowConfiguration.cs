using System.Collections.Generic;

namespace WorkflowState.Core
{
    public interface IWorkflowConfiguration<TState, TTrigger>
    {
        IList<GenericTransition<TState, TTrigger>> Transitions { get; set; }

        void CreateTransition(TState fromState, TState toState, TTrigger when);
    }
}