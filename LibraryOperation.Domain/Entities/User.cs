namespace LibraryOperation.Domain.Entities
{

    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }

        public virtual ICollection<Borrower>? Borrowers { set; get; }
    }
}