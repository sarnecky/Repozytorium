using System;
using System.Collections.Generic;

namespace zabawa_z_gitem.SearchEngine
{
    public class RabinKarpSearch
    {
        private double Prime = 3;

        public IEnumerable<ulong> searchPattern(string text, string pattern)
        {
            ulong m = (ulong)pattern.Length;
            ulong n = (ulong)text.Length;
            ulong textHash = createHash(text, m);
            ulong patternHash = createHash(pattern, m);

            for (ulong i = 1; i <= n - m + 1; i++)
            {
                if (textHash == patternHash && chcekEqual(i - 1, pattern, text))
                {
                    yield return i - 1;
                }
                if (i < n - m + 1)
                {
                    textHash = recalculateHash(text, textHash, i - 1, i + m - 1, m);
                }
            }
            yield break;
        }

        public ulong createHash(string text, ulong textLength)
        {
            ulong hash = 0;
            for (ulong i = 0; i < textLength; i++)
            {
                hash += (ulong)text[(int)i] * (ulong)Math.Pow(Prime, (double)i);
            }
            return hash;
        }

        public ulong recalculateHash(string text, ulong oldHash, ulong oldIndex, ulong newIndex, ulong patternLenght)
        {
            ulong newHash = (ulong)((oldHash - (ulong)text[(int)oldIndex]) / Prime);
            newHash += (ulong)text[(int)newIndex] * (ulong)Math.Pow(Prime, patternLenght - 1);
            return newHash;
        }

        public bool chcekEqual(ulong startTextIndex, string pattern, string text)
        {
            ulong i = startTextIndex;
            foreach (var s in pattern)
            {
                if (s != text[(int)i])
                    return false;
                i++;
            }
            return true;
        }
    }
}