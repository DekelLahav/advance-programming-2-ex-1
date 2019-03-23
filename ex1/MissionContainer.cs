using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double func(double num);

    public class FunctionsContainer
    {
        //field
        private Dictionary<string, func> functionContainer;
        private List<string> allFuncsAvailable;

        //C'tor
        public FunctionsContainer()
        {
            this.functionContainer = new Dictionary<string, func>();
            this.allFuncsAvailable = new List<string>();
        }

        //indexer
        public func this[string funcName]
        {
            get
            {
                //in case the key exist
                if (this.functionContainer.ContainsKey(funcName))
                {
                    return this.functionContainer[funcName];
                }
                //in case the key doesn't exist
                this.functionContainer.Add(funcName, num => num);
                allFuncsAvailable.Add(funcName);
                return num => num;
            }

            set
            {
                //in case the key exist
                if(this.functionContainer.ContainsKey(funcName))
                {
                    functionContainer[funcName] = value;
                }
                //in case the key doesn't exist
                else
                {
                    functionContainer.Add(funcName, value);
                    allFuncsAvailable.Add(funcName);
                }
            }
        }

        //returns a list of all function available
        public List<string> getAllMissions()
        {
            return this.allFuncsAvailable;
        }
    }
}
