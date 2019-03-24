using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class SingleMission : IMission
    {
        private string name;
        private string type;
        public event EventHandler<double> OnCalculate;
        private FunctionsContainer.CalcDelegate func;

        public SingleMission(FunctionsContainer.CalcDelegate givenFunc, string name)
        {
            this.func = givenFunc;
            this.name = name;
            this.type = "Single";
        }

        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                Name = name;
            }
        }

        public String Type
        {
            get
            {
                return type;
            }

            set
            {
                Type = type;
            }
        }
        public double Calculate(double value)
        {
            double val = func(value);
            OnCalculate?.Invoke(this, val);
            //if exists, invoke
            return val;
        }
    }
}
