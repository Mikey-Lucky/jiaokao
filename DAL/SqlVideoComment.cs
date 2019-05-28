﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    public class SqlVideoComment : IVideoComment
    {
        yichuEntities db = DbContextFactory.CreateDbContext();

        public IEnumerable<VideoComment> allvideocomment(int videoid)
        {
            var comment = from c in db.VideoComment
                          where c.VideoID == videoid
                          select c;
            return comment;
        }
        public void AddVideoComment(VideoComment videocomment)
        {
            db.VideoComment.Add(videocomment);
            db.SaveChanges();
        }
    }
}
