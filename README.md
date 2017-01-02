```3. odev 1. ödevin devamı olarak bu repoya commitlenmiştir, ama açıklama yazılması unutulmuştur.```

# Homework 1 -  Process Control Block

Soru

```
1. Process Control Block(PCB) yapısını tutacak bir class oluşturulması
2. Waiting  ve Ready kuyruklarının oluşturulabileceği, 
3. Bağlı Liste mantığıyla çalışacak bir Queue class'ı oluşturun. 
4. Ekleme,  silme ve görüntüleme metodları yeterli olacaktır. 
```

[Process Control Block sınıfı](../master/OperationSystems/ProcessControlBlock.cs)

İleride ne yapacağımız tam kesin olmadığı için PCB class'ı tam değildir.

[Bağlı Queue yapısı](../master/OperationSystems.DataStructures/LinkedQueue.cs)

```C#

public class LinkedQueue<T> {

    public Node<T> Front { get; set; }
    public Node<T> Rear { get; set; }


    public void Enqueue(T value) {
        var node = new Node<T>(value);
        if (Rear == null) {
            Front = node;
            Rear = node;
        } else {
            Rear.Next = node;
            Rear = node;
        }
    }

    public Node<T> Dequeue() {
        if (Front == null) {
            return null;
        }
        var target = Front;
        Front = Front.Next;
        return target;
    }

    public override string ToString() {
        var output = new StringBuilder();
        var current = Front;
        while (current != null) {
            output.Append($"{current.Value.ToString()} ");
            current = current.Next;
        }
        return output.ToString();
    }

    public bool IsQueueEmpty() {
        return Front == null;
    }

}

public class Node<T> {

    public Node(T value) {
        Value = value;
    }

    public Node<T> Next { get; set; }

    public T Value { get; set; }

}

```

[Program.cs](../master/operation_system_homework/Program.cs)

```C#
 private static void Main(string[] args) {
  var list = new LinkedQueue<int>();
  list.Enqueue(1);
  list.Enqueue(2);
  list.Enqueue(3);
  list.Enqueue(4);
  list.Enqueue(5);
  list.Enqueue(6);
  list.Enqueue(7);

  while (!list.IsQueueEmpty()) {
    Console.WriteLine(list);
    Console.WriteLine(list.Dequeue().Value);
  }
}

```
