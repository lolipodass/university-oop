#include <iostream>
using namespace std;

long powMod(long base, long exp, long modulus)
{
    base %= modulus;
    long result = 1;
    while (exp > 0)
    {
        if (exp & 1)
            result = (result * base) % modulus;
        base = (base * base) % modulus;
        exp >>= 1;
    }
    return result;
}

long FuncEiler(long p, long q)
{
    return (p - 1) * (q - 1);
}

int main()
{
    string word;
    cout << "word for encrypt" << endl;
    cin >> word;
    long p = 47, q = 59;
    long exp = 257;
    long d = 1;
    while ((d * exp - 1) % FuncEiler(p, q) != 0)
        d++;
    cout << d << endl;

    long *a = new long[word.length()];

    for (long i = 0; i < word.length(); i++)
    {
        a[i] = powMod(static_cast<long>(word[i]), exp, p * q);
        cout << a[i] << " ";
    }
    cout << "\ndecrypted text: ";
    char c = ' ';
    for (long i = 0; i < word.length(); i++)
    {
        c = static_cast<char>(powMod(a[i], d, p * q));
        cout << c;
    }
}