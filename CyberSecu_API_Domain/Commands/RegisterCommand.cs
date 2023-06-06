using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecu_API_Domain.Commands
{
    public class RegisterCommand
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public RegisterCommand(string email, string firstName, string lastName, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}

// first class to be implement :
// Commencez par implémenter la classe RegisterCommand qui représente une commande d'enregistrement d'utilisateur.
// Cette classe contient les informations nécessaires pour créer un nouvel utilisateur,
// telles que l'e-mail, le prénom, le nom et le mot de passe.
// Elle sera utilisée pour passer les informations d'enregistrement de l'utilisateur à l'API.