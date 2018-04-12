using System;
using WorkflowState.Core;
using WorkflowState.Core.Graph;

namespace WorkflowState.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var startState = new State(name:"Start");
            var endState = new State(name:"End");
            var trigger = new Trigger("StateChanged");

            var workflow = new GenericWorkflow<State, Trigger>();

            workflow.Configure(conf =>
            {
                conf.CreateTransition(startState, endState, trigger).AsFirstTransition().AsLastTransition();
            });

            var stateInformation = workflow.GetNextState(startState, trigger);

            Console.WriteLine(stateInformation.State.Name);

            var graph = GraphHelper.ExportWorkflow(workflow);

            Console.WriteLine(graph);

            var specificWorkflow = new SpecificWorkflow<State, Trigger, int>();

            specificWorkflow.Configure(conf =>
            {
                conf.CreateTransition(startState, endState, trigger, i => i >2);
            });

            var stateInformation2 = specificWorkflow.GetNextState(startState, trigger,1);
            Console.WriteLine(stateInformation2.State.Name);

            var stateInformation3 = specificWorkflow.GetNextState(startState, trigger, 3);
            Console.WriteLine(stateInformation3.State.Name);

            
            var specificWorkflow2 = new SpecificWorkflow<EnumState, EnumTrigger, int>();

            specificWorkflow2.Configure(conf =>
            {
                conf.CreateTransition(EnumState.Start, EnumState.Intermediate, EnumTrigger.StateChanged).AsFirstTransition();
                conf.CreateTransition(EnumState.Intermediate, EnumState.End, EnumTrigger.StateChanged, i => i > 2).AsLastTransition();
                conf.CreateTransition(EnumState.Intermediate, EnumState.Start, EnumTrigger.StateChanged, i => i < 2);
            });

            var stateInformation4 = specificWorkflow2.GetNextState(EnumState.Start, EnumTrigger.StateChanged, 1);
            Console.WriteLine(stateInformation4.State);

            var stateInformation5 = specificWorkflow2.GetNextState(EnumState.Intermediate, EnumTrigger.StateChanged, 3);
            Console.WriteLine(stateInformation5.State);
            var graph2 = GraphHelper.ExportWorkflow(specificWorkflow2);

            Console.WriteLine(graph2);

            Console.ReadLine();
        }
    }
}
