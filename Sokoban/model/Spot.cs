using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Spot
    {
        protected Char _sym;
        protected int _x, _y;

        //constructor
        public Spot(int x, int y, Char sym) {
            this._x = x;
            this._y = y;
            this._sym = sym;

        }

        public virtual int getX()
        {
            return _x;
        }

        public virtual int getY()
        {
            return _y;
        }

        public virtual Char getSym()
        {
            return _sym;
        }

    }
}
