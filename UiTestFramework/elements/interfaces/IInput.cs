namespace UiTestFramework.elements.interfaces
{
    public interface IInput<out T> where T : IInput<T>
    {
        public T SendKeys(string value);

        public T Clear();
    }
}