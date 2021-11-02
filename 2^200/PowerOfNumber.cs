using System.Collections.Generic;

namespace _2_200
{
    class PowerOfNumber
    {
        public int Number { get; set; }
        public int Power { get; set; }
        private LinkedListNode<int> Node;
        private LinkedList<int> List;
        public string Value { get; set; }

        private void feelingList()
        {
            int sum = 0;
            int buffer = 0;
            while (Node != null || buffer > 0)
            {
                sum = (Node != null ? Node.Value : 0) * Number + buffer;
                buffer = 0;
                if (sum > 9)
                {
                    buffer = sum / 10;
                    sum %= 10;
                }
                if (Node == null)
                    List.AddLast(new LinkedListNode<int>(sum));
                else
                    Node.Value = sum;
                if (Node != null)
                    Node = Node.Next;
            }
            Node = List.First;
        }
        private string ToString(int _val)
        {
            Value = _val.ToString();
            return Value;
        }
        private string ToString(string _str)
        {
            Value = _str;
            return Value;
        }
        public PowerOfNumber(int _number, int _power)
        {
            Number = _number;
            Power = _power;
            List = new LinkedList<int>();
            Node = new LinkedListNode<int>(Number);
            List.AddFirst(Node);
        }
        public override string ToString()
        {
            if (List.Count > 0)
            {
                LinkedListNode<int> lastNodeOfList = List.Last;
                while (lastNodeOfList.Previous != null)
                {
                    Value += lastNodeOfList.Value.ToString();
                    lastNodeOfList = lastNodeOfList.Previous;
                }
                Value += lastNodeOfList.Value.ToString();
            }
            else
                Value = "0";
            return Value;
        }
        public string getPower()
        {
            if (Power == 0)
                return this.ToString(1);
            else if (Power < 0)
                return this.ToString("exception : power not natural number");
            else
                for (int q = 1; q < Power; ++q)
                {
                    feelingList();
                }
            return this.ToString();
        }
    }
}