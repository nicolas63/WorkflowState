using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public class GenericTransition<TState, TTrigger>
    {
        internal TState FromState { get; }
        internal TState ToState { get; }
        internal TTrigger When { get; }
        internal bool IsFirstTransition { get; private set; }
        internal bool IsLastTransition { get; private set; }
        internal Action OnSuccess { get; }

        public GenericTransition(TState fromState, TState toState, TTrigger when,Action onSuccess =null )
        {
            FromState = fromState;
            ToState = toState;
            When = when;
            OnSuccess = onSuccess;
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