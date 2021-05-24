namespace Core.ViewModels
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string BusinessId { get; set; }
        public int AgentNumber { get; private set; }
        public int PIN { get; private set; }
    }
}