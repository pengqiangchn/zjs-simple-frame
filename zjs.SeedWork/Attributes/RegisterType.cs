using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.SeedWork.Enum;

namespace zjs.SeedWork.Attributes
{
    public sealed class RegisterType : Attribute
    {
        public RegisterTypeEnum Type { get; }

        public RegisterType(RegisterTypeEnum type)
        {
            Type = type;
        }
    }
}
