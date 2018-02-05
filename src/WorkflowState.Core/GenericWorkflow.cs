using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowState.Core
{
    public class GenericWorkflow<TState,TTrigger>
    {
        private IList<GenericTransition<TState, TTrigger>> Transitions { get; set; }
        
        public void Configure(Action<IWorkflowConfiguration<TState,TTrigger>> configuration)
        {
            var workflowConfiguration = new GenericWorkflowConfiguration<TState,TTrigger>();
            configuration(workflowConfiguration);
            Transitions = workflowConfiguration.Transitions;
        }

        public virtual TState GetNextState(TState currentState, TTrigger trigger)
        {
            var state = Transitions.FirstOrDefault(t => t.FromState.Equals(currentState) && t.When.Equals(trigger));
            return state.ToState;
        }
    }

}
