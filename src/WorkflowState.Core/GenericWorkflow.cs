using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowState.Core.Exceptions;

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
            if (transition == null)
            {
                throw new UnvalidTransitionException("This transition was unvalid verify your workflow configuration");
            }
            return transition.ToState;

        }
    }

}
