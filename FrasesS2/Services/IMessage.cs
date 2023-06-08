using System;
using System.Collections.Generic;
using System.Text;

namespace FrasesS2.Services
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
