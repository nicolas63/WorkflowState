namespace WorkflowState.Core
{
    public interface IWorkflowConfiguration<TState, TTrigger>
    {
        GenericTransition<TState, TTrigger> CreateTransition(TState fromState, TState toState, TTrigger when);
    }
}