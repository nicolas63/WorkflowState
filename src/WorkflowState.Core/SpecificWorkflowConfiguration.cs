using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public class SpecificWorkflowConfiguration<TState,TTrigger, TObjectToVerify> : GenericWorkflowConfiguration<TState,TTrigger> , ISpecificWorkflowConfiguration<TState, TTrigger, TObjectToVerify>
    {
        public SpecificTransition<TState, TTrigger, TObjectToVerify> CreateTransition(TState fromState, TState toState, TTrigger when, Expression<Func<TObjectToVerify, bool>> verify, Action<TObjectToVerify> onSuccess)
        {
            var transition = new SpecificTransition<TState, TTrigger, TObjectToVerify>(fromState, toState, when, verify,onSuccess);
            Transitions.Add(transition);
            return transition;
        }

    }
}