using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bad
{
    public interface IPhoneOperator_Bad
    {
        // This is against the SRP (at the method level):
        void CallPoliceAndAmbulance();

        void CallPoliceAndAmbulanceAndFireFighters();
    }
}
