using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class FunctionsContainer
    {
        List<string> funcNameList = new List<string>();
        public delegate double CalcDelegate(double value);
        private Dictionary<string, CalcDelegate> container
                     = new Dictionary<String, CalcDelegate>();

        public CalcDelegate this[string idx]
        {
            get
            {
                if (container.ContainsKey(idx))
                {
                    return container[idx];
                }
                else
                {
                    //add to the functions name list
                    funcNameList.Add(idx);
                    //make it the ID func
                    container[idx] = (x) => x;
                    return container[idx];
                }

            }

            set
            {
                //add the value given
                container[idx] = value;
                //if list doesnt contain a key with this string
                if (!funcNameList.Contains(idx))
                {
                    funcNameList.Add(idx);
                }

            }
        }
        public List<string> getAllMissions()
        {
            return funcNameList;
        }

    }
}
