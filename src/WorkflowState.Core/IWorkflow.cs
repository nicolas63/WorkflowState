using System;

namespace WorkflowState.Core
{
    public interface IWorkflow<TState, TTrigger>
    {
        void Configure(Action<IWorkflowConfiguration<TState, TTrigger>> configuration);
        TState GetNextState(TState currentState, TTrigger trigger);
    }
}