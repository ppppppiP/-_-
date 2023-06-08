using курсова_работа;

PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

priorityQueue.Enqueue(5, 2);  // Добавление элемента со значением 5 и приоритетом 2
priorityQueue.Enqueue(10, 1); // Добавление элемента со значением 10 и приоритетом 1
priorityQueue.Enqueue(7, 3);  // Добавление элемента со значением 7 и приоритетом 3

while (priorityQueue.Count > 0)
{
    int item = priorityQueue.Dequeue();
    Console.WriteLine(item); // Вывод элементов очереди в порядке приоритета
}

// Пример использования пирамидальной сортировки
int[] array = { 9, 4, 7, 1, 3, 6, 2, 8, 5 };

HeapSort(array);

foreach (int item in array)
{
    Console.Write(item + " "); // Вывод отсортированных элементов
}
    

    // Пирамидальная сортировка
    static void HeapSort(int[] array)
{
    int n = array.Length;

    // Построение пирамиды (кучи)
    for (int i = n / 2 - 1; i >= 0; i--)
    {
        Heapify(array, n, i);
    }

    // Извлечение элементов из пирамиды в отсортированный порядок
    for (int i = n - 1; i > 0; i--)
    {
        // Обмен значениями корня (максимального элемента) с последним элементом
        int temp = array[0];
        array[0] = array[i];
        array[i] = temp;

        // Перестроение пирамиды для оставшейся части массива
        Heapify(array, i, 0);
    }
}

// Вспомогательный метод для перестроения пирамиды
static void Heapify(int[] array, int n, int i)
{
    int largest = i; // Инициализация наибольшего элемента как корня
    int left = 2 * i + 1; // Левый потомок
    int right = 2 * i + 2; // Правый потомок

    // Если левый потомок больше корня
    if (left < n && array[left] > array[largest])
    {
        largest = left;
    }

    // Если правый потомок больше наибольшего элемента
    if (right < n && array[right] > array[largest])
    {
        largest = right;
    }

    // Если наибольший элемент не корень
    if (largest != i)
    {
        // Обмен значениями
        int temp = array[i];
        array[i] = array[largest];
        array[largest] = temp;

        // Рекурсивное перестроение пирамиды в поддереве
        Heapify(array, n, largest);
    }
}