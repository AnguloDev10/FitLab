﻿namespace Fitlab.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }

        public Profile Profile { get; set; }
    }
}