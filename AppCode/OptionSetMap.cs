using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteComponentTransporter.AppCode {
    class OptionSetMap {
        public OptionSetMap (string name, int? value) {
            Name = name;
            Value = value == null ? -1 : value.Value;
        }

        public string Name { get; private set; }
        public int Value { get; private set; }
    }
}
