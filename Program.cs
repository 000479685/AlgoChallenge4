// See https://aka.ms/new-console-template for more information


namespace Program
{
    public class MyStack
    {

        Queue<int> queueStack;
        Queue<int> queueTemp;
        public MyStack()
        {
            queueStack = new Queue<int>();
            queueTemp = new Queue<int>();
        }

        public void Push(int x)
        {
            queueTemp = new Queue<int>(queueStack.ToArray());
            queueStack.Clear();
            queueStack.Enqueue(x);
            int iter = queueTemp.Count();
            for (int i = 0; i < iter; i++)
            {
                queueStack.Enqueue(queueTemp.Dequeue());
            }
        }

        public int Pop()
        {
            return queueStack.Dequeue();
        }

        public int Top()
        {
            return queueStack.Peek();
        }

        public bool Empty()
        {
            return queueStack.Count() == 0;
        }
    }

    public class MyQueue
    {

        Stack<int> stackQueue;
        Stack<int> stackTemp;
        public MyQueue()
        {
            stackQueue = new Stack<int>();
            stackTemp = new Stack<int>();
        }

        public void Push(int x)
        {
            int iter = stackQueue.Count();

            stackTemp = new Stack<int>(stackQueue.ToArray());
            stackQueue.Clear();
            stackQueue.Push(x);
            for (int i = 0; i < iter; i++)
            {
                stackQueue.Push(stackTemp.Pop());
            }
        }

        public int Pop()
        {
            return stackQueue.Pop();
        }

        public int Peek()
        {
            return stackQueue.Peek();
        }

        public bool Empty()
        {
            return stackQueue.Count() == 0;
        }
    }

    public class Challenge4
    {
        public static void Main(string[] args)
        {
            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);
            obj.Push(3);
            int param_2 = obj.Pop();
            int param_3 = obj.Top();
            bool param_4 = obj.Empty();

            Console.WriteLine($"{param_2} {param_3} {param_4}");


            MyQueue myQueue = new MyQueue();
            myQueue.Push(1);
            myQueue.Push(2);
            myQueue.Push(3);
            myQueue.Push(4);
            Console.WriteLine(myQueue.Pop());
            myQueue.Push(5);
            Console.WriteLine(myQueue.Pop());
            Console.WriteLine(myQueue.Pop());
            Console.WriteLine(myQueue.Pop());
            Console.WriteLine(myQueue.Pop());
            //Console.WriteLine($"{myQueue.Pop()} {myQueue.Peek()} {myQueue.Empty()}");
        }
    }
}