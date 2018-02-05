namespace WorkflowState.Samples
{
    public class State
    {
        public string Name { get; private set; }

        public State(string name)
        {
            Name = name;
        }
    }
}