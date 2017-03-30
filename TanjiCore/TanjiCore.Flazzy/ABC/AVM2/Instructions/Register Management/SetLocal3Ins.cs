﻿using System;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class SetLocal3Ins : Local
    {
        public override int Register
        {
            get { return 3; }
            set { throw new NotSupportedException(); }
        }

        public SetLocal3Ins()
            : base(OPCode.SetLocal_3)
        { }
    }
}