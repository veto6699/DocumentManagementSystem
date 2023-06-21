﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared
{
    public class MediaType
    {
        public Schema Schema { get; set; }
        public object Example { get; set; }
        public Example Examples { get; set; }
        public EncodingOpenAPI Encoding { get; set; }
    }
}
