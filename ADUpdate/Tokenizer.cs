using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADUpdate
{
    public class Tokenizer
    {
        private readonly StringReader _reader;
        private string _text;

        public Tokenizer(string text)
        {
            _text = text;
            _reader = new StringReader(text);
        }

        public IEnumerable<Token> Tokenize()
        {
            var tokens = new List<Token>();
            while (_reader.Peek() != -1)
            {
                while (Char.IsWhiteSpace((char)_reader.Peek()))
                {
                    _reader.Read();
                }

                if (_reader.Peek() == -1)
                    break;

                var c = (char)_reader.Peek();
                switch (c)
                {
                    case '!':
                        tokens.Add(new NegationToken());
                        _reader.Read();
                        break;
                    case '(':
                        tokens.Add(new OpenParenthesisToken());
                        _reader.Read();
                        break;
                    case ')':
                        tokens.Add(new ClosedParenthesisToken());
                        _reader.Read();
                        break;
                    default:
                        if (Char.IsLetter(c))
                        {
                            var token = ParseKeyword();
                            tokens.Add(token);
                        }
                        else
                        {
                            var remainingText = _reader.ReadToEnd() ?? string.Empty;
                            throw new Exception(string.Format("Unknown grammar found at position {0} : '{1}'", _text.Length - remainingText.Length, remainingText));
                        }
                        break;
                }
            }
            return tokens;
        }

        private Boolean IsSpecialChar(Char c)
        {
            switch (c)
            {
                case '|':
                    return true;
                case '!':
                    return true;
                case '&':
                    return true;
                case '=':
                    return true;
                case '<':
                    return true;
                case '>':
                    return true;
                default:
                    return false;
            }
        }

        private Token ParseKeyword()
        {
            var text = new StringBuilder();
            while (Char.IsLetter((char)_reader.Peek()))
            {
                text.Append((char)_reader.Read());
            }

            var potentialKeyword = text.ToString().ToLower();

            switch (potentialKeyword)
            {
                case "true":
                    return new TrueToken();
                case "false":
                    return new FalseToken();
                case "and":
                    return new AndToken();
                case "or":
                    return new OrToken();
                case "equal":
                    return new EqualToken();
                case "notequal":
                    return new NotEqualToken();
                case "gt":
                    return new GreaterThanToken();
                case "lt":
                    return new LesserThanToken();
                case "gtoe":
                    return new GreaterThanOrEqualToken();
                case "ltoe":
                    return new LesserThanOrEqualToken();
                default:
                    throw new Exception("Expected keyword (True, False, And, Or, GT, LT, GTOE, LTOE, Equal, NotEqual) but found " + potentialKeyword);
            }
        }
    }
}
