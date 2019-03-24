using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class ComposedMission : IMission
    {
        private string name;
        private string type;
        public event EventHandler<double> OnCalculate;
        private FunctionsContainer.CalcDelegate func;
        List<FunctionsContainer.CalcDelegate> listOfDelegates = new List<FunctionsContainer.CalcDelegate>();

        public ComposedMission(string name)
        {
            this.name = name;
            this.type = "Composed";
        }

        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.Name = name;
            }
        }

        public String Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.Type = type;
            }
        }

        public ComposedMission Add(FunctionsContainer.CalcDelegate del)
        {
            this.listOfDelegates.Add(del);
            return this;
        }
        public double Calculate(double value)
        {
            double val = value;
            //for each delegate in our list
            foreach (FunctionsContainer.CalcDelegate element in listOfDelegates)
            {
                //val is the result of delegate
                val = element(val);
            }
            //if exists, invoke
            OnCalculate?.Invoke(this, val);
            return val;
        }
    }
}