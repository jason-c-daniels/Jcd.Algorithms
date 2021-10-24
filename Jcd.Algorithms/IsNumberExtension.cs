using System;

namespace Jcd.Algorithms
{
    public static class IsNumberExtension
    {
        enum ParseState { Start, LeadingSign, InPrefix, Period, InSuffix, ExponentSymbol, ExponentSign, InExponent, Final, Error };
        public static bool IsNumber(this string s)
        {
            // take care of some well known cases.
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length == 1)
                return s[0].IsDigit();

            if (s.Length == 2)
            {
                if (s[0].IsDigit()) return s[1].IsPeriod() || s[1].IsDigit();
                if (s[0].IsPeriod()) return s[1].IsDigit();
                if (s[0].IsSign()) return s[1].IsDigit();
                return false;
            }

            if (s[0].IsPeriod() && s[1].IsE()) return false;
            if (s[^1].IsE()) return false;
            if (s[^1].IsSign()) return false;

            // now parse the number
            var state = ParseState.Start;
            try
            {
                for( var i=0; i < s.Length && state != ParseState.Error; i++)
                {
                    state = ProcessState(state, s[i]);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return state != ParseState.Error;
        }

        private static ParseState ProcessState(ParseState state, char c)
        {
            // only process valid characters
            if (c.IsValid())
            {
                if (state == ParseState.Start)
                {
                    if (c.IsSign()) return ParseState.LeadingSign;
                    if (c.IsDigit()) return ParseState.InPrefix;
                    if (c.IsPeriod()) return ParseState.Period;
                    return ParseState.Error;
                }
                else if (state == ParseState.LeadingSign)
                {
                    if (c.IsDigit()) return ParseState.InPrefix;
                    if (c.IsPeriod()) return ParseState.Period;
                    return (ParseState.Error);
                }
                else if (state == ParseState.InPrefix)
                {
                    if (c.IsDigit()) return ParseState.InPrefix;
                    if (c.IsPeriod()) return ParseState.Period;
                    if (c.IsE()) return ParseState.ExponentSymbol;
                    return ParseState.Error;
                }
                else if (state == ParseState.Period)
                {
                    if (c.IsDigit()) return ParseState.InSuffix;
                    if (c.IsE()) return ParseState.ExponentSymbol;
                    return ParseState.Error;
                }
                else if (state == ParseState.InSuffix)
                {
                    if (c.IsDigit()) return ParseState.InSuffix;
                    if (c.IsE()) return ParseState.ExponentSymbol;
                    return ParseState.Error;
                }
                else if (state == ParseState.ExponentSymbol)
                {
                    if (c.IsSign()) return ParseState.ExponentSign;
                    if (c.IsDigit()) return ParseState.InExponent;
                    return ParseState.Error;
                }
                else if (state == ParseState.ExponentSign)
                {
                    if (c.IsDigit()) return ParseState.InExponent;
                    return ParseState.Error;
                }
                else if (state == ParseState.InExponent)
                {
                    if (c.IsDigit()) return ParseState.InExponent;
                    return ParseState.Error;
                }
                else if (state == ParseState.Final)
                {
                    throw new Exception("Final state reached but more text was pending parsing.");
                }
            }
            else
            {
                return ParseState.Error;
            }

            return state;
        }


        static bool IsValid(this char c) => c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' ||
                                            c == '6' || c == '7' || c == '8' || c == '9' || c == '-' || c == '+' ||
                                            c == 'e' || c == 'E' || c == '.';
        
        static bool IsDigit(this char c) => c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9';
        static bool IsE(this char c) => c == 'e' || c == 'E';
        static bool IsPeriod(this char c) => c == '.';
        static bool IsSign(this char c) => c == '-' || c == '+';
        
    }
}