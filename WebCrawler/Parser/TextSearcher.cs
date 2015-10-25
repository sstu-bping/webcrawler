using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    class TextSearcher
    {
        private int _position;
        private string _text;

        public int get_p(){
            return _position;
        }

        public TextSearcher(string text)
        {
            _text = text;
        }

        public void Skip(string text)
        {

            int p = _text.IndexOf(text, _position);
            if (p > -1)
            {
                _position = p + text.Length;
            }
        }

        public string ReadTo(string text)
        {
            int p = _text.IndexOf(text, _position);
            string result = "";

            if (p > -1)
            {
                result = _text.Substring(_position, (p - _position));
                _position = p;
            }

            return result;
        }
    }
}
