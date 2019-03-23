using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        const string COMPOSED = "Composed";

        //fields
        private String m_name;
        private List<func> m_funcList;

        //C'tor
        public ComposedMission(String name)
        {
            this.m_name = name;
            this.m_funcList = new List<func>();
        }

        //implement the interface
        string IMission.Name
        {
            get { return m_name; }
        }

        string IMission.Type
        {
            get { return COMPOSED; }
        }

        //an Event of when a mission is activated
        public event EventHandler<double> OnCalculate;

        public ComposedMission Add(func function)
        {
            this.m_funcList.Add(function);
            return this;
        }

        //calculate the result of the mission
        public double Calculate(double value)
        {
            double result = value;
            int funcListLength = this.m_funcList.Count;
            for(int i = 0; i < funcListLength; i++)
            {
                result = this.m_funcList[i](result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
