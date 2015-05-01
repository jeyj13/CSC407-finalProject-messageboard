using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC407_Final.Services.Posting
{
    interface IPostServices
    {

        List<Thread> GetThreads();

        List<Thread> GetThreadByTitle(string title);
        Thread GetThreadById(int id);

        void SaveThread(Thread thread);

        void DeleteThread(int id);

        List<Comment> GetComments(int id);


        void SaveComment(Comment comment);

        void DeleteComment(int id);


        
    }
}
