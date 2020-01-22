using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Climbing_the_Leaderboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int scoresCount = Convert.ToInt32(Console.ReadLine());

            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int aliceCount = Convert.ToInt32(Console.ReadLine());

            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
            int[] result = climbingLeaderboard(scores, alice);

            Console.WriteLine(string.Join("\n", result));

            Console.ReadLine();
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int scoresCount = scores.Length;
            int aliceCount = alice.Length;

            ArrayList results = new ArrayList();

            ArrayList score = new ArrayList();
            score.AddRange(scores);

            ArrayList alices = new ArrayList();
            alices.AddRange(alice);

            ArrayList ranks = new ArrayList();
            ranks.Add(1);

            int rank = 1;
            for(int i = 0; i < scoresCount-1; i++)
            {
                if (scores[i] == scores[i + 1])
                    ranks.Add(rank);
                else
                    ranks.Add(++rank);
            }

            //Array.Sort(scores);
            score.Sort();
            ranks.Reverse();

            int lastIndex = 0;
            for (int i = 0; i < aliceCount; i++)
            {
                int start = 0, end = score.Count - 1, mid, index = 0;
                bool flag = false;
                while (start <= end)
                {
                    mid = (start + end) / 2;
                    if ((int)score[mid] == (int)alices[i])
                    {
                        index = mid;
                        flag = true;

                        if (index == 0)
                        {
                            score.Insert(index, alice[i]);
                            rank = (int)ranks[index];
                            ranks.Insert(index, rank);
                            results.Add(rank);
                            lastIndex = index;
                        }
                        else if (index == score.Count)
                        {
                            rank = (int)ranks[index - 1];
                            score.Insert(index, alice[i]);

                            ranks.Insert(index, rank);
                            results.Add(rank);
                            for (int j = lastIndex - 1; j >= 0; j--)
                                ranks[j] = ((int)ranks[j]) + 1;
                            if (i != 0)
                            {
                                score.RemoveAt(lastIndex);
                                ranks.RemoveAt(lastIndex);
                            }
                            lastIndex = index;
                        }
                        else
                        {

                            rank = ((int)ranks[index]) ;
                            score.Insert(index, alice[i]);
                                
                                ranks.Insert(index, rank);
                                results.Add(rank);
                            for (int j = lastIndex - 1; j >= 0; j--)
                                ranks[j] = ((int)ranks[j]) - 1;
                            if (i != 0)
                            {
                                score.RemoveAt(lastIndex - 1 );
                                ranks.RemoveAt(lastIndex - 1);
                            }
                            lastIndex = index;
                            

                        }

                        

                        
                        break;
                    }
                    else if ((int)score[mid] > (int)alices[i])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }

                if (!flag)
                {
                    if (start >= score.Count)
                        start = (score.Count) - 1;

                    if(end >= score.Count)
                        end = (score.Count) - 1;

                    if (start < 0)
                        start = 0;

                    if (end < 0)
                        end = 0;

                    if ((int)score[start] >= (int)alices[i])
                        index = start;
                    else if ((int)score[start] < (int)alices[i] && (int)alices[i] <= (int)score[end])
                        index = end;
                    else
                        index = end + 1;

                    if(index == 0)
                    {
                        rank = ((int)ranks[index]) + 1;
                        score.Insert(index, alice[i]);
                        
                        ranks.Insert(index, rank);
                        results.Add(rank);
                        lastIndex = index;
                    }
                    else if (index == score.Count)
                    {
                        rank = (int)ranks[index - 1];
                        score.Insert(index, alice[i]);

                        ranks.Insert(index, rank);
                        results.Add(rank);
                        for (int j = index - 1; j >= 0; j--)
                            ranks[j] = ((int)ranks[j]) + 1;
                        if (i != 0)
                        {
                            score.RemoveAt(lastIndex);
                            ranks.RemoveAt(lastIndex);
                        }
                        lastIndex = index;
                    } 
                    else
                    {

                        rank = ((int)ranks[index]) + 1;
                        score.Insert(index, alice[i]);
                            
                            ranks.Insert(index, rank);
                            results.Add(rank);
                        for (int j = index - 1; j >= 0; j--)
                            ranks[j] = ((int)ranks[j]) + 1;
                        if (i != 0)
                        {
                            score.RemoveAt(lastIndex);
                            ranks.RemoveAt(lastIndex);
                        }
                        lastIndex = index;
                        

                    }
                   

                    

              
                }

            }
            //Console.WriteLine(string.Join("\n", (int[])score.ToArray(typeof(Int32))));
            //return (int[])ranks.ToArray(typeof(Int32));
            return (int[])results.ToArray(typeof(Int32));
        }
    }
}
