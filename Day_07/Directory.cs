namespace Day_07;

public class Directory
{
    private readonly string Name;

    private long Size;

    private readonly Directory? Parent;

    private readonly List<Directory> SubDirectories;

    public Directory(string name, long size, Directory? parent = null)
    {
        Name = name;
        Size = size;
        Parent = parent;
        SubDirectories = new List<Directory>();
    }

    public void AddSubDirectory(Directory directory)
    {
        // If directory already exist, skip it
        foreach (var subDirectory in SubDirectories)
        {
            if (subDirectory.Name.Equals(directory.Name))
            {
                return;
            }
        }
        SubDirectories.Add(directory);
    }

    public void UpdateDirectorySize(long size)
    {
        Size += size;

        // Update sizes of all Parents directories
        Parent?.UpdateDirectorySize(size);
    }

    public Directory GetDirectory(string name)
    {
        foreach (var directory in SubDirectories)
        {
            if (directory.Name.Equals(name))
            {
                return directory;
            }
        }
        throw new KeyNotFoundException(nameof(name));
    }

    public Directory? GetParent()
    {
        return Parent;
    }

    public Directory GetRoot()
    {
        if (Parent is not null)
        {
            return Parent.GetRoot();
        }
        return this;
    }

    public long GetSize()
    {
        return Size;
    }

    public long CalculateSum(long treshold)
    {
        Queue<Directory> directories = new();
        directories.Enqueue(this);
        long sum = 0;

        while (directories.Any())
        {
            Directory directory = directories.Dequeue();
            if (directory.Size <= treshold)
            {
                sum += directory.Size;
            }

            for (int i = 0; i < directory.SubDirectories.Count; ++i)
            {
                directories.Enqueue(directory.SubDirectories[i]);
            }
        }

        return sum;
    }

    public Directory FindDirectoryToDelete(long size)
    {
        Queue<Directory> directories = new();
        directories.Enqueue(this);
        Directory toDelete = this;

        while (directories.Any())
        {
            Directory directory = directories.Dequeue();
            if (directory.Size >= size && directory.Size < toDelete.Size)
            {
                toDelete = directory;
            }

            for (int i = 0; i < directory.SubDirectories.Count; ++i)
            {
                directories.Enqueue(directory.SubDirectories[i]);
            }
        }

        return toDelete;
    }
}
