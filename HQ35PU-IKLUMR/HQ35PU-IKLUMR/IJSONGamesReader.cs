using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HQ35PUIKLUMR.Model;

namespace HQ35PUIKLUMR
{
    internal interface IJSONGamesReader
    {
        List<Game> Read(string jsonPath);
    }
}
