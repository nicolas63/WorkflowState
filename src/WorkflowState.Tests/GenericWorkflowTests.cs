using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowState.Core;
using WorkflowState.Core.Exceptions;
using WorkflowState.Tests.Enums;

namespace WorkflowState.Tests
{
    [TestClass]
    public class GenericWorkflowTests
    {
        [TestMethod]
        public void Should_ChangedState_When_WorkflowIsValid()
        {

            var workflow = new GenericWorkflow<EnumState, EnumTrigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged);
                conf.CreateTransition(EnumState.Intermediate, EnumState.End, EnumTrigger.StateChanged);
            });
            var state = workflow.GetNextState(EnumState.Start, EnumTrigger.StateChanged);
            state.Should().BeEquivalentTo(EnumState.Intermediate);
            var state2 = workflow.GetNextState(EnumState.Intermediate, EnumTrigger.StateChanged);
            state2.Should().BeEquivalentTo(EnumState.End);
        }

        [TestMethod]
        [ExpectedException(typeof(UnvalidTransitionException))]
        public void Should_ThrowException_When_TransitionDoNotExist()
        {

            var workflow = new GenericWorkflow<EnumState, EnumTrigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged);
            });
            var state = workflow.GetNextState(EnumState.End, EnumTrigger.StateChanged);
        }
    }
}
