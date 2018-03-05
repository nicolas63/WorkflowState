using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowState.Core;
using WorkflowState.Tests.Enums;

namespace WorkflowState.Tests
{
    [TestClass]
    public class GenericWorkflowTests
    {
        private static int count; 

        [TestMethod]
        public void Should_ChangedState_When_TransitionIsValid()
        {

            var workflow = new GenericWorkflow<EnumState, EnumTrigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged);
                conf.CreateTransition(EnumState.Intermediate, EnumState.End, EnumTrigger.StateChanged);
            });
            var stateInformation = workflow.GetNextState(EnumState.Start, EnumTrigger.StateChanged);
            stateInformation.State.Should().BeEquivalentTo(EnumState.Intermediate);
            stateInformation.HasChangedState.Should().BeTrue();
            var stateInformation2 = workflow.GetNextState(EnumState.Intermediate, EnumTrigger.StateChanged);
            stateInformation2.State.Should().BeEquivalentTo(EnumState.End);
            stateInformation2.HasChangedState.Should().BeTrue();
        }

        [TestMethod]
        public void Should_ReturnCurrent_When_TransitionDoNotExist()
        {
            var workflow = new GenericWorkflow<EnumState, EnumTrigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged);
            });
            var stateInformation = workflow.GetNextState(EnumState.End, EnumTrigger.StateChanged);

            stateInformation.State.Should().BeEquivalentTo(EnumState.End);
            stateInformation.HasChangedState.Should().BeFalse();
        }


        [TestMethod]
        public void Should_CallOnSucces_WhenChangedState()
        {
            var workflow = new GenericWorkflow<EnumState, EnumTrigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged, () => count++);
            });

            workflow.GetNextState(EnumState.Start, EnumTrigger.StateChanged);

            count.Should().Be(1);
        }
    }
}
