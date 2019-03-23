using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{ 
    public class SingleMission : IMission
    {
        const string SINGLE = "Single";

        //fields
        private func m_function;
        private String m_name;

        //C'tor
        public SingleMission(func function, String name)
        {
            this.m_function = function;
            this.m_name = name;
        }

        string IMission.Name {
            get { return m_name; }
        }

        string IMission.Type
        {
            get { return SINGLE; }
        }

        //an Event of when a mission is activated
        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double result =  this.m_function(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}