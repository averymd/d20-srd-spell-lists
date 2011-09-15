using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace d20_SRD_Spell_Lists.Exceptions {
    public class NoCharacterFileException : Exception {

        public NoCharacterFileException(string message)
            : base(message) {
        }
    }
}
