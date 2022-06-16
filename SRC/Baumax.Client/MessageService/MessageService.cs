using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.MessageService
{

    public delegate void ChangeLanguage();

    public delegate void UserLogon();

    public delegate void UserLogout();

    public class MessageService
    {

        public static event ChangeLanguage OnChangeLanguage = null;

        public static event UserLogon OnUserLogon = null;

        public static event UserLogout OnUserLogout = null;


    }
}
