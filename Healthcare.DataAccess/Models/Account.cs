using System.ComponentModel.DataAnnotations;

namespace Healthcare.DataAccess
{
    public class Account : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
