public interface IInputHandler<T>
{
    T Output { get; }
    void InputUpdate();
}
