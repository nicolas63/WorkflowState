using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public interface ISpecificWorkflowConfiguration<TState,TTrigger,TWorkflowItem> : IWorkflowConfiguration<TState, TTrigger>
    {
           SpecificTransition<TState, TTrigger, TWorkflowItem> CreateTransition(TState fromState, TState toState, TTrigger when, Expression<Func<TWorkflowItem, bool>> verify);
    }
}
