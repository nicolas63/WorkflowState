namespace WorkflowState.Samples
{
    public class State
    {
        public string Name { get; private set; }

        public State(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}