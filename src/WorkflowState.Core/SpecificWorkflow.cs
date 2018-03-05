using System;
using System.Linq;

namespace WorkflowState.Core
{
    public class SpecificWorkflow<TState,TTrigger,TObjectToVerify> : GenericWorkflow<TState,TTrigger>
    {        
        public void Configure(Action<ISpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>> configuration)
        {
            var workflowConfiguration = new SpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>();
            configuration(workflowConfiguration);
            Transitions = workflowConfiguration.Transitions;
        }

        public StateInformation<TState> GetNextState(TState currentState, TTrigger trigger, TObjectToVerify itemToVerify)
        {
            var transitions = Transitions.Where(t => t.FromState.Equals(currentState) && t.When.Equals(trigger));
            var validSpecificTransition = transitions.OfType<SpecificTransition<TState, TTrigger, TObjectToVerify>>()
                .FirstOrDefault(t => t.Verify(itemToVerify));
            if (validSpecificTransition == null)
            {
                return GetNextState(currentState, trigger);
            }

            validSpecificTransition.OnSuccess(itemToVerify);
            return new StateInformation<TState> {State = validSpecificTransition.ToState, HasChangedState = true};
        }
    }
}