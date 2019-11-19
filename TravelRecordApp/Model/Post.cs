using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Post
    {
        /// <summary>
        /// Defining the table attribute to model
        /// </summary>
        /// defining the primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)] /// defining the maximum length of the experience colum
        public string Experience { get; set; }

    }
}
