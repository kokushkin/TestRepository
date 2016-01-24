using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApplication4
{
    
    public class ExperPeople
    {
        public string Name;
        public int Year;
    }

    public class ExperManthPeople : ExperPeople
    {
        public int Manth;
    }


    public interface IExperContainer<out T>
    {

        //T[] OurPeople { get; set; }
        //T OurPeople { get; set; }
        T[] GetPeople();
        //List<T> OurPeople { get; set; }

        T GetOldestPeople();


    }

    public class ExperContainerPeople<Tp> : IExperContainer<Tp> where Tp : ExperPeople
    {
        public string Coutry { get; set; }

        //public Tp[] OurPeople { get; set; }
        //public Tp OurPeople { get; set; }
        public List<Tp> OurPeople { get; set; }

        public Tp[] GetPeople()
        {
            return OurPeople.ToArray();
        }

        //List<Tp> OurPeople { get; set; }

        public virtual Tp GetOldestPeople()
        {
            return OurPeople.OrderBy(o => o.Year).FirstOrDefault();
        }
    }

    public class ExperContainerManthPeople<Tmp> : ExperContainerPeople<Tmp>, IExperContainer<Tmp> where Tmp : ExperManthPeople
    {
        public string Town { get; set; }

        public override Tmp GetOldestPeople()
        {
            return OurPeople.OrderBy(o => o.Year).ThenBy(o => o.Manth).FirstOrDefault();
        }

    }

}
