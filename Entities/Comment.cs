using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
