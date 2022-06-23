using System;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Walks
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string WalkerName { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }
        public string ClientName { get; set; }

        //public int TotalWalkTime { get
        //    {
        //        int numOfMins = Duration / 60;
        //        int numOfHrs = 
        //    } }
    }
}
