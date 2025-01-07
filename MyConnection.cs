using System;
using System.Data;
using Npgsql;  // Pour PostgreSQL

public class MyConnection
{
    private IDbConnection connection;

    // Le constructeur prend l'URL de connexion comme paramètre
    public MyConnection(string connectionString)
    {
        try
        {
            // Vérification rapide de la chaîne de connexion
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("La chaîne de connexion ne peut pas être vide.");
            }

            // Connexion à PostgreSQL
            connection = new NpgsqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'initialisation de la connexion : {ex.Message}");
            throw;  // Rethrow pour signaler l'échec de l'initialisation
        }
    }

    // Méthode pour ouvrir la connexion
    public void OpenConnection()
    {
        try
        {
            connection.Open();
            Console.WriteLine("Connexion réussie !");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'ouverture de la connexion : {ex.Message}");
            // Ajout de la pile d'appels pour un meilleur débogage
            Console.WriteLine(ex.StackTrace);
        }
    }

    // Méthode pour fermer la connexion
    public void CloseConnection()
    {
        try
        {
            connection.Close();
            Console.WriteLine("Connexion fermée.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la fermeture de la connexion : {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    // Méthode pour exécuter une commande SQL de type SELECT et afficher les résultats
    public void ExecuteQueryWithResult(string query)
    {
        try
        {
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (var reader = cmd.ExecuteReader())
                {
                    // Parcours des résultats (ResultSet)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetValue(i) + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Commande exécutée avec succès.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'exécution de la requête : {ex.Message}");
            Console.WriteLine(ex.StackTrace);  // Ajout de la pile d'appels pour le débogage
        }
        finally
        {
            CloseConnection();  // Assurez-vous que la connexion est fermée même si une erreur se produit
        }
    }

    // Méthode pour exécuter une commande SQL de type non SELECT (par exemple, INSERT, UPDATE, DELETE)
    public void ExecuteNonQuery(string query)
    {
        try
        {
            OpenConnection();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Commande exécutée avec succès.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de l'exécution de la requête : {ex.Message}");
            Console.WriteLine(ex.StackTrace);  // Ajout de la pile d'appels pour le débogage
        }
        finally
        {
            CloseConnection();  // Assurez-vous que la connexion est fermée même si une erreur se produit
        }
    }
}
