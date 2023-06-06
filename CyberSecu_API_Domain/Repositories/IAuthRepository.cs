using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CyberSecu_API_Domain.Commands;
using CyberSecu_API_Domain.Entities;
using CyberSecu_API_Domain.Queries;

namespace CyberSecu_API_Domain.Repositories
{
    public interface IAuthRepository
    {
        User? Handle(ConnectionQuery query);
        void Handle(RegisterCommand command);
    }
}

// Five class to be implement :

// Dans le namespace CyberSecu_API_Domain.Repositories, créez l'interface IAuthRepository
// qui définit les méthodes nécessaires pour gérer l'authentification des utilisateurs.
// Cette interface contient deux méthodes :
// Handle(ConnectionQuery query) pour gérer la connexion d'un utilisateur et renvoyer un objet User correspondant,
// et Handle(RegisterCommand command) pour gérer l'enregistrement d'un nouvel utilisateur.
