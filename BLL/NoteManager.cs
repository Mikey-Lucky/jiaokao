using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class NoteManager
    {
        
        INote inote = DataAccess.CreateNote();
        public IEnumerable<Note> GetHotNote(int top)
        {
            var hotnote = inote.Gethotnote(top);
            return hotnote;
        }

    }
}
