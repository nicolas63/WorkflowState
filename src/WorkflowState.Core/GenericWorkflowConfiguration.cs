using System.Collections.Generic;

namespace WorkflowState.Core
{
    public class GenericWorkflowConfiguration<TState,TTrigger> : IWorkflowConfiguration<TState, TTrigger>
    {
        internal IList<GenericTransition<TState,TTrigger>> Transitions { get; } = new List<GenericTransition<TState, TTrigger>>();

        public GenericTransition<TState, TTrigger> CreateTransition(TState fromState , TState toState, TTrigger when)
        {
            var transition = new GenericTransition<TState, TTrigger>(fromState, toState, when);
            Transitions.Add(transition);
            return transition;
        }

    }
}