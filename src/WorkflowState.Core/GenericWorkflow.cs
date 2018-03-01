using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowState.Core
{
    public class GenericWorkflow<TState, TTrigger> : IWorkflow<TState, TTrigger>
    {
        internal IList<GenericTransition<TState, TTrigger>> Transitions { get; set; }

        public void Configure(Action<IWorkflowConfiguration<TState, TTrigger>> configuration)
        {
            var workflowConfiguration = new GenericWorkflowConfiguration<TState, TTrigger>();
            configuration(workflowConfiguration);
            Transitions = workflowConfiguration.Transitions;
        }

        public TState GetNextState(TState currentState, TTrigger trigger)
        {
            var transition = Transitions.FirstOrDefault(t => t.FromState.Equals(currentState) && t.When.Equals(trigger));
            return transition == null ? currentState : transition.ToState;
        }
    }

}
