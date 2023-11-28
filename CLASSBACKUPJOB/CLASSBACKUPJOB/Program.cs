using System;
using System.IO;

public class Backup_job
{
    public string job_name;
    public string source_direction;
    public string target_direction;
    public string backup_type;
    public string FileSource;
    public string FileDestination;

    // Changez la signature de la méthode pour qu'elle soit statique
    public static void add_backup(string job_name, string source_direction, string target_direction,
                                  string backup_type, string FileSource, string FileDestination)
    {
        try
        {
            // Vérifier si le répertoire source existe
            if (Directory.Exists(source_direction))
            {
                // Vérifier si le répertoire de destination existe, sinon le créer
                if (!Directory.Exists(target_direction))
                {
                    Directory.CreateDirectory(target_direction);
                }

                // Construire les chemins complets des fichiers source et destination
                string sourceFilePath = Path.Combine(source_direction, FileSource);
                string destinationFilePath = Path.Combine(target_direction, FileDestination);

                // Copier le fichier de source vers destination
                File.Copy(sourceFilePath, destinationFilePath, true);

                Console.WriteLine("La sauvegarde  '" + job_name + "' a été créée avec succès.");
            }
            else
            {
                Console.WriteLine("Le répertoire source n'existe pas.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Exemple d'utilisation avec des paramètres différents

        // Créez une instance de la classe Backup_job
        Backup_job backupJob = new Backup_job();

        Console.Write("Nom de la sauvegarde ? : ");
        backupJob.job_name = Console.ReadLine();

        Console.Write("Donnez le chemin des fichiers que vous souhaitez sauvegarder : ");
        backupJob.source_direction = Console.ReadLine();

        Console.Write("donnez le chemin des fichiers sauvegardés : ");
        backupJob.target_direction = Console.ReadLine();

        Console.Write("le type de backup ? : ");
        backupJob.backup_type = Console.ReadLine();

        Console.Write("nom du fichier source : ");
        backupJob.FileSource = Console.ReadLine();

        Console.Write("nom du fichier sauvegardé : ");
        backupJob.FileDestination = Console.ReadLine();

        // Appelez la méthode add_backup avec les paramètres initialisés
        Backup_job.add_backup(backupJob.job_name, backupJob.source_direction, backupJob.target_direction,
                              backupJob.backup_type, backupJob.FileSource, backupJob.FileDestination);
    }
}