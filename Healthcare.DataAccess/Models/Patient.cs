namespace Healthcare.DataAccess
{
    public class Patient : BaseModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string HomeAddress { get; set; }
        public byte[] PhotoBytes { get; set; }
    }
}
