using System.Collections.Generic;

namespace _2_200
{
    class PowerOfNumber
    {
        private int Number { get; set; }
        private int Power { get; set; }
        private LinkedListNode<int> Node;
        private LinkedList<int> List;
        private string Value { get; set; }

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

            for (int q = 1; q < Power; ++q)
            {
                feelingList();
            }
            return this.ToString();
        }
    }
}