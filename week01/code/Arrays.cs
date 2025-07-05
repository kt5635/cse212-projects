public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>


    public static double[] MultiplesOf(double number, int length)
    {
        /// <MultiplesOf prcess>
        /// 1. will use double [] mulitples to store results
        /// 2. double number is the number to be multiplied
        /// 3. int length is the number of results to be stored 
        /// 4. use a loop to multiply the number 'length' number of times starting at 0 (int i = 0; i < length; i++)  
        /// 5. mulitply the number, starting at 1, adding it to the array before increasing the number to multiply by 1 increment
        /// 6. return multiples

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        /// <RotateListRight prcess>
        /// 1. split the list by the 'amount' into two lists using GetRange
        /// 2. add first part of the list 'front' to the back of the list 'back' using % 
        /// 3. update the original list using .Clear and .AddRange
         
        int n = data.Count;
        amount = amount % n;

        List<int> front = data.GetRange(n - amount, amount);
        List<int> back = data.GetRange(0, n - amount);

        data.Clear();
        data.AddRange(front);
        data.AddRange(back);

        return;

    }
}
