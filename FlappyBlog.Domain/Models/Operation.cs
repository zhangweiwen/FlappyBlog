using System.Collections.Generic;

namespace FlappyBlog.Domain.Models
{
    public partial class Operation
    {
         public string Name { get; set; }

         public string Description { get; set; }
    }

    public partial class Operation
    {
        public static readonly List<Operation> All = new List<Operation>();

        static Operation()
        {
            All.Add(new Operation {});
        }
    }
}