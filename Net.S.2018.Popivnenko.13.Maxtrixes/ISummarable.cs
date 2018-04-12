namespace Net.S._2018.Popivnenko._13.Maxtrixes
{
    /// <summary>
    /// Ensures that class can be summed.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public interface ISummarable<T>
    {
        T SumWith(ISummarable<T> second);
    }
}
