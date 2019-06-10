﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    public class SqlNoteComment : INoteComment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();
        public void AddNoteComment(NoteComment notecomment)
        {
            db.NoteComment.Add(notecomment);
            db.SaveChanges();
        }

        public IEnumerable<NoteComment> allnotecomment(int noteid)
        {
            
            var comment = from c in db.NoteComment
                          where c.NoteID == noteid
                          select c;
            return comment;
        }
    }
}
