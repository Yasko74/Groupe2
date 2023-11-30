using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Program
    {
        static void Main()
        {
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

            // initialiser l'instance StopWatch qui mesure la durée d'execution
            Stopwatch stopwatch = new Stopwatch();
            // mettre StopWatch en start  
            stopwatch.Start();
            // Appeler la méthode add_backup avec les paramètres initialisés
            Backup_job.add_backup(backupJob.job_name, backupJob.source_direction, backupJob.target_direction,backupJob.backup_type, backupJob.FileSource, backupJob.FileDestination);
            // mettre StopWatch en stop  
            stopwatch.Stop();
            // mettre la duree dans la variable tempstransfert  
            TimeSpan tempsTransfert = stopwatch.Elapsed;

            long filesize = Backup_job.GetSize(backupJob.source_direction, backupJob.FileSource);

            // Exemple d'utilisation de la classe LogJournalier
            LogJournalier logger = new LogJournalier("C:\\logstest.json");

            // Exemple d'ajout d'une entrée au journal
            logger.AjouterLog(backupJob.job_name, backupJob.source_direction, backupJob.target_direction,filesize, tempsTransfert.TotalMilliseconds, DateTime.Now);

            Console.WriteLine("Log ajouté avec succès.");
        }
    }
}
