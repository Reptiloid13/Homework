// Задача:
// Написать программу, которая из имеющегося массива строк
// формирует массив из строк, длина которых меньше либо равна 3 символа.
// Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма.
// При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.
//  
// Примеры: 
// ["hello", "2", "world",":-)"] -> ["2", ":-)"]
// ["1234", "1567", "-2", "computer science"] -> ["-2"] 
// ["Russia", "Denmark", "Kazan"] -> []


string[] CreateStringArray(int size)    // Создание  массива
{
    string[] arr = new string[size];

    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write($"Введите элемент массива {i + 1} из {size}: ");
        while (true)
        {
            arr[i] = Console.ReadLine();
            if (arr[i] != String.Empty) break;
            Console.Write("Строка не должна быть пустой.\nПовторите ввод: ");
        }
    }
    return arr;
}

void PrintStringArray(string[] array)   // вывод в консоль массива типа string
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}, ");
        else Console.Write($"{array[i]}");
    }
    Console.Write("]");
}

int CountMaxLength(string[] array, int maxStringLength) // метод для подсчета кол-ва элементов, подходящих по критерий
{
    int count = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= maxStringLength) count++;
    }

    return count;
}

string[] SelectedArray(string[] array, int resultArrayLength, int maxStringLength)  // получение результирующего массива
{
    string[] resultArr = new string[resultArrayLength];
    int k = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i].Length <= maxStringLength)
        {
            resultArr[k] = array[i];
            k++;
        }
    }
    return resultArr;
}

Console.Clear();
int maxLength = 3;  // максимальная длина элемента массива
string title = "---------------------------------------------------------------------\n"
             + "Задание: Написать программу, которая из имеющегося массива строк\n"
             + $"формирует массив из строк, длина которых меньше либо равна {maxLength} символа.\n"
             + "---------------------------------------------------------------------";
Console.WriteLine(title);

Console.Write("Введите длину текстового массива и затем введите его значения: ");
int arrayLength;
while (true)
{
    var input = Console.ReadLine();
    if (int.TryParse(input, out arrayLength) && arrayLength > 0) break;
    else Console.Write("Ошибка ввода.\nВведите целое положительное число: ");
}

string[] initArray = CreateStringArray(arrayLength);
Console.WriteLine();
PrintStringArray(initArray);

int maxLengthCount = CountMaxLength(initArray, maxLength);

string[] resultArray = SelectedArray(initArray, maxLengthCount, maxLength);

Console.Write(" -> ");
PrintStringArray(resultArray);
Console.WriteLine();
