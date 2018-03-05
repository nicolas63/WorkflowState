using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowState.Core;
using WorkflowState.Tests.Enums;
using WorkflowState.Tests.ObjectToVerify;

namespace WorkflowState.Tests
{
    [TestClass]
    public class SpecificWorkflowTests
    {
        [TestMethod]
        public void Should_ChangedState_When_TransitionIsValid()
        {
            var workflow = new SpecificWorkflow<PersonStateEnum, PersonTriggerEnum, Person>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(PersonStateEnum.Anonymous, PersonStateEnum.Registered, PersonTriggerEnum.EnterInformation);
                conf.CreateTransition(PersonStateEnum.Registered, PersonStateEnum.Premium, PersonTriggerEnum.Order, p => p.NumberOfOrder > 15);
            });

            var stateInformation = workflow.GetNextState(PersonStateEnum.Anonymous, PersonTriggerEnum.EnterInformation);
            stateInformation.State.Should().BeEquivalentTo(PersonStateEnum.Registered);
            stateInformation.HasChangedState.Should().BeTrue();

            var person = new Person() { NumberOfOrder = 16 };

            var stateInformation2 = workflow.GetNextState(PersonStateEnum.Registered, PersonTriggerEnum.Order, person);
            stateInformation2.State.Should().BeEquivalentTo(PersonStateEnum.Premium);
            stateInformation2.HasChangedState.Should().BeTrue();
        }

        [TestMethod]
        public void Should_ReturnCurrent_When_TransitionIsInvalid()
        {
            var workflow = new SpecificWorkflow<PersonStateEnum, PersonTriggerEnum, Person>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(PersonStateEnum.Anonymous, PersonStateEnum.Registered, PersonTriggerEnum.EnterInformation);
                conf.CreateTransition(PersonStateEnum.Registered, PersonStateEnum.Premium, PersonTriggerEnum.Order, p => p.NumberOfOrder > 15);
            });

            var person = new Person() { NumberOfOrder = 10 };
            var stateInformation2 = workflow.GetNextState(PersonStateEnum.Registered, PersonTriggerEnum.Order, person);
            stateInformation2.State.Should().BeEquivalentTo(PersonStateEnum.Registered);
            stateInformation2.HasChangedState.Should().BeFalse();
        }


        [TestMethod]
        public void Should_CallOnSucces_WhenChangedState()
        {
            var workflow = new SpecificWorkflow<PersonStateEnum, PersonTriggerEnum, Person>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(PersonStateEnum.Anonymous, PersonStateEnum.Registered, PersonTriggerEnum.EnterInformation);
                conf.CreateTransition(PersonStateEnum.Registered, PersonStateEnum.Premium, PersonTriggerEnum.Order,
                    p => p.NumberOfOrder > 15, p => p.NumberOfOrder++);
            });

            var person = new Person() { NumberOfOrder = 16 };

            workflow.GetNextState(PersonStateEnum.Registered, PersonTriggerEnum.Order, person);

            person.NumberOfOrder.Should().Be(17);

        }
    }
}
