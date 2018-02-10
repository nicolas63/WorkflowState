using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowState.Core
{
    public class SpecificWorkflow<TState,TTrigger,TObjectToVerify> : GenericWorkflow<TState,TTrigger>
    {
        private IList<SpecificTransition<TState, TTrigger,TObjectToVerify>> Transitions { get; set; }
        
        public void Configure(Action<ISpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>> configuration)
        {
            var workflowConfiguration = new SpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>();
            configuration(workflowConfiguration);
            Transitions = workflowConfiguration.Transitions;
        }

        public TState GetNextState(TState currentState, TTrigger trigger, TObjectToVerify itemToVerify)
        {
            var state = Transitions.FirstOrDefault(t => t.FromState.Equals(currentState) && t.When.Equals(trigger));
            var isVerify = state.Verify(itemToVerify);
            return isVerify ? state.ToState : currentState;
        }
    }
}