using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class Backup_real_time
{
    public string job_name { get; set; }
    public State State { get; get; }
    public int total_size { get; get; }
    public int file { get; get; }
    public int back_up_realtime_id { get; set; }
    public int files { get; set; }
    public float sizes { get; get; }
    public string adresse_source { get; set; }
    public string adresse_destination { get; set; }


    public static void add_backup_realtime()
    {

    }
    public static void save_backup_TempsReel()
    {

    }

}







public enum State
{
    Active,
    End
}

class Program
{
    static void Main() { }

}