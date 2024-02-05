using System.Text;

namespace CreateCustomList;

public class CustomList
{
    #region FieldsAndProperties
    private const int InitialArraySize = 2;
    private int[] items;
    public int Count { get; private set; } = 0;
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return items[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            items[index] = value;
        }
    }
    #endregion


    public CustomList()
    {
        this.items = new int[InitialArraySize];
    }
    /// <summary>
    /// This is a method to add an element to the list
    /// </summary>
    /// <param name="element"></param>
    public void Add(int element)
    {
        if (Count >= items.Length)
        {
            IncreaseCapacity();
        }

        this.items[Count] = element;
        Count++;
    }

    public int RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        int result = this.items[index];
        ShiftLeft(index);
        Count--;

        if (Count <= this.items.Length / 4)
        {
            ShrinkCapacity();
        }
        return result;
    }

    public bool Contains(int element)
    {
        for (int i = 0; i < Count; i++)
        {
            if (this.items[i] == element)
            {
                return true;
            }
        }

        return false;
    }
    public void Swap(int firstIndex, int secondIndex)
    {
        if (firstIndex < 0
            || secondIndex < 0
            || firstIndex >= Count
            || secondIndex >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        int temp = this.items[firstIndex];
        this.items[firstIndex] = this.items[secondIndex];
        this.items[secondIndex] = temp;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Count; i++)
        {
            sb.Append($"{items[i]} ");
        }

        return sb.ToString().TrimEnd();
    }
    private void IncreaseCapacity()
    {
        int[] copy = new int[this.items.Length * 2];
        for (int i = 0; i < Count; i++)
        {
            copy[i] = this.items[i];
        }
        this.items = copy;
    }
    private void ShiftLeft(int index)
    {
        for (int i = index; i < Count - 1; i++)
        {
            this.items[i] = this.items[i + 1];
        }
    }
    private void ShrinkCapacity()
    {
        int[] copy = new int[this.items.Length / 2];
        for (int i = 0; i < Count; i++)
        {
            copy[i] = this.items[i];
        }
        this.items = copy;
    }
}

