using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Transitions
    {
        public string startS = null;
        public string edgeS = null;
        public string endS = null;
        public Transitions(string ss,string edgs , string es)
        {
            this.startS = ss;
            this.edgeS = edgs;
            this.endS = es;
        }
    }
    class Q1
    {
        static bool Finite_Automata(string[] States,string[] Alphabets,string startState,string[] EndStates,Transitions[] trs,string str)
        {
            List<string> currentState = new List<string>();
            currentState.Add(startState);
            foreach(var s in str)
            {
                int idx = 0;
                while(idx < currentState.Count)
                {
                    foreach(var t in trs)
                    {
                        if(t.startS == currentState[idx] && t.edgeS == "$")
                            currentState.Add(t.endS);
                    }
                    idx++;
                }
                List<string> Nstate = new List<string>();
                foreach(var t in trs)
                {
                    if(currentState.Contains(t.startS) && t.edgeS == s.ToString())
                    {
                        Nstate.Add(t.endS);
                    }
                }
                currentState = Nstate;
            }
            foreach(var e in EndStates)
            {
                if(currentState.Contains(e))
                    return true;
            }
            return false;
        }
        static  void Main1(string[] args)
        {
            string input1 = Console.ReadLine();
            string states = input1.Trim('{','}');
            string[] States = states.Split(',');
            string startState = States[0];
            string input2 = Console.ReadLine();
            string Alpha = input2.Trim('{','}');
            string[] Alphabets = Alpha.Split(',');
            string input3 = Console.ReadLine();
            string endstates = input3.Trim('{','}');
            string[] EndStates = endstates.Split(',');
            long count = long.Parse(Console.ReadLine());
            Transitions[] trs = new Transitions[count];
            for(int i=0; i<count; i++)
            {
                string[] inputs = Console.ReadLine().Split(',');
                trs[i] = new Transitions(inputs[0],inputs[1],inputs[2]);
            }
            string str = Console.ReadLine();
            if(Finite_Automata(States,Alphabets,startState,EndStates,trs,str))
                System.Console.WriteLine("Accepted");
            else
                System.Console.WriteLine("Rejected");
        }
    }
}
