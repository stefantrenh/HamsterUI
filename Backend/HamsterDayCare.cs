using Backend.Events;
using HamsterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail; // Email NameSpace
using System.Net; //Credential
using System.Text;
using System.Threading;

namespace Backend
{
    public class HamsterDayCare
    {
        public event EventHandler<HamsterDayCareInfoEventArgs> SendHamsterDayCareInfo;
        public event EventHandler<DailyReportEventArgs> SendDailyInfo;
        private DateTime currentDate;
        private int ticks;

        public HamsterDayCare()
        {
            currentDate = new DateTime(2021, 04, 01, 07, 00, 00);
            MakeSureDbIsCreated();
            ChangeBackToStartConfigs();
            AddHamsterToCagesByGender('K');
            AddHamsterToCagesByGender('M');
        }

        #region Events Area
        public async void RunAll(object sender, TimerEventArgs e) //Ticker event subscriber 
        {
            ticks = e.Ticker;
            currentDate = e.Time;
            if (ticks == 0)
            {
                await Task.Run(() => HamsterCheckinByNewDay());
            }
            if (ticks % 11 == 0 && ticks < 99 || ticks == 11 && ticks < 99)
            {
                await Task.Run(() => TeleportBackToCages());
                await Task.Run(() => AddHamsterToWellnessCenterThatHasNotWorkedOutYet('K'));
                if (CheckIfAllHasWorkedOutYet('K') && CheckIfAllHasWorkedOutYet('M') == false)
                {
                    await Task.Run(() => AddHamsterToWellnessCenterThatHasNotWorkedOutYet('M'));
                }
                else if(CheckIfAllHasWorkedOutYet('K') && CheckIfAllHasWorkedOutYet('M'))
                {
                    AddRandomHamsterToWellnessCenter();
                }
            }
            if (ticks < 101)
            {
                await Task.Run(() => OnHamsterDayCareVisualInfo(e.Ticker, e.Time));
            }
            if (ticks == 101)
            {
                OnDailyInfo();
                SendMail();
                await Task.Run(() => CheckOutHamsters());
            }
        }
        protected virtual void OnHamsterDayCareVisualInfo(int totalTicks, DateTime time) //Sends out event at every tick for visual updates
        {
            var ctx = new HamsterDBContext();
            var hamsterlist = ctx.Hamsters.ToList();
            var hamsterLog = new HamsterDayCareInfoEventArgs(hamsterlist, totalTicks, time);
            SendHamsterDayCareInfo?.Invoke(this, hamsterLog);
        }
        protected virtual void OnDailyInfo() // sends out event 
        {
            var ctx = new HamsterDBContext();
            var historyLog = ctx.HistoryLogs.ToList();
            var hamsterlist = ctx.Hamsters.ToList();
            DailyReportEventArgs dailyReport = new DailyReportEventArgs(hamsterlist,historyLog,ticks,currentDate);
            SendDailyInfo?.Invoke(this,dailyReport);
        }
        #endregion

