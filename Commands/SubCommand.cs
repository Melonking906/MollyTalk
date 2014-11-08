using SharpStar.Lib.Attributes;
using SharpStar.Lib.Plugins;
using SharpStar.Lib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollyTalk.Commands
{
    abstract class SubCommand
    {
        public readonly string _name;
        public readonly string _permission;

        public SubCommand(string name, string permission)
        {
            _name = name;
            _permission = permission;
        }

        public abstract void OnCommand(SharpStarClient client, string[] args);
    }
}
