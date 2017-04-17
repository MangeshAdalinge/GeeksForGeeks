using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonProblems
{
    class NAryTree
    {
        
        public static bool checkMirror(string[] originalTree, string[] mirrorTree)
        {
            Dictionary<string, List<string>> originalTreeDictionary = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> mirrorTreeDictionary = new Dictionary<string, List<string>>();
            if (originalTree.Length == mirrorTree.Length)
            {
                for (int i = 0; i < originalTree.Length - 1; i++)
                {
                    List<string> s = new List<string>();
                    s.Add(originalTree[i + 1]);
                    if (!originalTreeDictionary.ContainsKey(originalTree[i]))
                    {
                        originalTreeDictionary.Add(originalTree[i], s);
                    }
                    else
                    {
                        originalTreeDictionary[originalTree[i]].Add(originalTree[i+1]);
                    }

                    List<string> s1 = new List<string>();
                    s1.Add(mirrorTree[i + 1]);
                    if (!mirrorTreeDictionary.ContainsKey(mirrorTree[i]))
                    {
                        mirrorTreeDictionary.Add(mirrorTree[i], s1);
                    }
                    else
                    {
                        mirrorTreeDictionary[mirrorTree[i]].Add(mirrorTree[i + 1]);
                    }
                    i++;
                }

                foreach (var item in originalTreeDictionary)
                {
                    if (mirrorTreeDictionary.ContainsKey(item.Key))
                    {
                        List<string> l1 = originalTreeDictionary[item.Key];
                        List<string> l2 = mirrorTreeDictionary[item.Key];
                        
                        for (int i = 0; i < l1.Count; i++)
                        {
                            if (l1.ElementAt(i) != l2.ElementAt(l2.Count - 1 - i))
                            {
                                return false;
                            }
                        }                       
                    }
                }
                return true;                
            }
            else
            {
                return false;
            }
            
        }
    }
}
