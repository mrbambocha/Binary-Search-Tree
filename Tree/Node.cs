namespace Labb4
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public string Key { get; set; }
        public int Value { get; set; }
        

        public override string ToString()
        {
            return string.Format("{0}:{1} ", Key, Value.ToString());            
        }
    }
}