namespace Data.ViewModels
{
    public class AgentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string BusinessId { get; set; }
<<<<<<< HEAD:backend/Data/ViewModels/AgentViewModel.cs
        public string AgentNumber { get; private set; }
        public string PIN { get; private set; }
=======
        public int AgentNumber { get; private set; }
        public int PIN { get; private set; }
>>>>>>> added-agent:backend/Core/ViewModels/AgentViewModel.cs
    }
}