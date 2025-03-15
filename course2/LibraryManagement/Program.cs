using System;

class LibraryManager
{
    static string?[] books = new string?[5];
    static bool[] isBorrowed = new bool[5];
    static int borrowedCount = 0;
    static int maxBorrowedLimit = 3;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Search for a book");
            Console.WriteLine("4. Borrow a book");
            Console.WriteLine("5. Return a book");
            Console.WriteLine("6. Display books");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string? action = Console.ReadLine()?.Trim().ToLower();

            switch (action)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    BorrowBook();
                    break;
                case "5":
                    ReturnBook();
                    break;
                case "6":
                    DisplayBooks();
                    break;
                case "7":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // ✅ Add a book
    static void AddBook()
    {
        if (Array.IndexOf(books, null) == -1)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.Write("Enter the title of the book to add: ");
        string? newBook = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newBook))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i]))
            {
                books[i] = newBook;
                isBorrowed[i] = false; // New book is not borrowed by default
                Console.WriteLine($"Book '{newBook}' added.");
                return;
            }
        }
    }

    // ✅ Remove a book
    static void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string? bookToRemove = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(bookToRemove))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]) && books[i]!.Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
            {
                books[i] = null;
                isBorrowed[i] = false;
                Console.WriteLine($"Book '{bookToRemove}' removed.");
                return;
            }
        }

        Console.WriteLine($"Book '{bookToRemove}' not found.");
    }

    // ✅ Search for a book
    static void SearchBook()
    {
        Console.Write("Enter the title of the book to search for: ");
        string? searchTitle = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchTitle))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]) && books[i]!.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Book '{searchTitle}' is available.");
                return;
            }
        }

        Console.WriteLine($"Book '{searchTitle}' is not in the collection.");
    }

    // ✅ Borrow a book
    static void BorrowBook()
    {
        if (borrowedCount >= maxBorrowedLimit)
        {
            Console.WriteLine("You have reached the limit of borrowed books.");
            return;
        }

        Console.Write("Enter the title of the book to borrow: ");
        string? bookToBorrow = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(bookToBorrow))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]) && books[i]!.Equals(bookToBorrow, StringComparison.OrdinalIgnoreCase))
            {
                if (isBorrowed[i])
                {
                    Console.WriteLine($"Book '{bookToBorrow}' is already borrowed.");
                    return;
                }

                isBorrowed[i] = true;
                borrowedCount++;
                Console.WriteLine($"Book '{bookToBorrow}' has been borrowed.");
                return;
            }
        }

        Console.WriteLine($"Book '{bookToBorrow}' not found.");
    }

    // ✅ Return a book
    static void ReturnBook()
    {
        Console.Write("Enter the title of the book to return: ");
        string? bookToReturn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(bookToReturn))
        {
            Console.WriteLine("Invalid book title.");
            return;
        }

        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]) && books[i]!.Equals(bookToReturn, StringComparison.OrdinalIgnoreCase))
            {
                if (!isBorrowed[i])
                {
                    Console.WriteLine($"Book '{bookToReturn}' was not borrowed.");
                    return;
                }

                isBorrowed[i] = false;
                borrowedCount--;
                Console.WriteLine($"Book '{bookToReturn}' has been returned.");
                return;
            }
        }

        Console.WriteLine($"Book '{bookToReturn}' not found.");
    }

    // ✅ Display available books
    static void DisplayBooks()
    {
        Console.WriteLine("\nAvailable books:");

        bool isEmpty = true;
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                string status = isBorrowed[i] ? "(Borrowed)" : "(Available)";
                Console.WriteLine($"- {books[i]} {status}");
                isEmpty = false;
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("No books in the library.");
        }

        Console.WriteLine($"\nYou have borrowed {borrowedCount}/{maxBorrowedLimit} books.");
    }
}
