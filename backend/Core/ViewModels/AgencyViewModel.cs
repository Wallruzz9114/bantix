namespace Core.ViewModels
{
    public class AgencyViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string BusinessId { get; set; }
        public int AgencyNumber { get; private set; }
        public int PIN { get; private set; }
    }
}