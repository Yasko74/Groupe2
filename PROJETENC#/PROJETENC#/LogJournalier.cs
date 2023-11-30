using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;


public class LogJournalier
{
    public class LogEntry
    {
        public string NomSauvegarde { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public long TailleFichier { get; set; }
        public double TempsTransfert { get; set; }
        public DateTime Time { get; set; }
    }
    private string cheminFichier;

    public LogJournalier(string cheminFichier)
    {
        this.cheminFichier = cheminFichier;

        // Créer le fichier s'il n'existe pas
        if (!File.Exists(cheminFichier))
        {
            // Création d'un tableau vide pour initialiser le fichier JSON
            File.WriteAllText(cheminFichier, "[]");
        }
    }

    public void AjouterLog(string nomSauvegarde, string source, string destination, long tailleFichier, double tempsTransfert, DateTime time)
    {
        // Charger les logs existants depuis le fichier
        List<LogEntry> logs = ChargerLogs();

        // Ajouter une nouvelle entrée
        LogEntry nouvelleEntree = new LogEntry
        {
            NomSauvegarde = nomSauvegarde,
            Source = source,
            Destination = destination,
            TailleFichier = tailleFichier,
            TempsTransfert = tempsTransfert,
            Time = time
        };

        logs.Add(nouvelleEntree);

        // Enregistrer la liste mise à jour dans le fichier JSON
        SauvegarderLogs(logs);
    }

    private List<LogEntry> ChargerLogs()
    {
        // Charger le contenu du fichier JSON dans une liste
        string contenuFichier = File.ReadAllText(cheminFichier);
        List<LogEntry> logs = JsonConvert.DeserializeObject<List<LogEntry>>(contenuFichier);

        // Si la liste est nulle, initialiser avec une liste vide
        return logs ?? new List<LogEntry>();
    }

    private void SauvegarderLogs(List<LogEntry> logs)
    {
        // Convertir la liste en format JSON et enregistrer dans le fichier
        string contenuFichier = JsonConvert.SerializeObject(logs, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(cheminFichier, contenuFichier);
    }
}




