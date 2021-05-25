namespace Data.ViewModels
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string BusinessId { get; set; }
        public string AgentNumber { get; private set; }
        public string PIN { get; private set; }
    }
}