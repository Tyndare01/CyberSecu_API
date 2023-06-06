using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecu_API_Domain.Queries
{

    public class ConnectionQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ConnectionQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    
}

// second class to be implement : 
// Ensuite, implémentez la classe ConnectionQuery qui représente une requête de connexion utilisateur.
// Cette classe contient l'e-mail et le mot de passe de l'utilisateur qui souhaite se connecter.
// Elle sera utilisée pour vérifier les informations de connexion de l'utilisateur dans l'API.