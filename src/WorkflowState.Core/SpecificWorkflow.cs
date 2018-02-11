﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkflowState.Core
{
    public class SpecificWorkflow<TState,TTrigger,TObjectToVerify> : GenericWorkflow<TState,TTrigger>
    {
       // internal new IList<SpecificTransition<TState, TTrigger,TObjectToVerify>> Transitions { get; private set; }
        
        public void Configure(Action<ISpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>> configuration)
        {
            var workflowConfiguration = new SpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>();
            configuration(workflowConfiguration);
            Transitions = workflowConfiguration.Transitions;
        }

        public TState GetNextState(TState currentState, TTrigger trigger, TObjectToVerify itemToVerify)
        {
            var transition = Transitions.FirstOrDefault(t => t.FromState.Equals(currentState) && t.When.Equals(trigger));
            var specifictransition = transition as SpecificTransition<TState, TTrigger, TObjectToVerify>;
            var isVerify = specifictransition?.Verify(itemToVerify);
            if (isVerify.HasValue)
            {
                return isVerify.Value ? transition.ToState : currentState;
            }

            return transition.ToState;
        }
    }
}