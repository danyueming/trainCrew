using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using trainCrew.Models;
using trainCrew.Models.Train;

namespace trainCrew.DAL
{
    public class TrainInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<TrainContext>
    {
        protected override void Seed(TrainContext context)
        {

            var systemusers = new List<SystemUser>
                {
                     new SystemUser{Name="张豪",Password="123456"},
                     new SystemUser{Name="11",Password="22222222"},
                     new SystemUser{Name="赵亮",Password ="22222222"},
        
                };

            systemusers.ForEach(s => context.SystemUsers.Add(s));
            context.SaveChanges();

            var driverteams = new List<DriverTeam>        //先初始化机队
            {
                new DriverTeam{ DriverTeamID=101,TeamName="电车一队",GroupNumber =3,remark="无"},
                new DriverTeam{ DriverTeamID=102,TeamName="电车二队",GroupNumber =3,remark="无"},
                new DriverTeam{ DriverTeamID=103,TeamName="电车三队",GroupNumber =3,remark="无"},
                new DriverTeam{ DriverTeamID=104,TeamName="电车四队",GroupNumber =4,remark="无"},
                new DriverTeam{ DriverTeamID=105,TeamName="电车五队",GroupNumber =4,remark="无"},
                new DriverTeam{ DriverTeamID=106,TeamName="电车六队",GroupNumber =4,remark="无"},
               
            };
            driverteams.ForEach(r => context.DriverTeams.Add(r));
            context.SaveChanges();


            var drivergroups = new List<DriverGroup>  //再初始化机班
            {
                new DriverGroup{ DriverGroupID=1001,DriverTeamID=101,DriverGroupName="第一班",GroupPeople = 5},
                new DriverGroup{ DriverGroupID=1002,DriverTeamID=101,DriverGroupName="第二班",GroupPeople = 5},
               

                new DriverGroup{ DriverGroupID =1003,DriverTeamID=102,DriverGroupName="第三班",GroupPeople = 2},
                new DriverGroup{DriverGroupID =1004,DriverTeamID=102,DriverGroupName="第四班",GroupPeople = 2},
              
               
           
            };
            drivergroups.ForEach(g => context.DriverGroups.Add(g));
            context.SaveChanges();


            var drivers = new List<Driver>
            {
                new Driver {DriverID =1,DriverGroupID=1003,DriverName = "张三",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="主司机" },
                new Driver {DriverID =2,DriverGroupID=1003,DriverName = "张四",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="主司机"},
                new Driver {DriverID =3,DriverGroupID=1002,DriverName = "张三",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="主司机" },
                new Driver {DriverID =4,DriverGroupID=1004,DriverName = "李三",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="副司机" },
                new Driver {DriverID =5,DriverGroupID=1001,DriverName = "李四",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="副司机" },
                new Driver {DriverID =6,DriverGroupID=1002,DriverName = "李五",Birthday = DateTime.Parse("1968-02-03"),Sex=Sex.man,DriveType ="副司机" }
               
            
            };
              drivers.ForEach(s => context.Drivers.Add(s));
               context.SaveChanges();


          var stations = new List<Station>
           {
               new Station { StationID=1, StationName = "name1",RestAllowed = true },
               new Station { StationID=2, StationName = "name2",RestAllowed = false },
               new Station { StationID=3, StationName = "name3",RestAllowed = true },
               new Station { StationID=4, StationName = "name4",RestAllowed = true },
               new Station { StationID=5, StationName = "name5",RestAllowed = true },

            
           };
               stations.ForEach(s => context.Stations.Add(s));
               context.SaveChanges();

         var trips = new List<Trip>
           {
             new Trip{Line = "line1",InitTime= new TimeSpan(6,0,0),InitStation = stations[0], EndStation = stations[1] , EndTime =new TimeSpan(6,10,0) },
             new Trip{Line = "line1",InitTime= new TimeSpan(6,15,0),InitStation = stations[1], EndStation = stations[2] , EndTime =new TimeSpan(6,35,0) },
             new Trip{Line = "line1",InitTime= new TimeSpan(6,40,0),InitStation = stations[2], EndStation = stations[3] , EndTime =new TimeSpan(7,0,0) },
             new Trip{Line = "line1",InitTime= new TimeSpan(7,5,0),InitStation = stations[3], EndStation = stations[4] , EndTime =new TimeSpan(7,20,0) }
           
           };
               trips.ForEach(s => context.Trips.Add(s));
               context.SaveChanges();

            





        }




    }
}