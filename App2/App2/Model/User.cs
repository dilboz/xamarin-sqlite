﻿using SQLite;

namespace App2.Model
{
    public class User
    {
        public string Id { get; set; }

        public string Email { get; set; }
        
        public bool PasswordHash { get; set; }
    }
}