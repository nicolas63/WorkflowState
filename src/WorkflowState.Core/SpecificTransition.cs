using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public class SpecificTransition<TState,TTrigger, TObjectToVerify> : GenericTransition<TState,TTrigger>
    {
        internal Expression<Func<TObjectToVerify, bool>> ExpressionToVerify { get; }
        public new Action<TObjectToVerify> OnSuccess { get; }

        internal Func<TObjectToVerify, bool> Verify => ExpressionToVerify.Compile();

        public SpecificTransition(TState fromState, TState toState, TTrigger when, Expression<Func<TObjectToVerify, bool>> verify, Action<TObjectToVerify> onSuccess = null)
            : base(fromState, toState, when)
        {
            ExpressionToVerify = verify;
            OnSuccess = onSuccess;
        }
    }
}