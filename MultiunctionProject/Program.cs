using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiunctionProject
{

    public interface ICollapsed
    {
        void Collapse(ICollapsed y);
    }

    public class Ship
    {
        public virtual void Collapse(Asterod asteroid)
        {
            asteroid.Collapse(this);
        }

        public virtual void Collapse(Stantion stantion)
        {
            stantion.Collapse(this);
        }

        public virtual void Collapse(AsteroidA ship) { }

        public virtual void Collapse(AsteroidB ship) { }

        public virtual void Collapse(StantionA ship) { }

        public virtual void Collapse(StantionB ship) { }
    }

    public class ShipA : Ship
    {
        public override void Collapse(AsteroidA ship)
        {
            Console.WriteLine("AsteroidA collapse ShipA");
        }

        public override void Collapse(AsteroidB ship)
        {
            Console.WriteLine("AsteroidB collapse ShipA");
        }

        public override void Collapse(StantionA ship)
        {
            Console.WriteLine("StantionA collapse ShipA");
        }

        public override void Collapse(StantionB ship)
        {
            Console.WriteLine("StantionB collapse ShipA");
        }
    }

    public class ShipB : Ship
    {
        public override void Collapse(AsteroidA ship)
        {
            Console.WriteLine("AsteroidA collapse ShipB");
        }

        public override void Collapse(AsteroidB ship)
        {
            Console.WriteLine("AsteroidB collapse ShipB");
        }

        public override void Collapse(StantionA ship)
        {
            Console.WriteLine("StantionA collapse ShipB");
        }

        public override void Collapse(StantionB ship)
        {
            Console.WriteLine("StantionB collapse ShipB");
        }
    }

    public class Asterod
    {
        public virtual void Collapse(Stantion stantion)
        {
            stantion.Collapse(this);
        }

        public virtual void Collapse(Ship ship)
        {
            ship.Collapse(this);
        }

        public virtual void Collapse(ShipA ship){}

        public virtual void Collapse(ShipB ship){}

        public virtual void Collapse(StantionA ship) { }

        public virtual void Collapse(StantionB ship) { }
    }

    public class AsteroidA : Asterod
    {
        public override void Collapse(ShipA ship)
        {
            Console.WriteLine("ShipA collapse AsteroidA");
        }

        public override void Collapse(ShipB ship)
        {
            Console.WriteLine("ShipB collapse AsteroidA");
        }

        public override void Collapse(StantionA stantion)
        {
            Console.WriteLine("StantionA collapse AsteroidA");
        }

        public override void Collapse(StantionB stantion)
        {
            Console.WriteLine("StantionB collapse AsteroidA");
        }
    }

    public class AsteroidB :Asterod
    {
        public override void Collapse(ShipA ship)
        {
            Console.WriteLine("ShipA collapse AsteroidB");
        }

        public override void Collapse(ShipB ship)
        {
            Console.WriteLine("ShipB collapse AsteroidB");
        }

        public override void Collapse(StantionA stantion)
        {
            Console.WriteLine("StantionA collapse AsteroidB");
        }

        public override void Collapse(StantionB stantion)
        {
            Console.WriteLine("StantionB collapse AsteroidB");
        }
    }

    public class Stantion
    {
        public virtual void Collapse(Asterod asteroid)
        {
            asteroid.Collapse(this);
        }

        public virtual void Collapse(Ship ship)
        {
            ship.Collapse(this);
        }

        public virtual void Collapse(ShipA ship) { }

        public virtual void Collapse(ShipB ship) { }

        public virtual void Collapse(AsteroidA ship) { }

        public virtual void Collapse(AsteroidB ship) { }
    }

    public class StantionA : Stantion
    {
        public override void Collapse(ShipA ship)
        {
            Console.WriteLine("ShipA collapse StantionA");
        }

        public override void Collapse(ShipB ship)
        {
            Console.WriteLine("ShipB collapse StantionA");
        }

        public override void Collapse(AsteroidA asteroid)
        {
            Console.WriteLine("AsteroidA collapse StantionA");
        }

        public override void Collapse(AsteroidB asteroid)
        {
            Console.WriteLine("AsteroidB collapse StantionA");
        }
    }

    public class StantionB : Stantion
    {
        public override void Collapse(ShipA ship)
        {
            Console.WriteLine("ShipA collapse StantionB");
        }

        public override void Collapse(ShipB ship)
        {
            Console.WriteLine("ShipB collapse StantionB");
        }

        public override void Collapse(AsteroidA asteroid)
        {
            Console.WriteLine("AsteroidA collapse StantionB");
        }

        public override void Collapse(AsteroidB asteroid)
        {
            Console.WriteLine("AsteroidB collapse StantionB");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new ShipB();
            Stantion stantion = new StantionA();
            Asterod asteroid = new AsteroidB();

            ship.Collapse(stantion);
            ship.Collapse(asteroid);
            asteroid.Collapse(ship);
            asteroid.Collapse(stantion);
        }
    }
}
