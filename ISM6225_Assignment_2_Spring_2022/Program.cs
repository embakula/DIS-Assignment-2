/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/
// Sashanth Embakula
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = {1,3,5,6 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "a.";
            string[] banned = { };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 1,2,2,3,3,3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1123";
            string guess = "0111";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "(]";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1  = "horse";
            string word2 = "ros";
            int minLen = MinDistance( word1,  word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }
    

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {

            //Write your Code here
            int l = nums.Length;
            int[] res = new int[l+1];
            try
            {
                if (l == 0) //When there is no array, return 0
                {
                    return 0;
                }
                if (l == 1) //when the length of array is 1, check size of array
                {
                    if ((nums[0] == target) || (nums[0] > target)) //when target is in first position or less than second position, retun as position 0
                        return 0;
                    if (nums[0] < target) //else position 1
                        return 1;
                }
                if (l >= 2) //when length is greater than 1, check if the number is present and return the position
                {               
                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        if (nums[i] < target && nums[i + 1] > target)
                        {
                            return i + 1;
                        }
                        if(nums[i] == target)
                        {
                            return i;
                        }
                    }
                }

                return l;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                paragraph = paragraph.ToLower();
                paragraph = paragraph.Replace(",", String.Empty);
                paragraph = paragraph.Replace(".", String.Empty);
                string[] paraSplit = paragraph.Split();
                int max = 0;
                string res = "";
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (string word in paraSplit) //checks loop for all the words
                {
                    if (!banned.Contains(word)) //check if the word meets our criteria of atleast 3 words
                    {
                        if (dict.ContainsKey(word))  //check for the word in the dictionary
                        {  
                            dict[word] = dict[word] + 1;  
                            if ( dict[word] > max)
                            {
                                max = dict[word];
                                res = word;
                            }

                        }
                        else
                        {
                            dict[word] = 1; //add to the dictionary with a count 1
                            if (dict[word] > max)
                            {
                                max = dict[word];
                                res = word;
                            }
                        }
                    }
                }


                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                int res = -1;
                Dictionary<int, int> dict = new Dictionary<int, int>();
                foreach (int val in arr) //checks loop for all the words
                {
                    if (dict.ContainsKey(val))  //check for the word in the dictionary
                    {
                        dict[val] += 1;
                    }
                    else
                    {
                        dict[val] = 1;
                    }
                }
                foreach(var item in dict)  //check if the key is equal to postion and greater than -1
                {
                    if ((item.Key == item.Value) && (item.Key > res))
                        res = item.Value; 
                }

                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                List<char> s = new List<char>(); //creating a new list s
                List<char> g = new List<char>(); //creating a new list g
                foreach (char a in secret)
                { 
                    s.Add(a); //assigning words from secret to s
                }
                foreach (char a in guess)
                {
                    g.Add(a); //assigning words from guess to g
                }
                //char[] s = secret.ToCharArray();
                //char[] g = guess.ToCharArray();
                //initializing bulls and cows to 0
                int bulls = 0;
                int cows = 0;
                int l = secret.Length;
                for(int i = 0; i < l;) 
                {
                    if (s[i] == g[i]) //check if s and g has same numbers ignoring the position
                    {
                        s.RemoveAt(i);
                        g.RemoveAt(i);
                        l--;
                        bulls++;
                    }
                    else
                        i++;
                }
                foreach(char a in s) 
                {
                    foreach(char b in g)
                    {
                        if (a == b) //check if s and g positions are same
                        {
                            cows++;
                            g.Remove(a);
                            break;
                        }
                    }
                }
                return bulls + "A" + cows + "B";
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                char[] str = s.ToCharArray();//Converting the string to char array
                List<int> res = new List<int>();
                int l=str.Length;//getting the string length
                for(int i = 0; i < l; i++)//storing the last position of the each character
                {
                    dict[str[i]] = i;
                }
                int prev = 0;
                int next = 0;
                int maxl = 0;// traversing the entire string
                for(int i = 0; i < l; i++)
                {
                    int last = dict[str[i]];
                    maxl = Math.Max(maxl, last);// if last position of each charater is same as position, partitioning the string
                    if(i == maxl)
                    {
                        next = i - prev + 1;
                        res.Add(next); // adding the partition value to result array
                        prev = i + 1;
                    }
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths,string s)
        {
            try
            {
                char i = 'a';
                int l = 1;// initializing the length to 1
                int w = 0;
                int width;
                foreach (char a in s)// iterating each character in string
                {
                    int k = (int)a - (int)i;
                    width = widths[k];//getting the width of character
                    w += width;//calcualting the total width
                    if (w > 100)//if width is more than 100, increasing the length
                    {
                        l++;
                        w = width;
                    }

                }
                return new List<int>() { l, w };
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                char[] bulls = bulls_string10.ToCharArray();
                //write your code here.
                Stack myStack = new Stack();
                myStack.Push('|');
                foreach(char a in bulls_string10) //check all chars in the string
                {
                    if(a == '}') //check if there is a closed brace in the string
                    {
                        if ((char)myStack.Peek() != '{')
                        {
                            myStack.Push(a); //push a when there is no open bracket
                        }
                        else
                        {
                            myStack.Pop();
                        }
                    }
                    if (a == ']')
                    {
                        if ((char)myStack.Peek() != '[')
                        {
                            myStack.Push(a); ////push a when there is no open bracket
                        }
                        else
                        {
                            myStack.Pop();
                        }
                    }
                    if (a == ')')
                    {
                        if ((char)myStack.Peek() != '(')
                        {
                            myStack.Push(a); ////push a when there is no open bracket
                        }
                        else
                        {
                            myStack.Pop();
                        }
                    }
                    if (a != '}' && a != ')' && a != ']')
                        myStack.Push(a);

                }
                if (myStack.Count == 1) //when there are both open and closed brackets, boolean(true) is returned else boolean(false) is returned   
                    return true;
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //defining a string with all the codes
                string[] morse = new string[26] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                List<string> l = new List<string>(); //creating a list
                foreach (string word in words) //for each word in the string 
                {
                    string s = "";
                    foreach (char c in word)
                    {
                        string t = morse[(int)c - (int)'a']; //converting the string into morse
                        s += t.ToString(); //adding chars of s to the string

                    }

                    if (!l.Contains(s))
                    {
                        l.Add(s);
                    }
                }

                return l.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                int l = grid.GetLength(0);//length of grid
                int low = Math.Max(grid[0, 0], grid[l - 1, l - 1]); // creating grid matrix
                int high = l * l - 2;
                bool[] visited = null;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2; // calculating the mid value
                    visited = new bool[l * l];
                    var success = Dfs(mid, 0, 0); // traversing the dfs path and checking if the path is successful
                    if (success) // if successful,reducing the high to mid
                        high = mid - 1;
                    else
                        low = mid + 1;// else, increasing the low to mid
                }
                return low;

                bool Dfs(int t, int y, int x)
                {
                    if (x == l - 1 && y == l - 1) // if it reaches the end
                        return true;

                    visited[grid[y, x]] = true;

                    // down
                    if (y + 1 < l && !visited[grid[y + 1, x]] && grid[y + 1, x] <= t && Dfs(t, y + 1, x))
                        return true;

                    // right
                    if (x + 1 < l && !visited[grid[y, x + 1]] && grid[y, x + 1] <= t && Dfs(t, y, x + 1))
                        return true;

                    // up
                    if (y - 1 >= 0 && !visited[grid[y - 1, x]] && grid[y - 1, x] <= t && Dfs(t, y - 1, x))
                        return true;

                    // left
                    if (x - 1 >= 0 && !visited[grid[y, x - 1]] && grid[y, x - 1] <= t && Dfs(t, y, x - 1))
                        return true;

                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                var n1 = word1.Length;
                var n2 = word2.Length;
                var dp = new int[n1 + 1, n2 + 1];

                for (int i = 0; i < n1 + 1; i++)
                {
                    for (int j = 0; j < n2 + 1; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            dp[i, j] = 0;
                        }
                        else if (i == 0)
                        {
                            dp[i, j] = j;
                        }
                        else if (j == 0)
                        {
                            dp[i, j] = i;
                        }
                        else
                        {
                            var word1Index = i - 1;
                            var word2Index = j - 1;

                            if (word1[word1Index] == word2[word2Index])
                            {
                                dp[i, j] = dp[i - 1, j - 1];
                            }
                            else
                            {
                                // 1. change one letter
                                // 2. remove one letter from word2
                                // 3. add one letter to word2
                                dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                            }
                        }
                    }
                }
                return dp[n1, n2];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

/*Self Reflection
    Question 1: Time taken: 10mins
    Question 2: Time taken: 15mins
    Question 3: Time taken: 15mins
    Question 4: Time taken: 10mins
    Question 5: Time taken: 30mins
    Question 6: Time taken: 25mins
    Question 7: Time taken: 40mins
    Question 8: Time taken: 35mins
    Question 9: Time taken: 180mins
    Question 10: Time taken: 145mins
    */