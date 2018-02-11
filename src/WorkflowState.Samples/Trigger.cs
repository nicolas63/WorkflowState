namespace WorkflowState.Samples
{
    public class Trigger
    {
        private string Name { get; set; }

        public Trigger(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}