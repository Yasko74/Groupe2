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
    public static long GetSize(string path, string name)
    {
        string fullPath = Path.Combine(path, name);
        long totalSize = 0;

        // Vérifie si le chemin spécifié est un dossier
        if (Directory.Exists(fullPath))
        {
            // Obtenir la taille des fichiers dans le dossier
            foreach (var file in Directory.GetFiles(fullPath))
            {
                var fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            // Obtenir la taille des sous-dossiers en appelant récursivement la fonction GetSize
            foreach (var directory in Directory.GetDirectories(fullPath))
            {
                totalSize += GetSize(directory, "");
            }
        }
        else if (File.Exists(fullPath))
        {
            // Si le chemin spécifié est un fichier, obtenir simplement la taille du fichier
            var fileInfo = new FileInfo(fullPath);
            totalSize += fileInfo.Length;
        }
        else
        {
            // Le chemin n'existe pas
            Console.WriteLine("Le chemin spécifié n'existe pas.");
        }

        return totalSize;
    }


}



