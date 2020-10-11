using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime Created_at { get; set; }
        DateTime Updated_at { get; set; }
    }
}
