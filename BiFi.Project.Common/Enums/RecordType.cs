using System.ComponentModel;

namespace BiFi.Project.Common.Enums
{
    public enum RecordType : byte
    {
        [Description("#Customer Card")]
        Customer = 1,
        [Description("#Province Card")]
        Province = 2,
        [Description("#Country Card")]
        Country = 3,
        [Description("#Uom Card")]
        Uom = 4,
        [Description("#Account Card")]
        Account = 5
  }
}