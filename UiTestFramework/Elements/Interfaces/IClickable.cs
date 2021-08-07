namespace UiTestFramework.elements.interfaces
{
    public interface IClickable<out T> where T : IClickable<T>
    {
        T Click();

        T ClickByActions();

        T ClickByScript();
    }
}