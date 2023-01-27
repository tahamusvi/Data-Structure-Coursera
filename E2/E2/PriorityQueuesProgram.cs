using System;
using System.Collections.Generic;

// Demonstrate a Priority Queue implemented with a Binary Heap

namespace PriorityQueues
{
  class PriorityQueuesProgram
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\nBegin Priority Queue demo");
      
      Console.WriteLine("\nCreating priority queue of Employee items\n");
      PriorityQueue<Employee> pq = new PriorityQueue<Employee>();

      Employee e1 = new Employee("Aiden", 1.0);
      Employee e2 = new Employee("Baker", 2.0);
      Employee e3 = new Employee("Chung", 3.0);
      Employee e4 = new Employee("Dunne", 4.0);
      Employee e5 = new Employee("Eason", 5.0);
      Employee e6 = new Employee("Flynn", 6.0);

      Console.WriteLine("Adding " + e5.ToString() + " to priority queue");
      pq.Enqueue(e5);
      Console.WriteLine("Adding " + e3.ToString() + " to priority queue");
      pq.Enqueue(e3);
      Console.WriteLine("Adding " + e6.ToString() + " to priority queue");
      pq.Enqueue(e6);
      Console.WriteLine("Adding " + e4.ToString() + " to priority queue");
      pq.Enqueue(e4);
      Console.WriteLine("Adding " + e1.ToString() + " to priority queue");
      pq.Enqueue(e1);
      Console.WriteLine("Adding " + e2.ToString() + " to priority queue");
      pq.Enqueue(e2);

      Console.WriteLine("\nPriory queue is: ");
      Console.WriteLine(pq.ToString());
      Console.WriteLine("\n");

      Console.WriteLine("Removing an employee from priority queue");
      Employee e = pq.Dequeue();
      Console.WriteLine("Removed employee is " + e.ToString());
      Console.WriteLine("\nPriory queue is now: ");
      Console.WriteLine(pq.ToString());
      Console.WriteLine("\n");
            
      Console.WriteLine("Removing a second employee from queue");
      e = pq.Dequeue();
      Console.WriteLine("\nPriory queue is now: ");
      Console.WriteLine(pq.ToString());
      Console.WriteLine("\n");

      Console.WriteLine("Testing the priority queue");
      TestPriorityQueue(50000);
     

     Console.WriteLine("\nEnd Priority Queue demo");
      Console.ReadLine();
    } // Main()

    static void TestPriorityQueue(int numOperations)
    {
      Random rand = new Random(0);
      PriorityQueue<Employee> pq = new PriorityQueue<Employee>();
      for (int op = 0; op < numOperations; ++op)
      {
        int opType = rand.Next(0, 2);

        if (opType == 0) // enqueue
        {
          string lastName = op + "man";
          double priority = (100.0 - 1.0) * rand.NextDouble() + 1.0;
          pq.Enqueue(new Employee(lastName, priority));
          if (pq.IsConsistent() == false)
          {
            Console.WriteLine("Test fails after enqueue operation # " + op);
          }
        }
        else // dequeue
        {
          if (pq.Count() > 0)
          {
            Employee e = pq.Dequeue();
            if (pq.IsConsistent() == false)
            {
              Console.WriteLine("Test fails after dequeue operation # " + op);
            }
          }
        }
      } // for
      Console.WriteLine("\nAll tests passed");
    } // TestPriorityQueue

  } // class PriorityQueuesProgram

  // ===================================================================

  public class Employee : IComparable<Employee>
  {
    public string lastName;
    public double priority; // smaller values are higher priority

    public Employee(string lastName, double priority)
    {
      this.lastName = lastName;
      this.priority = priority;
    }

    public override string ToString()
    {
      return "(" + lastName + ", " + priority.ToString("F1") + ")";
    }

    public int CompareTo(Employee other)
    {
      if (this.priority < other.priority) return -1;
      else if (this.priority > other.priority) return 1;
      else return 0;
    }
  } // Employee

  // ===================================================================

  public class PriorityQueue<T> where T : IComparable<T>
  {
    private List<T> data;

    public PriorityQueue()
    {
      this.data = new List<T>();
    }

    public void Enqueue(T item)
    {
      data.Add(item);
      int ci = data.Count - 1; // child index; start at end
      while (ci > 0)
      {
        int pi = (ci - 1) / 2; // parent index
        if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
        T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
        ci = pi;
      }
    }

    public T Dequeue()
    {
      // assumes pq is not empty; up to calling code
      int li = data.Count - 1; // last index (before removal)
      T frontItem = data[0];   // fetch the front
      data[0] = data[li];
      data.RemoveAt(li);

      --li; // last index (after removal)
      int pi = 0; // parent index. start at front of pq
      while (true)
      {
        int ci = pi * 2 + 1; // left child index of parent
        if (ci > li) break;  // no children so done
        int rc = ci + 1;     // right child
        if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
          ci = rc;
        if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
        T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
        pi = ci;
      }
      return frontItem;
    }

    public T Peek()
    {
      T frontItem = data[0];
      return frontItem;
    }

    public int Count()
    {
      return data.Count;
    }

    public override string ToString()
    {
      string s = "";
      for (int i = 0; i < data.Count; ++i)
        s += data[i].ToString() + " ";
      s += "count = " + data.Count;
      return s;
    }

    public bool IsConsistent()
    {
      // is the heap property true for all data?
      if (data.Count == 0) return true;
      int li = data.Count - 1; // last index
      for (int pi = 0; pi < data.Count; ++pi) // each parent index
      {
        int lci = 2 * pi + 1; // left child index
        int rci = 2 * pi + 2; // right child index

        if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
        if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
      }
      return true; // passed all checks
    } // IsConsistent
  } // PriorityQueue

} // ns
