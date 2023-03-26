public class Solution
{

    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;
        if (s.Length == 1) return 1;

        var maxLength = 0;
        HashSet<char> visited = new();

        int left = 0, right = 0;
        for (; right < s.Length; right++)
        {
            if (visited.TryGetValue(s[right], out var character))
            {
                maxLength = Math.Max(maxLength, right - left);

                while (left < right)
                {
                    if (s[left] == s[right])
                    {
                        left++;
                        break;
                    }

                    visited.Remove(s[left]);
                    left++;
                }
            }

            visited.Add(s[right]);
        }

        maxLength = Math.Max(maxLength, right - left);

        return maxLength;
    }
}