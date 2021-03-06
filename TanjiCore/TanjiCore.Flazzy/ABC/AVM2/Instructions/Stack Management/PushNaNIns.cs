﻿using System;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class PushNaNIns : Primitive
    {
        public override object Value
        {
            get { return double.NaN; }
            set { throw new NotSupportedException(); }
        }

        public PushNaNIns()
            : base(OPCode.PushNan)
        { }
    }
}