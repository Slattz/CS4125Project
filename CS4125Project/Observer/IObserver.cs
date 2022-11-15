using System.Collections.Generic;

namespace CS4125Project.Observer
{

    public interface IObserver
    {

        void Update(ISubject subject);
    
    }
}
