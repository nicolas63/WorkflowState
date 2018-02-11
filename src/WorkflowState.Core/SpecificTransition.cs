using System;
using System.Linq.Expressions;

namespace WorkflowState.Core
{
    public class SpecificTransition<TState,TTrigger,TWorkflowItem> : GenericTransition<TState,TTrigger>
    {
        internal Expression<Func<TWorkflowItem, bool>> ExpressionToVerify { get; }

        internal Func<TWorkflowItem, bool> Verify => ExpressionToVerify.Compile();

        public SpecificTransition(TState fromState, TState toState, TTrigger when, Expression<Func<TWorkflowItem, bool>> verify) : base(fromState, toState, when)
        {
            ExpressionToVerify = verify;
        }
    }
}