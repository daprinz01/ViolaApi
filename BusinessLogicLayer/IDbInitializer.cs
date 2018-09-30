using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IDbInitializer
    {
         void Initialize();
         Task CreateRoleAsync();
    }
}
