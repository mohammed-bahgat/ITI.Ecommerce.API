namespace ITI.Ecommerce.Presentaion.Models
{
    public class UserCreateModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
