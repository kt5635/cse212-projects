using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following values and priority: Apple (4), Orange (1), Pear (5), Banana (3) 
    // run until the queue is empty. Checking that the items are being added to the queue in the correct order.  
    // Expected Result: Apple, Orange, Pear, Banana
    // Defect(s) Found: No errors found, working as expected.
    public void TestPriorityQueue_1()
    {

        var apple = new PriorityItem("Apple", 4);
        var orange = new PriorityItem("Orange", 1);
        var pear = new PriorityItem("Pear", 5);
        var banana = new PriorityItem("Banana", 3);

        var expectedResult = "[Apple (Pri:4), Orange (Pri:1), Pear (Pri:5), Banana (Pri:3)]";

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(apple.Value, apple.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(pear.Value, pear.Priority);
        priorityQueue.Enqueue(banana.Value, banana.Priority);

        Assert.AreEqual(expectedResult, priorityQueue.ToString());

    }

    [TestMethod]
    // Scenario: Add the following items and priorities to the queue, check that they are being dequeued in order or priority. 
    // apple(2), orange(5), pear(1), banana(4).
    // Expected Result: orange, banana, apple, pear
    // Defect(s) Found: Program is not removing the items from queue, instead it is dequeueing the highest priority over and over again.
    // Once that error was fixed, found that the program does not cycle through the rest of the list based on priority. Adjusted loop to check all items (not just the first) 
    public void TestPriorityQueue_2()
    {
        var apple = new PriorityItem("Apple", 2);
        var orange = new PriorityItem("Orange", 5);
        var pear = new PriorityItem("Pear", 1);
        var banana = new PriorityItem("Banana", 4);

        string[] expectedResults = { "Orange", "Banana", "Apple", "Pear" };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(apple.Value, apple.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(pear.Value, pear.Priority);
        priorityQueue.Enqueue(banana.Value, banana.Priority);

        var actualResults = new List<string>();
        for (int i = 0; i < expectedResults.Length; i++)
        {
            actualResults.Add(priorityQueue.Dequeue());
        }

        CollectionAssert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    // Scenario: Add the following items and priorities to the queue, check when two items have the same priority, the 
    // first item dequeued is in the from of the queue. apple(5), orange(1), pear(3), banana(5).
    // Expected Result: apple, banana, pear, orange
    // Defect(s) Found: If two items have the same priority, program is prioritizing last item instead of first. 
    // Corrected so first item is prioritize in the case of a tie
    public void TestPriorityQueue_3()
    {
        var apple = new PriorityItem("Apple", 4);
        var orange = new PriorityItem("Orange", 1);
        var pear = new PriorityItem("Pear", 4);
        var banana = new PriorityItem("Banana", 5);

        string[] expectedResults = { "Banana", "Apple", "Pear", "Orange" };

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(apple.Value, apple.Priority);
        priorityQueue.Enqueue(orange.Value, orange.Priority);
        priorityQueue.Enqueue(pear.Value, pear.Priority);
        priorityQueue.Enqueue(banana.Value, banana.Priority);

        var actualResults = new List<string>();
        for (int i = 0; i < expectedResults.Length; i++)
        {
            actualResults.Add(priorityQueue.Dequeue());
        }

        CollectionAssert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    // Scenario: Try to get the next person from an empty queue
    // Expected Result: Throws correct error with error message, queue is empty
    // Defect(s) Found: No errors found, program runs as expected.
    public void TestPriorityQueue_4()
    {
        var queue = new PriorityQueue();
        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}