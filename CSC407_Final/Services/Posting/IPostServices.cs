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

        void CreateThread(Thread thread);
        void DeleteThread(Thread thread);
        void CreateComment(Comment comment);
        void DeleteComment(Comment comment);


        
    }
}
