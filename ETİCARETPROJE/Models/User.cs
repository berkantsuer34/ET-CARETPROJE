﻿namespace ETİCARETPROJE.Models
{
    //kullanıcılar
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
