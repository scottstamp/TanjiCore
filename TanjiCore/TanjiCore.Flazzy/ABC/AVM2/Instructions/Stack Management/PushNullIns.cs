﻿using System;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class PushNullIns : Primitive
    {
        public override object Value
        {
            get { return null; }
            set { throw new NotSupportedException(); }
        }

        public PushNullIns()
            : base(OPCode.PushNull)
        { }
    }
}