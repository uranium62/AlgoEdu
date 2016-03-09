namespace AlgoEdu.CreakingTheCoding.Lib
{
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class ListNodeBuilder<T>
    {
        private ListNode<T> head;
        private ListNode<T> last;

        public ListNodeBuilder()
        {
            head = null;
            last = null;
        }

        public ListNodeBuilder<T> Add(T val)
        {
            var node = new ListNode<T>(val);

            if (head == null)
            {
                head = node;
                last = node;
                node.Next = null;
            }
            else
            {
                node.Next = null;
                last.Next = node;
                last = node;
            }

            return this;
        }

        public ListNodeBuilder<T> Add(T[] vals)
        {
            foreach (var val in vals)
            {
                this.Add(val);
            }
            return this;
        } 

        public ListNode<T> Build()
        {
            return head;
        }
    }
}
