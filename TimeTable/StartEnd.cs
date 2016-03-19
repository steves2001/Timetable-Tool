using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTable
{
    public class StartEnd
    {
        public int id;
        public float start;
        public float end;
        public int row;

        public StartEnd()
        {
            this.id = 0;
            this.start = 0f;
            this.end = 0f;
            this.row = 0;
        }

        public StartEnd(int i, float s, float e, int r)
        {
            this.id = i;
            this.start = s;
            this.end = e;
            this.row = r;

        }
    }
}
