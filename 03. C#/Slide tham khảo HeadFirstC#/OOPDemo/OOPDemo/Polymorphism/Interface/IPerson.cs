using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo.Interface
{
    public interface IPerson
    {
        string Name { get; set; } // property Name

        DateTime DateOfBirth { get; set; } // property DateOfBirth

        int Age { get; } // property Age (read-only)

    }

}
