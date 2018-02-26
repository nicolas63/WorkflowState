﻿namespace WorkflowState.Core
{
    public class GenericTransition<TState, TTrigger>
    {
        internal TState FromState { get; }
        internal TState ToState { get; }
        internal TTrigger When { get; }
        internal bool IsFirstTransition { get; private set; }
        internal bool IsLastTransition { get; private set; }
        
        public GenericTransition(TState fromState, TState toState, TTrigger when)
        {
            FromState = fromState;
            ToState = toState;
            When = when;
        }

        public GenericTransition<TState, TTrigger> AsFirstTransition()
        {
            IsFirstTransition = true;
            return this;
        }


        public GenericTransition<TState, TTrigger> AsLastTransition()
        {
            IsLastTransition = true;
            return this;
        }
    }
}