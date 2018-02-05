using System.Collections.Generic;

namespace WorkflowState.Core
{
    public class GenericWorkflowConfiguration<TState,TTrigger> : IWorkflowConfiguration<TState, TTrigger>
    {
        public IList<GenericTransition<TState,TTrigger>> Transitions { get; set; } = new List<GenericTransition<TState, TTrigger>>();

        public void CreateTransition(TState fromState , TState toState, TTrigger when)
        {
            Transitions.Add(new GenericTransition<TState,TTrigger>(fromState,toState,when));
        }

    }
}