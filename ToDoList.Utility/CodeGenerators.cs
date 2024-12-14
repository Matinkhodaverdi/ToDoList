using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Utility
{
    public static class CodeGenerators
    {
        public static string GetActiveCode()
        {
            Random random = new Random();
            return random.Next(100000, 990000).ToString();

        }

        public static Guid GetId()
        {
            return Guid.NewGuid();

        }

       

    }
}
