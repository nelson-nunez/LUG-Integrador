using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPersona
    {
        private MPPPersona oMPPPersona;

        public BLLPersona()
        {
            oMPPPersona = new MPPPersona();
        }

        public Persona Login(string email, string password)
        {
            return oMPPPersona.Login(email, password);
        }
    }
}
