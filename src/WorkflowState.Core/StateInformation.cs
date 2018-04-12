namespace WorkflowState.Core
{
    public class StateInformation<TState>
    {
        public TState State { get; set; }

        public bool HasChangedState { get; set; }

    }
}
