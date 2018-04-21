using Key = System.Int32;

namespace DataStructures.Exceptions
{
    public class NoPathBetweenNodesException : System.Exception
    {
        public NoPathBetweenNodesException(Key a, Key b) : base($"Couldn't find path between Node {a} and Node {b}.")
        {
        }
    }
}
