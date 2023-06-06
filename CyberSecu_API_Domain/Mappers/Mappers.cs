using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CyberSecu_API_Domain.Entities;

namespace CyberSecu_API_Domain.Mappers
{
    public static class Mappers
    {
        //public static User ToUserViewModel(this User user)
        //{
        //    return new User
        //    {
        //        Id = user.Id,
        //        Email = user.Email,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //    };

        //}


        static User toUser(this IDataRecord record)
        {
            return new User(

                (int)record["Id"],
                (string)record["Nom"],
                (string)record["Prenom"],
                (string)record["Email"]);


        }


        //internal static User ToUser(User user)
        //{
        //    return new User()
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        Password = user.Password,

        //    };


        //}
    }
}

// four class to be implement :

//Dans le namespace CyberSecu_API_Domain.Mappers, implémentez la classe Mappers qui contient une méthode statique ToUser.
//Cette méthode est utilisée pour convertir un objet User en un autre objet User avec les mêmes propriétés.
//Cela peut sembler redondant, mais c'est probablement utilisé pour faciliter la sérialisation et la désérialisation des objets User dans le cadre de l'API.