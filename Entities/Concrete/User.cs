using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concretee
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
