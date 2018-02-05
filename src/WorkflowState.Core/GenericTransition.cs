namespace WorkflowState.Core
{
    public class GenericTransition<TState,TTrigger>
    {
        public TState FromState { get; set; }
        public TState ToState { get; set; }
        public TTrigger When { get; set; }

        public GenericTransition(TState fromState, TState toState, TTrigger when)
        {
            FromState = fromState;
            ToState = toState;
            When = when;
        }
    }
}