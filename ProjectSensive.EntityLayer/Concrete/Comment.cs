using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSensive.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentDetail { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
    }
}