        #region Thread Area
        protected async Task CheckOutHamsters()
        {
            await Task.Run(() => {
                var ctx = new HamsterDBContext();
                ChangeBackToStartConfigs();
                var hamsterList = ctx.Hamsters.ToList();
                for (int i = 0; i < hamsterList.Count; i++)
                {
                    ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamsterList[i].HamsterId, 4, currentDate.ToString("yyyy-MM-dd HH:mm:ss")); // PROC
                }
                GetHamsterReadyForCheckOutByGender('M');
                GetHamsterReadyForCheckOutByGender('K');
            } );
        }
        protected async Task TeleportBackToCages()
        {
            await Task.Run(() =>
            {
                var ctx = new HamsterDBContext(); //context 
                var wellnessCenter = ctx.WellnessCenters.First(); // wellness object
                var hamsters = ctx.Hamsters
                              .Where(h => h.WellnessCenterId == 1).ToList(); //hamsterlist in cage
                for (int i = 0; i < hamsters.Count; i++)
                {
                    var hamster = hamsters[i];
                    bool isMale = false;
                    if (hamster.Gender == 'M')
                    {
                        isMale = true;
                    }
                    var cage = ctx.Cages
                       .Where(c => c.Size < 3 && c.IsMale == isMale)
                       .First();

                    cage.Size++;
                    hamster.CageId = cage.CageId;
                    hamster.WellnessCenterId = null;
                    wellnessCenter.Size--;
                    ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 2, currentDate.ToString("yyyy-MM-dd HH:mm:ss")); // PROC
                    ctx.SaveChanges();
                }
            });
        }
        protected async Task AddHamsterToWellnessCenterThatHasNotWorkedOutYet(char gender)
        {
           await Task.Run(() => {

           var ctx = new HamsterDBContext();
           var wellnessCenter = ctx.WellnessCenters.First(); //getting wellnessCenter object
           var hamsters = ctx.Hamsters
                                .Where(h => h.HasWorkedOut == false)
                                .Where(g => g.Gender == gender).ToList(); // hamsterlist by gender
           var queueHamsters = new Queue<Hamster>(); // queue instance
           for (int i = 0; i < hamsters.Count; i++)
           {
               queueHamsters.Enqueue(hamsters[i]); // add from list to queue
           }
           if (queueHamsters.Count > 6 && wellnessCenter.Size == 0) // add 6 hamsters to wellnesscenter
           {
               for (int i = 0; i < 6; i++)
               {
                   var hamster = queueHamsters.Dequeue(); //hamster object from first in queue
                   var cage = ctx.Cages   // Get cageid by linq query
                              .Where(c => c.CageId == hamster.CageId)
                              .First();
                   hamster.CageId = null;
                   hamster.WellnessCenterId = wellnessCenter.WellnessCenterId;
                   hamster.HasWorkedOut = true;
                   cage.Size--;
                   wellnessCenter.Size++;
                       ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 1, currentDate.ToString("yyyy-MM-dd HH:mm:ss")); // procedure
                       var date1 = hamster.CheckedIn;
                       TimeSpan ts = currentDate - (DateTime)date1;
                       hamster.TimeWaited = ts;
                       ctx.SaveChanges();
               }
           }
           else if (queueHamsters.Count == 3)
           {
               for (int i = 0; i < 3; i++)
               {
                   var hamster = queueHamsters.Dequeue();
                   var cage = ctx.Cages
                              .Where(c => c.CageId == hamster.CageId)
                              .First();
                   hamster.CageId = null;
                   hamster.WellnessCenterId = wellnessCenter.WellnessCenterId;
                   hamster.HasWorkedOut = true;
                   wellnessCenter.Size++;
                   cage.Size--;
                       ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 1, currentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                       var date1 = hamster.CheckedIn;
                       TimeSpan ts = currentDate - (DateTime)date1;
                       hamster.TimeWaited = ts;
                       ctx.SaveChanges();
               }
               for (int j = 0; j < 3; j++)
               {
                   var hamsterList = ctx.Hamsters
                                     .Where(c => c.CageId != null)
                                     .Where(c => c.Gender == gender).ToList();
                   Random rdn = new Random();
                   int random = rdn.Next(0, hamsterList.Count);
                   var hamster = hamsterList[random];
                   var cage = ctx.Cages
                              .Where(c => c.CageId == hamster.CageId)
                              .First();
                   hamster.CageId = null;
                   hamster.WellnessCenterId = wellnessCenter.WellnessCenterId;
                   wellnessCenter.Size++;
                   cage.Size--;
                       ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 1, currentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                       ctx.SaveChanges();
               }
               }
           });
        }
        protected async Task HamsterCheckinByNewDay()
        {
            await Task.Run(() => {
                var ctx = new HamsterDBContext();
                var query = ctx.Hamsters.ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    query[i].CheckedIn = currentDate;
                    ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", query[i].HamsterId, 3, currentDate.ToString("yyyy-MM-dd HH:mm:ss")); // procedure
                    ctx.SaveChanges();
                }
            } );

        }
        #endregion

        #region LinqQuery Area
        private void AddRandomHamsterToWellnessCenter()
        {
            var ctx = new HamsterDBContext();
            Random rdn = new Random();
            int random = rdn.Next(0,2);
            char[] gender = { 'K', 'M' };

            var hamsterList = ctx.HistoryLogs
                              .Where(l => l.ActivityId == 1) // 1 = Workout Area
                              .Where(h => h.Hamster.Gender == gender[random]) // random gender pick off
                              .AsEnumerable() // make it possible to loop through group by
                              .GroupBy(i => i.HamsterId) // IEnumerable
                              .OrderBy(k => k.Key).ToList();

            var hamsterQueue = new Queue<int>(); // queue list
            for (int i = 0; i < hamsterList.Count; i++)
            {
                hamsterQueue.Enqueue(hamsterList[i].Key);
            }
            for (int i = 0; i < 6; i++)
            {
               var wellnessCenter = ctx.WellnessCenters
                                     .First(); // we just got one wellnesscenter Q.Q

               int hamsterId = hamsterQueue.Dequeue();
               var hamster = ctx.Hamsters //found the object hamster yeyeyey!!!
                             .Where(h => h.HamsterId == hamsterId)
                             .First();

                var cage = ctx.Cages // i found you , you cant hide! in this cage!
                           .Where(c => c.CageId == hamster.CageId)
                           .First();

                cage.Size--; // pick them off
                wellnessCenter.Size++; // get them to bootcamp
                hamster.CageId = null;
                hamster.WellnessCenterId = wellnessCenter.WellnessCenterId;
                ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 1, currentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                ctx.SaveChanges();
            }
 /*
      SELECT H.HamsterId, COUNT(L.ActivityId)
      FROM HistoryLogs L
      JOIN Hamsters H
      ON H.HamsterId = L.HamsterId
      WHERE L.ActivityId = 1
      GROUP BY H.HamsterId
      ORDER BY COUNT(H.HamsterId)
 */


        }
        private bool CheckIfAllHasWorkedOutYet(char gender)
        {
            var ctx = new HamsterDBContext();
            var query = ctx.Hamsters.Where(w => w.HasWorkedOut == false)
                                    .Where(g => g.Gender == gender).FirstOrDefault();
            bool flag = false;
            if (query != null)
            {
                flag = false;
            }
            else if (query == null)
            {
                flag = true;
            }
            return flag;
        }
        private void ChangeBackToStartConfigs()
        {
                var ctx = new HamsterDBContext();
                var wellnessCenter = ctx.WellnessCenters.First();
                wellnessCenter.Size = 0;

                var cages = ctx.Cages.ToList();
                for (int i = 0; i < cages.Count; i++)
                {
                    cages[i].Size = 0;
                }
                var hamsterList = ctx.Hamsters.ToList();
                for (int i = 0; i < hamsterList.Count; i++)
                {
                    hamsterList[i].CageId = null;
                    hamsterList[i].WellnessCenterId = null;
                    hamsterList[i].HasWorkedOut = false;
                    hamsterList[i].TimeWaited = null;
                }
                ctx.SaveChanges();
        }
        private void MakeSureDbIsCreated()
        {
            using (HamsterDBContext HContext = new HamsterDBContext())
            {
                HContext.Database.Migrate();
            }
        } //ensures that the db is created first before starting the application
        private void AddHamsterToCagesByGender(char gender)
        {
                using (var ctx = new HamsterDBContext())
                {
                    var hamsters = ctx.Hamsters.ToList();
                    for (int i = 0; i < hamsters.Count; i++)
                    {
                        if (hamsters[i].Gender == gender)
                        {
                            var hamster = ctx.Hamsters
                                .Where(h => h.HamsterId == hamsters[i].HamsterId)
                                .FirstOrDefault();

                            if (hamster != null && hamsters[i].Gender == 'M' && hamsters[i].CageId == null)
                            {
                                var cages = ctx.Cages
                                            .Where(c => c.Size < 3)
                                            .Where(g => g.IsMale == true)
                                            .FirstOrDefault();
                                if (cages != null)
                                {
                                    cages.Size++;
                                    hamster.CageId = cages.CageId;
                                    hamster.CheckedIn = currentDate;
                                    ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 3, currentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                    ctx.SaveChanges();
                                }
                            }
                            else if (hamster != null && hamsters[i].Gender == 'K' && hamsters[i].CageId == null)
                            {
                                var cages = ctx.Cages
                                            .Where(c => c.Size < 3)
                                            .Where(g => g.IsMale == false)
                                            .FirstOrDefault();
                                if (cages != null)
                                {
                                    cages.Size++;
                                    hamster.CageId = cages.CageId;
                                    hamster.CheckedIn = currentDate;
                                ctx.Database.ExecuteSqlRaw("EXEC AddToHistoryLog {0},{1},{2}", hamster.HamsterId, 3, currentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                                ctx.SaveChanges();
                                }
                            }
                        }
                    }
                }
        } // function to contruct to add all hamster to cages
        private void GetHamsterReadyForCheckOutByGender(char gender)
        {
            using (var ctx = new HamsterDBContext())
            {
                var hamsters = ctx.Hamsters.ToList();
                for (int i = 0; i < hamsters.Count; i++)
                {
                    if (hamsters[i].Gender == gender)
                    {
                        var hamster = ctx.Hamsters
                            .Where(h => h.HamsterId == hamsters[i].HamsterId)
                            .FirstOrDefault();

                        if (hamster != null && hamsters[i].Gender == 'M' && hamsters[i].CageId == null)
                        {
                            var cages = ctx.Cages
                                        .Where(c => c.Size < 3)
                                        .Where(g => g.IsMale == true)
                                        .FirstOrDefault();
                            if (cages != null)
                            {
                                cages.Size++;
                                hamster.CageId = cages.CageId;
                                ctx.SaveChanges();
                            }
                        }
                        else if (hamster != null && hamsters[i].Gender == 'K' && hamsters[i].CageId == null)
                        {
                            var cages = ctx.Cages
                                        .Where(c => c.Size < 3)
                                        .Where(g => g.IsMale == false)
                                        .FirstOrDefault();
                            if (cages != null)
                            {
                                cages.Size++;
                                hamster.CageId = cages.CageId;
                                ctx.SaveChanges();
                            }
                        }
                    }
                }
            }
        } // function to contruct to add all hamster to cages
        #endregion

        #region API AREA
        protected void SendMail() // sends out event 
        {
            var ctx = new HamsterDBContext();
            var historyLog = ctx.HistoryLogs.ToList();
            var hamsterlist = ctx.Hamsters.ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hamsterlist.Count; i++)
            {
                var query = ctx.Owners //Owner Object
                            .Where(o => o.OwnerId == hamsterlist[i].OwnerId)
                            .First();
                string hamster = $"Hamster ID:{hamsterlist[i].HamsterId} \nName: {hamsterlist[i].Name} \nTime Waited To WorkOut: {hamsterlist[i].TimeWaited}\nOwner: {query.FirstName +" "+ query.LastName}\nContact Info\nPhone: {query.Phone}\nEmail: {query.Email}\n";
                sb.Append(hamster);
                sb.Append("\n ");
            }

            DailyReportEventArgs dailyReport = new DailyReportEventArgs(hamsterlist, historyLog, ticks, currentDate);
            SmtpClient Client = new SmtpClient();
            {
                Client.Host = "smtp.gmail.com"; //mail host
                Client.Port = 587; //port used for mail
                Client.EnableSsl = true; //enable connections
                Client.DeliveryMethod = SmtpDeliveryMethod.Network; // email sends trough a SMTP server
                Client.UseDefaultCredentials = false;
                Client.Credentials = new NetworkCredential()  //to check mail password etc
                {
                    UserName = "stefantrenhhamsterexam@gmail.com",
                    Password = "ExamExam123456"
                };
                MailAddress fromEmail = new MailAddress("stefantrenhhamsterexam@gmail.com");

                MailMessage mailMessage = new MailMessage()
                {
                    From = fromEmail,
                    Subject = $"DailyReport {currentDate}",
                    Body = sb.ToString()
                };
                mailMessage.To.Add(fromEmail); // can add multiply sends
                Client.Send(mailMessage);
                try
                {
                    Client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
       
        }

        #endregion

    }
}
