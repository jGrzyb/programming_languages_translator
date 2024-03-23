# translator-jezyków-programowania
W przyszłości będzie to potencjalnie translator z języka c na python, ale aktualnie jest to tylko skaner generujący listę tokenów i plik html z pokolorowaną składnią.

By uruchomić należy pobrać ten [folder](bin/Debug/net7.0) i z jego poziomu uruchomić [skaner.exe](bin/Debug/net7.0/skaner.exe). Może się też przydać platforma .NET.

Program generuje do pliku [colored.html](colored.html) pokolorowany tekst z pliku źródłowego. Domyślnie jest to [Scanner.cs](bin/Debug/net7.0/Scanner.cs) ale z wiersza polenceń można ustawić plik źródłowy podając jego ścieżkę po komendzie uruchomienia np.
```
.\skaner.exe Scanner.cs
```

![obrazek](colorful_code.png)
