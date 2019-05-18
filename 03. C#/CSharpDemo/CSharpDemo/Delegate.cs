using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemo
{
    public class TestEvent
    {
        public delegate void StringParse();

        public event EventHandler ExecuteCompleted;

        public event Action<int> ActionCompleted;

        public Func<int, int, bool> CompareTwoNumber;

        public void Execute()
        {
            EventArgs e = new EventArgs() { };
            OnExecuteCompleted(e);
            if (ActionCompleted != null)
            {
                ActionCompleted(this.GetHashCode());
            }
        }

        protected virtual void OnExecuteCompleted(EventArgs e)
        {
            if (this.ExecuteCompleted != null) { }
            {
                this.ExecuteCompleted(this, e);
            }
        }
    }

    
}
