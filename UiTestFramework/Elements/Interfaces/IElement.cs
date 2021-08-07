namespace UiTestFramework.elements.interfaces
{
    public interface IElement<T> where T : IElement<T>
    {
        T Click();
    }
}