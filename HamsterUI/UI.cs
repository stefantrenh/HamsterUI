using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;
using Backend.Events;
using System.Threading.Tasks;
using System.Threading;

namespace HamsterUI
{
    public class UI
    {
        int days = 1;
        static int tickerSpeed;
        static int totalDays;
        public void Run()
        {
            MainMenu();
            HamsterDayCare dayCare = new HamsterDayCare();
            TimerTicker timer = new TimerTicker(tickerSpeed,totalDays);
            timer.SendTick += dayCare.RunAll;
            dayCare.SendHamsterDayCareInfo += ShowHamsterDayCareStatus;
            dayCare.SendDailyInfo += timer.OnSendningDailyInfo;
            dayCare.SendDailyInfo += ShowDailyLog;
            timer.StartTicks();
            Console.ReadLine();
        }
        protected static void MainMenu()
        {
            Logo();
            Thread.Sleep(2000);
            Console.Clear();
            Logo2();
            Console.SetCursorPosition(55, 35); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("Recommended tickspeed > 200"); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 36); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("Warning under tickspeed 100 may crash!!!!"); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 45); Console.ForegroundColor = ConsoleColor.Green; Console.Write("Stefan Trenh SUT20"); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 46); Console.ForegroundColor = ConsoleColor.Green; Console.Write("HamsterSimulator 2021 - Advanced .Net"); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 33); Console.Write("Enter Tickerspeed: ");
            tickerSpeed = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(55, 33); Console.Write("Enter Total Days:      ");
            totalDays = int.Parse(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                Loading1();
                Thread.Sleep(500);
                Console.Clear();
                Loading2();
                Thread.Sleep(500);
                Console.Clear();
                Loading3();
                Thread.Sleep(500);
                Console.Clear();
            }
            Console.SetCursorPosition(55, 25); Console.ForegroundColor = ConsoleColor.Green; Console.Write("LETS GO!!!!"); Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.Clear();
        }
        public async void ShowDailyLog(object sender, DailyReportEventArgs e)
        {
            await Task.Run(() =>{
                Console.Clear();
                int centerPos = 30;
                Console.SetCursorPosition(centerPos, 5); Console.Write($"Daily Report: {e.Date}");
                Console.SetCursorPosition(15, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("ID"); Console.SetCursorPosition(25, 7); Console.Write("Hamster Name"); Console.SetCursorPosition(45, 7); Console.Write("Time Waited For Work-out"); Console.SetCursorPosition(75, 7); Console.Write("Total Workouts"); Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < e.Hamsters.Count; i++)
                {
                    Console.SetCursorPosition(15, 8 + i);  Console.Write(e.Hamsters[i].HamsterId); Console.SetCursorPosition(25, 8 + i); Console.Write(e.Hamsters[i].Name); Console.SetCursorPosition(45, 8 + i); Console.Write(e.Hamsters[i].TimeWaited.ToString());

                    var query = e.Logs
                                .Where(l => l.Timestamp.Day == e.Date.Day)
                                .Where(z => z.ActivityId == 1)
                                .Where(y => y.HamsterId == e.Hamsters[i].HamsterId)
                                .Count();
                    Console.SetCursorPosition(75, 8+i); Console.Write(query);
                }

            });
        
        }
        protected async void ShowHamsterDayCareStatus(object sender, HamsterDayCareInfoEventArgs e)
        {
            await Task.Run(() => {
                int firstCageRow = 5;
                int counter = 0;
                if (e.DayTicker % 102 == 0)
                {
                    days++;
                }
                int[] cageLeftPos = { 15,35,55,75,95 };

                Console.SetCursorPosition(50,1); Console.Write("Date: " + e.Date);
                Console.SetCursorPosition(50,3); Console.Write("Day: "+days);

                for (int i = 4; i < 40; i++)
                {
                    Console.SetCursorPosition(cageLeftPos[0], i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                int num = 5;
                for (int j = 0; j < 5; j++)
                {
                        Console.SetCursorPosition(cageLeftPos[j], firstCageRow); Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write($"Cage {j + 1}   "); Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(cageLeftPos[j], firstCageRow + 5); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write($"Cage {num + 1}" + "    "); Console.ForegroundColor = ConsoleColor.White;
                    num++;
                }
                #region Cage Area
                for (int i = 0; i < 10; i++)
                {
                    var query = e.Hamsters.Where(h => h.CageId == i + 1).ToList();
                    if (query != null && query.Count != 0)
                    {
                        if (i < 5)
                        {
                            if (query.Count == 0)
                            {
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                            }

                            if (query.Count == 1)
                            {
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write(query.ElementAt(0).Name+"    ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                            }
                            if (query.Count == 2)
                            {
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write(query.ElementAt(0).Name + "    ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write(query.ElementAt(1).Name + "    ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                            }
                            if (query.Count ==3)
                            {
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write("                   ");
                                Console.SetCursorPosition(cageLeftPos[i], 6); Console.Write(query.ElementAt(0).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[i], 7); Console.Write(query.ElementAt(1).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[i], 8); Console.Write(query.ElementAt(2).Name + "      ");
                            }
                        }
                        else if (i > 4)
                        {

                            if (query.Count == 1)
                            {
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write(query.ElementAt(0).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write("                 ");
                            }
                            if (query.Count == 2)
                            {
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write(query.ElementAt(0).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write(query.ElementAt(1).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write("                 ");
                            }
                            if (query.Count ==3 )
                            {
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write("                 ");
                                Console.SetCursorPosition(cageLeftPos[counter], 11); Console.Write(query.ElementAt(0).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[counter], 12); Console.Write(query.ElementAt(1).Name + "     ");
                                Console.SetCursorPosition(cageLeftPos[counter], 13); Console.Write(query.ElementAt(2).Name + "     ");
                            }
                                                   
                            counter++;
                        }
                    }
                }
                #endregion

                var hamsterInWellnessCenter = e.Hamsters.Where(h => h.WellnessCenterId == 1).ToList();
                Console.SetCursorPosition(50, 17);Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("Wellness Center"); Console.ForegroundColor = ConsoleColor.White;
                if (hamsterInWellnessCenter == null || hamsterInWellnessCenter.Count == 0)
                {
                    Console.SetCursorPosition(45, 19); Console.Write("             "); Console.SetCursorPosition(62, 19); Console.Write("             ");
                    Console.SetCursorPosition(45, 20); Console.Write("             "); Console.SetCursorPosition(62, 20); Console.Write("             ");
                    Console.SetCursorPosition(45, 21); Console.Write("             "); Console.SetCursorPosition(62, 21); Console.Write("             ");
                }

                if (hamsterInWellnessCenter != null && hamsterInWellnessCenter.Count != 0 && hamsterInWellnessCenter.Count == 6)
                {
                    Console.SetCursorPosition(45, 19); Console.Write(hamsterInWellnessCenter.ElementAt(0).Name + "        "); Console.SetCursorPosition(62, 19); Console.Write(hamsterInWellnessCenter.ElementAt(3).Name + "        ");
                    Console.SetCursorPosition(45, 20); Console.Write(hamsterInWellnessCenter.ElementAt(1).Name + "        "); Console.SetCursorPosition(62, 20); Console.Write(hamsterInWellnessCenter.ElementAt(4).Name + "        ");
                    Console.SetCursorPosition(45, 21); Console.Write(hamsterInWellnessCenter.ElementAt(2).Name + "        "); Console.SetCursorPosition(62, 21); Console.Write(hamsterInWellnessCenter.ElementAt(5).Name + "        ");
                }
            }
            );
        }
        public static void Loading1()
        { 


            string logo = @"

░                       ░░░▓▓▓▓▓▓▓▓██▓▓▓▓░░░░  
          ░░          ░░██▒▒░░  ██████████████░░░░████▒▒                          
      ▒▒░░          ▓▓░░▒▒████              ████░░▒▒▒▒                          
        ░░      ▒▒██░░██▒▒                      ▓▓██▒▒▓▓▓▓                      
        ░░    ░░▓▓░░▒▒                              ░░▒▒░░▓▓                    
            ██░░░░                                        ██▓▓░░               
          ▒▒▒▒▓▓                                            ▒▒▓▓               
        ░░▒▒▓▓                                              ░░░░██░░            
        ▓▓▓▓                                                  ▓▓░░██            
      ██░░░░                                                    ██░░▓▓          
    ██  ▓▓                    ░░                                  ██▒▒░░        
    ██░░▓▓              ▒▒▒▒▒▒▒▒▒▒                                ██░░░░      
  ▓▓░░██              ▒▒░░      ░░██                                ▓▓▓▓     
  ▓▓░░██            ▒▒▓▓░░      ░░████▒▒░░██▒▒░░                    ▓▓▒▒     
  ░░██            ██░░▒▒░░      ░░██░░░░░░░░░░▒▒██      ████        ░░▒▒██  
  ▒▒██          ▒▒░░░░░░░░      ▓▓░░░░░░░░░░░░░░░░▓▓▒▒██░░██        ░░▒▒██    
  ░░██        ▓▓▒▒░░▓▓░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░▒▒░░░░▓▓        ░░▒▒██  
  ▒▒██    ▒▒██  ░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒          ░░▒▒██  
  ░░██  ░░████  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██            ░░  ██  
  ░░██  ░░░░        ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓░░          ░░▒▒██  
  ░░██    ▒▒████░░      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓          ░░▒▒██  
  ░░██      ██▓▓▓▓      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓          ░░▒▒██  
  ▓▓▒▒██      ▓▓▓▓██      ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓          ▓▓▒▒      
  ▓▓  ██        ▒▒████░░▒▒░░░░▒▒░░            ▒▒░░░░░░░░░░██        ▓▓▓▓     
    ██▒▒▓▓            ▒▒▓▓░░░░▒▒░░░░░░░░░░░░▓▓▓▓░░░░░░░░░░▓▓░░    ██░░░░      
    ██  ▓▓            ░░░░░░▓▓░░░░░░░░░░  ░░    ░░░░▓▓██▒▒░░▒▒░░  ██▒▒░░        
      ██▒▒░░        ░░░░▒▒██                            ░░████░░██  ██        
        ▓▓▒▒        ░░██▒▒                                    ▓▓░░██         
        ░░▓▓▒▒                                                ▒▒▓▓░░          
    ████▓▓▒▒  ▓▓                                            ▒▒▓▓          
    ██░░▓▓  ▓▓░░▒▒░░                                  ░░░░▓▓▒▒               
  ▒▒░░▒▒▒▒▒▒  ▒▒▒▒░░▒▒                              ░░▓▓▒▒▒▒░░                
  ░░░░░░░░▒▒    ▒▒██▒▒██▒▒                      ████▒▒██▓▓                    
  ░░  ░░  ▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓░░   
  ░░░░░░  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓░░▒▒▒▒▒▒▒▒▒▒░░▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██";
            Console.SetCursorPosition(30, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(logo); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 8); Console.Write("Loading!!!");
            Console.SetCursorPosition(70, 10); Console.Write("Loading!!!");
            Console.SetCursorPosition(40, 13); Console.Write("Loading!!!");
            Console.SetCursorPosition(35, 15); Console.Write("Loading!!!");
            Console.SetCursorPosition(25, 23); Console.Write("Loading!!!");




        }
        public static void Loading2()
        {
            string logo = @"

     
  ▒▒▒▒          ██████░░  ████████████████▒▒  ░░████░░                    
      ░░        ▒▒    ░░████                ██████▒▒  ▓▓                    
       ░░░░      ▓▓▓▓████▓▓                        ░░████▒▒████                
     ░░      ▒▒░░▒▒                                    ▒▒░░░░██              
        ▓▓▒▒                                              ██░░▒▒          
           ░░░░▒▒                                                ▓▓▒▒          
          ▓▓▓▓                                                    ▓▓▓▓        
        ▒▒▒▒                                                      ▒▒░░▓▓      
      ░░▓▓▒▒                                                        ██▒▒██    
      ▓▓▓▓                                                            ██  ▒▒  
      ▓▓▓▓                                                            ██░░▒▒  
      ▒▒░░░░                                                            ░░██▒▒░░
      ▒▒▒▒░░                  ▒▒▒▒▒▒▒▒                                    ██▒▒░░
█  ░░▒▒▓▓                  ▒▒░░░░░░░░██                                    ▒▒▓▓
█    ██▓▓                ░░▒▒░░    ░░░░██                                  ▒▒▓▓
   ██▓▓              ░░░░▒▒        ░░██      ░░                          ██▓▓
  ░░▒▒▓▓            ▒▒▒▒▒▒▒▒        ░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒                    ██▓▓
   ▓▓▓▓          ▒▒░░░░░░░░░░    ░░██░░░░░░░░░░░░░░░░██░░██████▓▓        ▓▓▓▓
 ░░▓▓▓▓    ██▓▓  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░████            ▓▓▓▓
    ██▓▓    ████  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██              ▒▒▓▓
    ▒▒░░░░  ▓▓        ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██        ░░██▒▒░░
   ▒▒░░░░  ░░▒▒            ░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░██        ░░██▒▒░░
     ██▓▓    ░░██▓▓░░      ░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░██        ▓▓░░▒▒  
     ▓▓▓▓      ▒▒▓▓░░      ▓▓░░░░░░░░░░░░░░██░░░░░░░░░░░░░░██        ▓▓░░▒▒  
      ░░▒▒▒▒      ████████  ██░░░░██        ██░░░░░░░░░░░░██        ██░░██    
          ▒▒▒▒              ▓▓██░░░░██░░░░░░░░██░░░░░░░░░░░░▓▓        ▒▒▓▓      
           ░░▒▒▒▒              ██░░▒▒░░░░  ░░░░░░▓▓▓▓░░░░░░▓▓        ▒▒▒▒░░      
        ████▒▒▒▒▒▒            ██░░▒▒                ████░░▓▓      ██▓▓          
            ▓▓▓▓  ▒▒▒▒░░          ██░░▒▒                ░░██▒▒░░░░░░▓▓░░░░          
      ▒▒▒▒░░▒▒  ▒▒▒▒▒▒        ██▒▒░░                  ██▒▒▒▒▒▒▓▓▓▓░░            
  ▒▒░░░░▒▒    ██░░████▓▓                          ████░░████                
   ▒▒░░░░▒▒▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒░░░░▒▒░░░░░░░░░░▒▒▒▒▓▓▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒
  ░░░░░░  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓░░▒▒▒▒▒▒▒▒▒▒░░▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██";
            Console.SetCursorPosition(30, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(logo); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45, 8); Console.Write("Loading!!!");
            Console.SetCursorPosition(70, 18); Console.Write("Loading!!!");
            Console.SetCursorPosition(20, 13); Console.Write("Loading!!!");
            Console.SetCursorPosition(30, 15); Console.Write("Loading!!!");
            Console.SetCursorPosition(25, 20); Console.Write("Loading!!!");

        }
        public static void Loading3() 
        { 
            string logo = @"

                            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                 
                        ▒▒████░░░░▒▒  ▒▒  ▒▒████                         
    ░░░░░░          ▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒                                  
    ░░░░░░      ░░▒▒▒▒▒▒▒▒░░░░              ░░░░▒▒▓▓▒▒▒▒▒▒                    
        ░░    ░░░░▒▒▓▓                              ▒▒░░▒▒██                      
    ░░░░░░  ░░▒▒▒▒▒▒                                  ▒▒▒▒▒▒▒▒               
          ░░░░▓▓                                          ░░▒▒▒▒               
        ░░▒▒██                                              ▒▒░░██                  
        ▓▓▓▓                                                  ▓▓░░██                
      ▒▒▒▒▒▒                                                  ░░▓▓▒▒▒▒              
    ██▒▒▓▓                                                        ██░░░░         
    ██  ██                                                        ██▒▒             
    ██░░▒▒                                                        ▓▓░░▒▒           
  ▓▓  ██                                                            ▓▓▓▓             
  ██  ██                                                            ▓▓▒▒                
  ▒▒██                                                              ░░▒▒██              
  ░░██                        ██████▒▒                              ░░░░██             
  ▒▒██                      ██░░░░░░▒▒                              ░░▒▒██          
  ░░██                    ▓▓░░░░    ░░▓▓                            ░░▒▒██             
  ▒▒██                  ████░░      ░░████████▒▒                    ░░▒▒██            
  ░░██                ▒▒░░▓▓░░        ▓▓░░░░░░▒▒██▓▓                ░░▒▒██             
  ░░██              ░░▒▒░░░░░░░░    ▒▒░░░░░░░░░░░░░░▒▒░░            ░░▒▒██           
  ▓▓  ██      ░░██  ░░▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒░░██████░░    ▓▓▓▓               
  ▓▓░░██      ▓▓██  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░░░▒▒░░    ▓▓▓▓               
    ██  ▓▓    ▓▓        ░░░░░░░░░░░░░░░░░░░░██▒▒░░░░░░██▓▓        ██▒▒░░               
    ██  ▓▓    ░░░░        ░░░░░░░░░░░░░░████░░░░░░░░░░██          ██░░               
    ▓▓▒▒▒▒    ░░▓▓          ░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░▓▓        ░░▓▓░░░░                
      ░░▒▒▒▒    ░░▒▒▒▒▒▒      ░░░░░░░░▓▓░░░░░░░░░░░░▒▒        ▒▒░░▓▓░░                    
        ▓▓▓▓        ▓▓        ░░░░██░░▓▓░░░░░░░░░░░░▒▒        ▓▓  ██                     
        ░░▒▒██      ░░████░░  ▒▒░░██  ▓▓░░░░░░░░░░░░▒▒      ░░▒▒▓▓                   
    ██▓▓▓▓▒▒░░▓▓          ▒▒▓▓▒▒░░░░▒▒██░░░░░░░░░░▓▓        ▒▒▓▓                     
  ▓▓██████░░  ▓▓▒▒██          ▒▒░░░░▒▒░░▒▒░░░░▒▒      ████▒▒▒▒                        
  ░░░░░░  ▒▒  ░░▒▒▒▒▒▒░░        ▒▒░░▒▒▓▓░░░░▒▒  ░░░░▒▒░░░░▓▓                           
  ░░  ░░░░▒▒▒▒▒▒▓▓██▒▒▒▒▒▒▒▒▒▒    ░░▓▓▓▓▒▒░░▒▒▒▒▓▓▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒██           
  ░░░░    ██▒▒▒▒▒▒▒▒▓▓██▒▒▒▒  ██████████████▒▒  ████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██       
  ░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████▒▒░░░░▒▒░░▒▒░░████▓▓▓▓▓▓▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓    ";
            Console.SetCursorPosition(30, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(logo); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(55, 8); Console.Write("Loading!!!");
            Console.SetCursorPosition(80, 10); Console.Write("Loading!!!");
            Console.SetCursorPosition(40, 13); Console.Write("Loading!!!");
            Console.SetCursorPosition(35, 15); Console.Write("Loading!!!");
            Console.SetCursorPosition(25, 5); Console.Write("Loading!!!");
        }
        public static void Logo()
        {
            string logo = @"
██████████                ████████          
      ██░░░░░░░░░░██            ██░░░░░░░░██        
    ██░░░░░░░░░░░░░░██        ██░░░░░░░░░░░░██      
  ██░░████░░░░░░░░░░██████████████░░░░░░░░██░░██    
  ██      ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░██  ░░██    
  ██      ██░░      ░░░░░░░░░░░░░░░░░░░░██  ░░██    
  ██░░  ░░            ░░░░░░░░░░░░░░░░░░░░██░░██    
    ████                  ░░░░░░░░░░░░░░░░████      
      ██      ██████            ░░░░██████  ██      
      ██    ████    ██            ██    ██████      
      ██    ████    ██            ██    ████░░██    
    ██      ██████████            ██████████  ██    
  ████████░░  ██████        ░░██    ██████  ░░██████
    ██░░                                      ██    
    ██████░░                              ░░██████  
  ████                ██    ██    ██        ░░██    
    ██░░░░              ████  ████          ██      
    ██░░░░░░░░                            ████      
  ████░░░░        ██                ██    ░░██      
██░░██░░        ░░  ██            ██        ██      
  ████        ██░░░░██            ██    ██  ██      
    ████        ████                ████  ██        
      ████░░██    ░░░░░░░░            ░░██          
      ██░░░░░░██████████████████████░░░░░░██        
        ██████                      ██████     ";

            Console.SetCursorPosition(30, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(logo); Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(55, 8); Console.Write("Hamster!");
            Console.SetCursorPosition(80, 10); Console.Write("Hamster!");
            Console.SetCursorPosition(40, 13); Console.Write("Hamster!");
            Console.SetCursorPosition(35, 15); Console.Write("Hamster!");
            Console.SetCursorPosition(25, 5); Console.Write("Hamster!");



        }
        public static void Logo2()
        {
            string logo = @"
████████                  ████████      
          ██▒▒▒▒▒▒▒▒██              ██▒▒▒▒▒▒▒▒██    
        ██▒▒▒▒▒▒▒▒▒▒▒▒██          ██▒▒▒▒▒▒▒▒▒▒▒▒██  
      ██  ████▒▒▒▒▒▒▒▒██████████████▒▒▒▒▒▒▒▒████  ██
      ██      ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██      ██
      ██      ██      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██      ██
      ██    ██            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██    ██
        ████                  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████  
      ██████████████████████████████████████████    
  ████    ██  ██▒▒██▒▒██████      ██▒▒██▒▒██████    
        ██      ██▒▒██▒▒██          ██▒▒██▒▒██▒▒██  
        ████      ██████    ██        ██████  ████  
        ██                                      ██  
        ████          ██    ██    ██          ████  
        ██              ████  ████              ██  
          ██                                  ██    
          ████                              ████    
          ██        ██              ██        ██    
          ██          ██          ██          ██    
          ██    ██    ██          ██    ██    ██    
          ██      ████              ████      ██    
            ██                              ██      
          ██████                          ██████    
        ██    ██████████████████████████████    ██  
          ████                              ████   ";

            Console.SetCursorPosition(30, 7); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(logo); Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(60, 8); Console.Write("Thug Life!");
            Thread.Sleep(200);
            Console.SetCursorPosition(70, 10); Console.Write("Thug Life!");
            Thread.Sleep(300);
            Console.SetCursorPosition(40, 13); Console.Write("Thug Life!");
            Thread.Sleep(250);
            Console.SetCursorPosition(50, 15); Console.Write("Thug Life!");
            Thread.Sleep(100);
            Console.SetCursorPosition(85, 5); Console.Write("Thug Life!");
        }

    }

  
}
