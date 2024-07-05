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

    public struct LruObject
    {
        public int key;
        public int value;
        public LruObject(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class LRUCache
    {
        Queue<LruObject> lruQueue;
        int cap;        
        int filledElems;
        public LRUCache(int capacity)
        {            
            filledElems = 0;
            cap = capacity;
            lruQueue = new Queue<LruObject>();
        }

        public int Get(int key)
        {
            int keypos = Array.IndexOf(lruQueue.Select(LruObject => LruObject.key).ToArray(), key);
            if (keypos > -1)
            {
                int temp = 0;
                for (int i = 0; i <= lruQueue.Count(); i++)
                {                    
                    if(i == keypos)
                    {
                        temp = lruQueue.Dequeue().value;
                        continue;
                    }                    
                    lruQueue.Enqueue(lruQueue.Dequeue());
                }
                lruQueue.Enqueue(new LruObject(key, temp));
                return temp;
            }
            return -1;
        }        

        public void Put(int key, int value)
        {
            int keypos = Array.IndexOf(lruQueue.Select(LruObject => LruObject.key).ToArray(), key);
            if (keypos > -1)
            {
                //LruObject temp = new LruObject(0,0);
                //for (int i = 0; i <= lruQueue.Count(); i++)
                //{
                //    if (i == keypos)
                //    {
                //        temp = lruQueue.Dequeue();
                //        continue;
                //    }
                //    lruQueue.Enqueue(lruQueue.Dequeue());
                //}                
                //temp.value = value;
                //lruQueue.Enqueue(temp);

                lruQueue = new Queue<LruObject>(lruQueue.Where(LruObject => LruObject.key != key).ToArray());
                lruQueue.Enqueue(new LruObject(key, value));
                return;
            }

            if (filledElems < cap)
            {
                lruQueue.Enqueue(new LruObject(key, value));
                filledElems++;
                return;
            }

            lruQueue.Dequeue();
            lruQueue.Enqueue(new LruObject(key, value));
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

            Console.WriteLine("'----------------'");
            LRUCache lru = new LRUCache(3);

            lru.Put(1, 1);
            lru.Put(2, 2);
            lru.Put(3, 3);
            lru.Put(4, 4);
            Console.WriteLine(lru.Get(4));
            Console.WriteLine(lru.Get(3));
            Console.WriteLine(lru.Get(2));
            Console.WriteLine(lru.Get(1));
            lru.Put(5, 5);
            Console.WriteLine(lru.Get(1));
            Console.WriteLine(lru.Get(2));
            Console.WriteLine(lru.Get(3));
            Console.WriteLine(lru.Get(4));
            Console.WriteLine(lru.Get(5));





            Console.WriteLine("-------------TESTING------------");

            Queue<LruObject> queue = new Queue<LruObject>();
            queue.Enqueue(new LruObject(1,1));
            queue.Enqueue(new LruObject(2,2));
            queue.Enqueue(new LruObject(3,3));
            queue.Enqueue(new LruObject(4,4));

            Console.WriteLine(String.Join(" ", queue.Select(LruObject => LruObject.key).ToArray()));
            Console.WriteLine(Array.IndexOf(queue.Select(LruObject => LruObject.key).ToArray(), 3));
            Console.WriteLine(String.Join(" ", queue.Select(LruObject => LruObject.key != 3).ToArray()));
            Console.WriteLine(String.Join(" ", queue.Where(LruObject => LruObject.key != 3).ToArray()));

            List<int> numbers2 = [15, 14, 11, 13, 19, 18, 16, 17, 12, 10];
            IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);
            int[] test = largeNumbersQuery.ToArray();
        }
    }
}