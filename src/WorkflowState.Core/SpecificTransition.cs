using System;

namespace WorkflowState.Core
{
    public class SpecificTransition<TState,TTrigger,TWorkflowItem> : GenericTransition<TState,TTrigger>
    {

        public Func<TWorkflowItem,bool> Verify { get; set; }

        public SpecificTransition(TState fromState, TState toState, TTrigger when, Func<TWorkflowItem, bool> verify) : base(fromState, toState, when)
        {
            Verify = verify;
        }
    }
}