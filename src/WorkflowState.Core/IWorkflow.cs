using System;

namespace WorkflowState.Core
{
    public interface IWorkflow<TState, TTrigger>
    {
        void Configure(Action<IWorkflowConfiguration<TState, TTrigger>> configuration);
        StateInformation<TState> GetNextState(TState currentState, TTrigger trigger);
    }
}