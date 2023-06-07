using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecu_API_Domain.Entities
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password = null)
        {
            FirstName = firstName;
            LastName = lastName ;
            Email = email;
            Password = password;
        }

        public User(int id, string firstName, string lastName, string email, string? password = null)
            : this(firstName, lastName, email, password)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

// Third class to be implement :

// Créez la classe User dans le namespace CyberSecu_API_Domain.Entities.
// Cette classe représente un utilisateur avec ses propriétés
// telles que l'identifiant, le prénom, le nom, l'e-mail et le mot de passe.
// Vous pouvez implémenter plusieurs constructeurs pour la classe User
// afin de pouvoir créer des instances avec différentes combinaisons de propriétés.
