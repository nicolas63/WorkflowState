using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public interface ISpecificWorkflowConfiguration<TState,TTrigger,TObjectToVerify> : IWorkflowConfiguration<TState, TTrigger>
    {
        SpecificTransition<TState, TTrigger, TObjectToVerify> CreateTransition(TState fromState, TState toState,
            TTrigger when, Expression<Func<TObjectToVerify, bool>> verify, Action<TObjectToVerify> onSuccess = null);
    }
}
