using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PU_IKLUMR.Model;

namespace HQ35PU_IKLUMR
{
    internal interface IJSONGamesReader
    {
        List<Game> Read(string jsonPath);
    }
}
