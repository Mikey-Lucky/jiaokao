using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INote
    {
        //热门帖子
        IEnumerable<Note> Gethotnote(int top);
    }
}
