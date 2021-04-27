using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace HamsterData
{
    public class HamsterDBContext : DbContext
    {

        public HamsterDBContext()
        {

        }
        public virtual DbSet<Hamster> Hamsters { get; set; }
        public virtual DbSet<Cage> Cages { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<WellnessCenter> WellnessCenters { get; set; }
        public virtual DbSet<HistoryLog> HistoryLogs { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-14R42PPR\SQLEXPRESS;Database=AdvStefanTrenh;Integrated Security=SSPI;MultipleActiveResultSets=True;");
                //optionsBuilder.UseLazyLoadingProxies();
                //optionsBuilder.UseSqlServer(@"Server=LAPTOP-14R42PPR\SQLEXPRESS;Database=AdvStefanTrenh;Integrated Security=SSPI;")
                //                            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                //                            LogLevel.Information);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Hamster> hamsters = GetHamsterDataByFile("Hamsterlista30.csv");
            List<Owner> owners = GetOwnersDataByFile("Hamsterlista30.csv");
            List<Cage> cages = GetCageDataInfo();
            List<Activity> activities = GetActivitiesData();
            modelBuilder.Entity<Hamster>().HasData(hamsters);
            modelBuilder.Entity<Owner>().HasData(owners);
            modelBuilder.Entity<Cage>().HasData(cages);
            modelBuilder.Entity<Cage>(c => c.HasCheckConstraint("CK_Cage_Size", "[Size] >= 0 AND [Size] <= 3"));
            modelBuilder.Entity<Activity>().HasData(activities);
            modelBuilder.Entity<WellnessCenter>().HasData(
                   new WellnessCenter { WellnessCenterId = 1, Size = 0 }
                );
            modelBuilder.Entity<WellnessCenter>(w => w.HasCheckConstraint("CK_WellnessCenter_Size", "[Size] >= 0 AND [Size] <= 6"));
        }
        private List<Hamster> GetHamsterDataByFile(string file)
        {
            List<Hamster> hamsters = new List<Hamster>();
            StreamReader sr = new StreamReader(file);
            int id = 1;
            using (sr)
            {
                // string exempel Rufus;4;M;Kallegurra Aktersnurra
                /*
                 * Split 0 = Hamster Name
                 * Split 1 = Age
                 * Split 2 = Gender
                */

                string line = sr.ReadLine();
                while (line != null)
                {
                    Hamster hamster = new Hamster();
                    string[] split = line.Split(";");
                    hamster.Name = split[0];
                    hamster.Age = int.Parse(split[1]);
                    hamster.Gender = char.Parse(split[2]);
                    hamster.HamsterId = id;
                    hamster.OwnerId = int.Parse(split[4]);
                    line = sr.ReadLine();
                    hamsters.Add(hamster);
                    id++;
                }
            }
            return hamsters;

        } // Read file to hamster object list
        private List<Owner> GetOwnersDataByFile(string file)
        {
            StreamReader sr = new StreamReader(file);
            using (sr)
            {
                // string exempel Rufus;4;M;Kallegurra Aktersnurra
                /*  TASK
                 *  Get Firstname and Lastname by split[3]
                 *  Create a random generator for
                 *  E-Mail and phone number
                 */
                List<Owner> ownerList = new List<Owner>();
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] split = line.Split(";");
                    string fullname = split[3];
                    string[] getFullname = fullname.Split(" ");
                    Owner owner = new Owner();
                    owner.FirstName = getFullname[0];
                    owner.LastName = getFullname[1];

                    string[] emailArray = { "Live.se", "Hotmail.com", "Yahoo.com", "Outlook.se" };
                    Random random = new Random();
                    int ranNr = random.Next(0, 3);
                    string email = $"{owner.FirstName}{owner.LastName}@{emailArray[ranNr]}";
                    owner.Email = email;

                    int ranNr2 = random.Next(60000000, 99999999);
                    string phoneNumb = $"7{ranNr2}";
                    owner.Phone = int.Parse(phoneNumb);

                    ownerList.Add(owner);
                    line = sr.ReadLine();

                }
                /*
                 *  This query is not optimal, normaly there is a personalID 900607-xxxx for search engin
                 */
                var query = ownerList.GroupBy(o => o.FirstName + o.LastName)
                             .Select(g => g.First())
                             .ToList();

                for (int i = 0; i < query.Count; i++)
                {
                    query[i].OwnerId = i + 1;
                }

                return query;
            }
        } // Read file to owner list with generated mails and phone numbs
        private List<Cage> GetCageDataInfo()
        {
            List<Cage> cages = new List<Cage>();
            for (int i = 0; i < 10; i++)
            {
                Cage cage = new Cage();
                cage.CageId = i + 1;
                cage.Size = 0;
                if (i <= 4)
                {
                    cage.IsMale = true;
                }
                cages.Add(cage);
            }
            return cages;
        } // 10 Cages
        private List<Activity> GetActivitiesData()
        {
            List<Activity> activities = new List<Activity>();
            for (int i = 0; i < 4; i++)
            {
                Activity activity = new Activity();
                activity.ActivityId = i + 1;
                string[] types = { "Workout", "Move To Cage", "Arrival", "Checked Out" };
                activity.Type = types[i];
                activities.Add(activity);
            }
            return activities;
        }
    }
}
