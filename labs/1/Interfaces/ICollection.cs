namespace RunProgram
{
    interface ICollection<T>
    {
        bool Add(T t);
        T Delete(int index);
        T GetValue(int index);
    }
}