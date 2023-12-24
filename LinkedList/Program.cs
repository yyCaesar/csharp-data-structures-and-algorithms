namespace LinkedList
{
    internal class Program
    {

        private static ToolMethods _toolMethods
        {
            get { return ToolMethods.getInstance(); }
        }

        private static LeetCode _leetCode
        {
            get { return LeetCode.GetInstance(); }
        }


        static void Main(string[] args)
        {
            code136_DeleteNode();

            Console.ReadKey();
        }


        static void code136_DeleteNode()
        {
            int[] arrs = [-3, 5, -99];
            NodeList node = _toolMethods.ArrayToNodeList2(arrs);
           NodeList result = _leetCode.code136_DeleteNode_2(node, -9);
            _toolMethods.Print(result);
        }

        static void code123_ReverseBookList()
        {
            int[] arrs = { 3, 6, 4, 5 };
            NodeList node = _toolMethods.ArrayToNodeList2(arrs);
            int[] ints = _leetCode.code123_ReverseBookList_4(node);
        }

        static void code24_ReverseList()
        {
            int[] arrs = { 1, 2, 3, 4, 5, 6, 7, 8 };
            NodeList node = _toolMethods.ArrayToNodeList2(arrs);
            NodeList result = _leetCode.code24_ReverseList_2(node);
            _toolMethods.Print(result);
        }

        static void ArrayToNodeList()
        {
            int[] ints = { 2, 4, 6, 8 };
            NodeList node = _toolMethods.ArrayToNodeList2(ints);
            ToolMethods.getInstance().Print(node);
        }
    }
}
