namespace WebApiPractice.Sorting
{
    public class TreeNode
    {
        public char Data { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
        public TreeNode(char data) => Data = data;

        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        public char[] Transform(List<char>? characters = null)
        {
            if (characters == null)
            {
                characters = new List<char>();
            }

            if (Left != null)
            {
                Left.Transform(characters);
            }

            characters.Add(Data);

            if (Right != null)
            {
                Right.Transform(characters);
            }

            return characters.ToArray();
        }

        public static char[] TreeSort(char[] characters)
        {
            var TreeSort = new TreeNode(characters[0]);
            for (int i = 1; i < characters.Length; i++)
            {

                TreeSort.Insert(new TreeNode(characters[i]));
            }
            return TreeSort.Transform();
        }
    }