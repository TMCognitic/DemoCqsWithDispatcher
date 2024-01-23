using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Commands
{
    internal class CommandResult : ResultBase, ICommandResult
    {
        internal CommandResult(bool isSuccess, string? errorMessage = null)
            : base(isSuccess, errorMessage)
        {
        }
    }
}
