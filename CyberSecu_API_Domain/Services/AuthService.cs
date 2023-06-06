using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecu_API_Domain.Commands;
using CyberSecu_API_Domain.Entities;
using CyberSecu_API_Domain.Queries;
using CyberSecu_API_Domain.Repositories;


namespace CyberSecu_API_Domain.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IDbConnection _dbConnection;

        public AuthService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Handle(RegisterCommand command)
        {
            using (SqlConnection c = new SqlConnection(_dbConnection.ConnectionString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    
                    cmd.CommandText = "dbo.RegisterUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "@email", command.Email },
                        { "@firstname", command.FirstName },
                        { "@lastname", command.LastName },
                        { "@password", command.Password }
                    };

                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    c.Open();

                    cmd.ExecuteNonQuery();

                    c.Close();
                };
            }
        }

        public User? Handle(ConnectionQuery query)
        {
            using (SqlConnection c = new SqlConnection(_dbConnection.ConnectionString))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    User user = null;
                    cmd.CommandText = "dbo.AuthenticateUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        { "@Email", query.Email },
                        { "@inputPassword", query.Password }

                    };

                    foreach (KeyValuePair<string, object> parameter in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                    }

                    c.Open();

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["id"];
                            string firstName = (string)reader["firstname"];
                            string lastName = (string)reader["lastname"];
                            string email = (string)reader["email"];

                            user = new User(id, firstName, lastName, email);


                        }
                    }
                    c.Close();

                    return user is not null ? user : null;
                }

            }
        }
    }

}

#region Note
// Ce code est une méthode appelée Handle qui prend une requête de connexion (ConnectionQuery) en tant que paramètre et renvoie un objet User. Voici une explication claire et synthétique du code pour les étudiants :

//La méthode Handle permet de gérer la connexion d'un utilisateur en vérifiant les informations fournies dans la requête.

//    À l'aide d'une connexion SQL (SqlConnection), une commande SQL (SqlCommand) est créée.

//    La commande est configurée pour exécuter une procédure stockée appelée "dbo.AuthenticateUser" qui est définie dans la base de données.

//    Les paramètres de la procédure stockée, tels que l'e-mail et le mot de passe, sont spécifiés à l'aide d'un dictionnaire (Dictionary<string, object>).

//    Les paramètres sont ajoutés à la commande SQL à l'aide de l'objet SqlParameter.

//    La connexion à la base de données est ouverte.

//    Les résultats de la procédure stockée sont récupérés à l'aide d'un lecteur de données (DbDataReader).

//    Les informations de l'utilisateur, telles que l'identifiant, le prénom, le nom et l'e-mail, sont extraites des résultats et utilisées pour créer un nouvel objet User.

//    Si un utilisateur correspondant est trouvé, l'objet User est retourné. Sinon, si aucun utilisateur n'est trouvé, null est retourné.

//    La connexion à la base de données est fermée.

//    En résumé, ce code exécute une procédure stockée dans la base de données pour vérifier les informations de connexion de l'utilisateur. Il extrait les informations de l'utilisateur à partir des résultats et renvoie un objet User correspondant.


#endregion
